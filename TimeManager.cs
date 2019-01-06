// ClockIn
// Copyright (C) 2012-2019 Jens Rossbach, All Rights Reserved.


using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;


namespace ClockIn
{
    /// <summary>
    ///   Levels of work which can be reached during the day
    /// </summary>
    public enum WorkingLevel
    {
        RegularTime        = 0,  // Working within regular time
        AheadOfClosingTime = 1,  // Ahead of closing time
        OverTime           = 2,  // Working longer than regular time
        ApproachingMaxTime = 3,  // Approaching maximum working time
        MaxTimeViolation   = 4   // Exceeded maximum working time
    }

    /// <summary>
    ///   Working state
    /// </summary>
    public enum WorkingState
    {
        Working = 0,  // Present and working
        Absent  = 1   // Absent / not working
    }


    /// <summary>
    ///   Arguments for working time alert events
    /// </summary>
    public class WorkingTimeAlertEventArgs : EventArgs
    {
        /// <summary>
        ///   Working level
        /// </summary>
        public WorkingLevel WorkingLevel { get; set; }

        /// <summary>
        ///   Time in minutes ahead of the actual working time limit
        ///   (only applicable to ahead levels)
        /// </summary>
        public int AheadTime { get; set; }

        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        /// <param name="level">Working level</param>
        /// <param name="aheadTime">Ahead time in minutes</param>
        public WorkingTimeAlertEventArgs(WorkingLevel level, int aheadTime = 0)
        {
            WorkingLevel = level;
            AheadTime = aheadTime;
        }
    }


    /// <summary>
    ///   Event handler for working time alerts
    /// </summary>
    public delegate void WorkingTimeAlertEventHandler(object sender, WorkingTimeAlertEventArgs e);


    /// <summary>
    ///   Calculates all time related values like elapsed and remaining working
    ///   time, total and chargeable absence time and manages notification timers.
    /// </summary>
    class TimeManager
    {
        private DateTime startTime;

        private Timer notifyTimer = new Timer();
        private Timer periodicTimer = new Timer();
        private Timer eodTimer = new Timer();

        private Properties.Settings settings = Properties.Settings.Default;
        private Session session = Session.Default;

        private WorkingLevel level = WorkingLevel.RegularTime;
        private WorkingState state = WorkingState.Working;
        private TimePeriod currentAbsence = null;


        /// <summary>
        ///   Event notifies when absence has been updated.
        /// </summary>
        public event EventHandler AbsenceUpdated;

        /// <summary>
        ///   Event notifies when working time has been updated.
        /// </summary>
        public event EventHandler WorkingTimeUpdated;

        /// <summary>
        ///   Event notifies when leave time has been updated.
        /// </summary>
        public event EventHandler LeaveTimeUpdated;

        /// <summary>
        ///   Event notifies when working level has been updated.
        /// </summary>
        public event EventHandler WorkingLevelUpdated;

        /// <summary>
        ///   Event notifies when working state has been updated.
        /// </summary>
        public event EventHandler WorkingStateUpdated;

        /// <summary>
        ///   Event notifies when a working time alert occurs.
        /// </summary>
        public event WorkingTimeAlertEventHandler WorkingTimeAlert;


        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public TimeManager()
        {
            // take time snapshot
            startTime = DateTime.Now.Truncate(TimeSpan.FromMinutes(1)) - TimeSpan.FromMinutes((double)settings.ArrivalTimeOffset);

            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
            Absence.ListChanged += Absence_ListChanged;
            session.PropertyValidated += Session_PropertyValidated;
            settings.PropertyChanged += Settings_PropertyChanged;
            AbsenceUpdated += TotalAbsence_Updated;
            WorkingStateUpdated += WorkingState_Updated;

            notifyTimer.Tick += NotifyTimer_Tick;

            periodicTimer.Tick += PeriodicTimer_Tick;
            periodicTimer.Interval = 60000;

            eodTimer.Tick += EodTimer_Tick;
        }


        /// <summary>
        ///   List of absence time periods
        /// </summary>
        public BindingList<TimePeriod> Absence { get; } = new BindingList<TimePeriod>();

        /// <summary>
        ///   Total absence including implicitly added chargeable break
        /// </summary>
        public TimeSpan TotalAbsence { get; private set; } = TimeSpan.Zero;

        /// <summary>
        ///   Time of clocking out
        /// </summary>
        public DateTime ClockOutTime => (currentAbsence != null) ? currentAbsence.StartTime : DateTime.MinValue;

        /// <summary>
        ///   Current working level
        /// </summary>
        public WorkingLevel WorkingLevel
        {
            get => level;
            private set
            {
                if (level != value)
                {
                    level = value;
                    WorkingLevelUpdated?.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        ///   Current working state
        /// </summary>
        public WorkingState WorkingState
        {
            get => state;
            set
            {
                if (state != value)
                {
                    SetWorkingState(value, DateTime.Now);
                }
            }
        }


        /// <summary>
        ///   Handles application start.
        /// </summary>
        public void HandleStart()
        {
            Debug.WriteLine("[TimeManager] Handle application start.");

            if (session.Arrival.Date == startTime.Date)
            {
                if (settings.NewSessionOnStartup)
                {
                    RestartSession(false);
                }
                else if (settings.AskSessionOnStartup)
                {
                    DialogResult result = MessageBox.Show(Properties.Resources.AskSessionOnStartup,
                                                          Properties.Resources.WindowCaption,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        RestartSession(false);
                    }
                    else
                    {
                        ContinueSession();
                    }
                }
                else
                {
                    ContinueSession();
                }
            }
            else
            {
                RestartSession(false);
            }

            SetupEoDTimer();
        }

        /// <summary>
        ///   Continues last session earlier from the day.
        /// </summary>
        public void ContinueSession()
        {
            Debug.WriteLine("[TimeManager] Continue last session.");

            if (session.ClockedOut)
            {
                SetWorkingState(WorkingState.Absent, session.ClockOutTime);
            }

            LoadAbsenceFromSession();

            if (settings.ClockInAtStart)
            {
                WorkingState = WorkingState.Working;
            }
        }

        /// <summary>
        ///   Restarts the session.
        /// </summary>
        /// <param name="toCurTime">
        ///   true if session should be reset to current time, false if session
        ///   should be reset to time when application started
        /// </param>
        public void RestartSession(bool toCurTime)
        {
            Debug.WriteLine("[TimeManager] Restart session (" + (toCurTime ? "now" : "to start") + ").");

            session.Arrival = toCurTime ? DateTime.Now.Truncate(TimeSpan.FromMinutes(1)) : startTime;
            session.NotifyLevel = 0;
            session.Absence = string.Empty;
            session.ClockedOut = false;
            session.ClockOutTime = DateTime.MinValue;

            session.Save();

            Absence.Clear();
            UpdateTotalAbsence();
        }

        /// <summary>
        ///   Returns the elapsed working time.
        /// </summary>
        /// <returns>Elapsed working time</returns>
        public TimeSpan GetElapsedWorkingTime()
        {
            DateTime cur = DateTime.Now;
            TimeSpan workingTime = cur - session.Arrival;

            if (TotalAbsence >= workingTime)
            {
                workingTime = TimeSpan.Zero;
            }
            else
            {
                workingTime -= TotalAbsence;
            }

            if (workingTime >= TimeSpan.FromHours((double)settings.MaximumWorkingTime))
            {
                WorkingLevel = WorkingLevel.MaxTimeViolation;
            }
            else if ((settings.NotifyAdvance > 0) &&
                     (workingTime >= (TimeSpan.FromHours((double)settings.MaximumWorkingTime) -
                                      TimeSpan.FromMinutes((double)settings.NotifyAdvance))))
            {
                WorkingLevel = WorkingLevel.ApproachingMaxTime;
            }
            else if (workingTime >= TimeSpan.FromHours((double)settings.RegularWorkingTime))
            {
                WorkingLevel = WorkingLevel.OverTime;
            }
            else if ((settings.NotifyRegAdvance > 0) &&
                     (workingTime >= (TimeSpan.FromHours((double)settings.RegularWorkingTime) -
                                      TimeSpan.FromMinutes((double)settings.NotifyRegAdvance))))
            {
                WorkingLevel = WorkingLevel.AheadOfClosingTime;
            }
            else
            {
                WorkingLevel = WorkingLevel.RegularTime;
            }

            return workingTime;
        }

        /// <summary>
        ///   Returns the remaining working time.
        /// </summary>
        /// <returns>Remaining working time</returns>
        public TimeSpan GetRemainingWorkingTime()
        {
            DateTime leaveTime = GetLeaveTime(out bool overTime);
            DateTime cur = DateTime.Now;

            if (leaveTime > cur)
            {
                return leaveTime - cur;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }

        /// <summary>
        ///   Retuens the leave time.
        /// </summary>
        /// <param name="overTime">
        ///     true if regular working time has been reached, false otherwise
        /// </param>
        /// <returns>Leave time</returns>
        public DateTime GetLeaveTime(out bool overTime)
        {
            DateTime leaveTime = CalculateLeaveTime((int)settings.RegularWorkingTime);
            overTime = (leaveTime < DateTime.Now);

            if (overTime || settings.DisplayMaximumTime)
            {
                leaveTime = CalculateLeaveTime((int)settings.MaximumWorkingTime);
            }

            return leaveTime;
        }

        /// <summary>
        ///   Restarts the notification timer for repeatedly 
        ///   notifying about maximum working time reached.
        /// </summary>
        /// <param name="minutes">Delay for the timer</param>
        public void RepeatNotificationTimer(int minutes)
        {
            if (minutes > 0)
            {
                session.NotifyLevel = 3;
                session.Save();

                notifyTimer.Interval = minutes * 60 * 1000;
                notifyTimer.Start();

                Debug.WriteLine("[TimeManager] Notify timer started at level " + session.NotifyLevel + " (" + minutes + " min).");
            }
        }

        /// <summary>
        ///   Sets the current working state.
        /// </summary>
        /// <param name="state">Target working state</param>
        /// <param name="time">Clock in/out time</param>
        private void SetWorkingState(WorkingState state, DateTime time)
        {
            Debug.WriteLine("[TimeManager] Changing working state to " + state);

            if (state == WorkingState.Absent)
            {
                currentAbsence = new TimePeriod
                {
                    StartTime = time
                };
            }
            else if (currentAbsence != null)
            {
                currentAbsence.EndTime = time;
                if (currentAbsence.Duration != TimeSpan.Zero)
                {
                    if (settings.ConfirmAbsenceOnClockIn)
                    {
                        DialogResult res = new AbsenceInputDialog(currentAbsence, Properties.Resources.EditAbsence).ShowDialog();

                        if (res == DialogResult.OK)
                        {
                            Absence.Add(currentAbsence);
                        }
                    }
                    else
                    {
                        Absence.Add(currentAbsence);
                    }
                }
                else
                {
                    UpdateTotalAbsence();
                }

                currentAbsence = null;
            }

            this.state = state;
            WorkingStateUpdated?.Invoke(this, new EventArgs());
        }

        /// <summary>
        ///   Configures and starts the end-of-day timer.
        /// </summary>
        private void SetupEoDTimer()
        {
            eodTimer.Stop();
            eodTimer.Interval = (int)(DateTime.Today.AddDays(1.0) - DateTime.Now).TotalMilliseconds;
            eodTimer.Start();

            Debug.WriteLine("[TimeManager] End-of-day timer started (" + eodTimer.Interval + " ms).");
        }

        /// <summary>
        ///   Checks if any time limit has been reached and notifies the user.
        /// </summary>
        private void CheckExpiration()
        {
            TimeSpan ts = GetElapsedWorkingTime();

            if (session.NotifyLevel < (int)level)
            {
                int aheadTime = 0;
                if (level == WorkingLevel.AheadOfClosingTime)
                {
                    aheadTime = GetRemainingMinutes((int)settings.RegularWorkingTime);
                }
                else if (level == WorkingLevel.ApproachingMaxTime)
                {
                    aheadTime = GetRemainingMinutes((int)settings.MaximumWorkingTime);
                }

                WorkingTimeAlert?.Invoke(this, new WorkingTimeAlertEventArgs(level, aheadTime));
                session.NotifyLevel = (int)level;
            }

            notifyTimer.Stop();

            switch (session.NotifyLevel)
            {
                case 0:
                {
                    ts = CalculateRemainingTime((int)settings.RegularWorkingTime) - new TimeSpan(0, (int)settings.NotifyRegAdvance, 0);
                    break;
                }
                case 1:
                {
                    ts = CalculateRemainingTime((int)settings.RegularWorkingTime);
                    break;
                }
                case 2:
                {
                    ts = CalculateRemainingTime((int)settings.MaximumWorkingTime) - new TimeSpan(0, (int)settings.NotifyAdvance, 0);
                    break;
                }
                case 3:
                {
                    ts = CalculateRemainingTime((int)settings.MaximumWorkingTime);
                    break;
                }
                default:
                {
                    ts = TimeSpan.Zero;
                    break;
                }
            }

            if (ts != TimeSpan.Zero)
            {
                int interval = (int)ts.TotalMilliseconds;
                if (interval > 0)
                {
                    notifyTimer.Interval = interval;
                    notifyTimer.Start();

                    Debug.WriteLine("[TimeManager] Notify timer started at level " + session.NotifyLevel + " (" + interval + " ms).");
                }
            }

            WorkingTimeUpdated?.Invoke(this, new EventArgs());
        }

        /// <summary>
        ///   Returns the remaining minutes until time limit.
        /// </summary>
        /// <param name="clearWorkingTimeHours">Number of hours to work</param>
        /// <returns>Remaining minutes</returns>
        private int GetRemainingMinutes(int clearWorkingTimeHours)
        {
            return (int)Math.Ceiling((CalculateLeaveTime(clearWorkingTimeHours) - DateTime.Now).TotalMinutes);
        }

        /// <summary>
        ///   Calculates the leave time.
        /// </summary>
        /// <param name="clearWorkingTimeHours">Number of hours to work</param>
        /// <returns>Leave time</returns>
        private DateTime CalculateLeaveTime(int clearWorkingTimeHours) => session.Arrival + TimeSpan.FromHours(clearWorkingTimeHours) + TotalAbsence;

        /// <summary>
        ///   Calculates the remaining working time.
        /// </summary>
        /// <param name="clearWorkingTimeHours">Number of hours to work</param>
        /// <returns>Remaining working time</returns>
        private TimeSpan CalculateRemainingTime(int clearWorkingTimeHours) => CalculateLeaveTime(clearWorkingTimeHours) - DateTime.Now;

        /// <summary>
        ///   Updates the total absence time span considering chargeable breaks.
        /// </summary>
        private void UpdateTotalAbsence()
        {
            periodicTimer.Stop();

            DateTime now = DateTime.Now;
            TimePeriod breakPeriod = new TimePeriod(new DateTime(now.Year, now.Month, now.Day,
                                                                 settings.BreaksBegin.Hour,
                                                                 settings.BreaksBegin.Minute, 0),
                                                    new DateTime(now.Year, now.Month, now.Day,
                                                                 settings.BreaksEnd.Hour,
                                                                 settings.BreaksEnd.Minute, 0));
            TimeSpan chargeableAbsence = TimeSpan.Zero;
            TotalAbsence = TimeSpan.Zero;

            foreach (TimePeriod tp in Absence)
            {
                chargeableAbsence += tp.GetIntersection(breakPeriod);
                TotalAbsence += tp.Duration;
            }

            if ((session.Arrival.TimeOfDay >= settings.BreaksBegin.TimeOfDay) &&
                (session.Arrival.TimeOfDay <= settings.BreaksEnd.TimeOfDay))
            {
                TimePeriod tp = new TimePeriod(settings.BreaksBegin, session.Arrival);
                chargeableAbsence += tp.GetIntersection(breakPeriod);
            }

            TimeSpan breakAdder = TimeSpan.Zero;

            if (session.Arrival.TimeOfDay <= settings.BreaksEnd.TimeOfDay)
            {
                breakAdder = TimeSpan.FromMinutes((double)settings.Break);

                if (chargeableAbsence < breakAdder)
                {
                    breakAdder -= chargeableAbsence;
                }
                else
                {
                    breakAdder = TimeSpan.Zero;
                }
            }
            else
            {
                TimeSpan work = now - session.Arrival;
                if (work >= TotalAbsence)
                {
                    work -= TotalAbsence;
                }
                else
                {
                    work = TimeSpan.Zero;
                }

                if (work > TimeSpan.FromHours((double)settings.OutsideLunchWorkspan2))
                {
                    breakAdder = TimeSpan.FromMinutes((double)settings.OutsideLunchBreak2);
                }
                else if (work > TimeSpan.FromHours((double)settings.OutsideLunchWorkspan1))
                {
                    breakAdder = TimeSpan.FromMinutes((double)settings.OutsideLunchBreak1);
                    periodicTimer.Start();

                    Debug.WriteLine("[TimeManager] Periodic timer started.");
                }
                else
                {
                    periodicTimer.Start();
                    Debug.WriteLine("[TimeManager] Periodic timer started.");
                }
            }

            TotalAbsence += breakAdder;
            AbsenceUpdated?.Invoke(this, new EventArgs());
        }

        /// <summary>
        ///   Stores all absence periods to the session.
        /// </summary>
        private void StoreAbsenceInSession()
        {
            session.Absence = string.Empty;

            foreach (TimePeriod tp in Absence)
            {
                if (session.Absence != string.Empty)
                {
                    session.Absence += ",";
                }

                session.Absence += tp.ToString();
            }

            session.Save();
        }

        /// <summary>
        ///   Loads all absence periods from the session.
        /// </summary>
        private void LoadAbsenceFromSession()
        {
            if (session.Absence != string.Empty)
            {
                string[] tpList = session.Absence.Split(',');

                foreach (string tp in tpList)
                {
                    if (tp != string.Empty)
                    {
                        Absence.Add(new TimePeriod(tp));
                    }
                }
            }

            if (state == WorkingState.Working)
            {
                UpdateTotalAbsence();
            }
        }

        /// <summary>
        ///   Handles total absence update events.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TotalAbsence_Updated(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] Total absence has been updated.");

            CheckExpiration();
            LeaveTimeUpdated?.Invoke(this, new EventArgs());
        }

        /// <summary>
        ///   Handles working state update events.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void WorkingState_Updated(object sender, EventArgs e)
        {
            if (state == WorkingState.Absent)
            {
                notifyTimer.Stop();
                periodicTimer.Stop();

                session.ClockedOut = true;
                session.ClockOutTime = currentAbsence.StartTime;
            }
            else
            {
                session.ClockedOut = false;
                session.ClockOutTime = DateTime.MinValue;
            }

            session.Save();
        }

        /// <summary>
        ///   Handles absence list change events.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void Absence_ListChanged(object sender, ListChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] Absence list has changed.");

            UpdateTotalAbsence();
            StoreAbsenceInSession();
        }

        /// <summary>
        ///   Handles validation of session properties.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void Session_PropertyValidated(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] Session property '" + e.PropertyName + "' has been validated.");

            switch (e.PropertyName)
            {
                case "Arrival":
                {
                    session.Save();
                    UpdateTotalAbsence();

                    break;
                }
            }
        }

        /// <summary>
        ///   Handles changes of user settings properties.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] Settings property '" + e.PropertyName + "' has changed.");

            switch (e.PropertyName)
            {
                case "RegularWorkingTime":
                case "MaximumWorkingTime":
                {
                    CheckExpiration();
                    LeaveTimeUpdated?.Invoke(this, new EventArgs());

                    break;
                }
                case "BreaksBegin":
                case "BreaksEnd":
                case "Break":
                case "OutsideLunchWorkspan1":
                case "OutsideLunchWorkspan2":
                case "OutsideLunchBreak1":
                case "OutsideLunchBreak2":
                {
                    UpdateTotalAbsence();
                    break;
                }
            }
        }

        /// <summary>
        ///   Handles power mode change events.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] Power mode has changed:  MOD " + e.Mode);

            if (e.Mode == PowerModes.Resume)
            {
                if (settings.LowPowerIsStart)
                {
                    startTime = DateTime.Now.Truncate(TimeSpan.FromMinutes(1)) - TimeSpan.FromMinutes((double)settings.ArrivalTimeOffset);
                    HandleStart();
                }
                else
                {
                    if (state == WorkingState.Absent)
                    {
                        if (settings.ClockInAtWakeup)
                        {
                            WorkingState = WorkingState.Working;
                        }
                    }
                    else
                    {
                        UpdateTotalAbsence();
                    }

                    SetupEoDTimer();
                }
            }
        }

        /// <summary>
        ///   Handles expiration of the notification timer.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NotifyTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] Notify timer expired.");
            notifyTimer.Stop();

            CheckExpiration();
        }

        /// <summary>
        ///   Handles expiration of the periodic timer.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void PeriodicTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] Periodic timer expired.");
            periodicTimer.Stop();

            UpdateTotalAbsence();
        }

        /// <summary>
        ///   Handles expiration of the end-of-day timer.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void EodTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] End-of-day timer expired.");

            notifyTimer.Stop();
            periodicTimer.Stop();
            eodTimer.Stop();

            DialogResult result = MessageBox.Show(Properties.Resources.AskSessionAtMidnight,
                                                  Properties.Resources.WindowCaption,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RestartSession(true);
            }
            else
            {
                UpdateTotalAbsence();
            }

            SetupEoDTimer();
        }
    }
}
