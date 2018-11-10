// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;


namespace ClockIn
{
    /// <summary>
    ///   Calculates all time related values like elapsed and remaining working
    ///   time, total and chargeable absence time and manages notification timers.
    /// </summary>
    class TimeManager
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public TimeManager()
        {
            session = Session.Default;
            userSettings = Properties.Settings.Default;

            // take time snapshot
            startTime = DateTime.Now.Truncate(TimeSpan.FromMinutes(1)) - TimeSpan.FromMinutes((double)userSettings.ArrivalTimeOffset);

            absence = new BindingList<TimePeriod>();
            totalAbsence = TimeSpan.Zero;

            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            absence.ListChanged += Absence_ListChanged;
            session.PropertyValidated += Session_PropertyValidated;
            userSettings.PropertyChanged += UserSettings_PropertyChanged;
            AbsenceUpdated += TotalAbsence_Updated;

            notifyTimer = new Timer();
            notifyTimer.Tick += new EventHandler(NotifyTimer_Tick);

            periodicTimer = new Timer();
            periodicTimer.Tick += new EventHandler(PeriodicTimer_Tick);
            periodicTimer.Interval = 60000;

            eodTimer = new Timer();
            eodTimer.Tick += EodTimer_Tick;
        }

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
        ///   List of absence time periods
        /// </summary>
        public BindingList<TimePeriod> Absence
        {
            get
            {
                return absence;
            }
        }

        /// <summary>
        ///   Total absence including implicitly added chargeable break
        /// </summary>
        public TimeSpan TotalAbsence
        {
            get
            {
                return totalAbsence;
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
                if (userSettings.NewSessionOnStartup)
                {
                    RestartSession(false);
                }
                else if (userSettings.AskSessionOnStartup)
                {
                    DialogResult result = MessageBox.Show(Properties.Resources.AskSessionOnStartup,
                                                          Properties.Resources.MessageBoxCaption,
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

            LoadAbsenceFromSession();
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

            session.Save();

            absence.Clear();
            UpdateTotalAbsence();
        }

        /// <summary>
        ///   Returns the elapsed working time.
        /// </summary>
        /// <param name="level">Working level which has been reached</param>
        /// <returns>Elapsed working time</returns>
        public TimeSpan GetElapsedWorkingTime(out WorkingLevel level)
        {
            DateTime cur = DateTime.Now;
            TimeSpan workingTime = cur - session.Arrival;

            if (totalAbsence >= workingTime)
            {
                workingTime = TimeSpan.Zero;
            }
            else
            {
                workingTime -= totalAbsence;
            }

            if (workingTime >= TimeSpan.FromHours((double)userSettings.MaximumWorkingTime))
            {
                level = WorkingLevel.MaxTimeViolation;
            }
            else if ((userSettings.NotifyAdvance > 0) &&
                     (workingTime >= (TimeSpan.FromHours((double)userSettings.MaximumWorkingTime) -
                                      TimeSpan.FromMinutes((double)userSettings.NotifyAdvance))))
            {
                level = WorkingLevel.ApproachingMaxTime;
            }
            else if (workingTime >= TimeSpan.FromHours((double)userSettings.RegularWorkingTime))
            {
                level = WorkingLevel.OverTime;
            }
            else if ((userSettings.NotifyRegAdvance > 0) &&
                     (workingTime >= (TimeSpan.FromHours((double)userSettings.RegularWorkingTime) -
                                      TimeSpan.FromMinutes((double)userSettings.NotifyRegAdvance))))
            {
                level = WorkingLevel.AheadOfClosingTime;
            }
            else
            {
                level = WorkingLevel.RegularTime;
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
        /// <param name="level">
        ///     true if regular working time has been reached, false otherwise
        /// </param>
        /// <returns>Leave time</returns>
        public DateTime GetLeaveTime(out bool overTime)
        {
            DateTime leaveTime = CalculateLeaveTime((int)userSettings.RegularWorkingTime);
            overTime = (leaveTime < DateTime.Now);

            if (overTime || Properties.Settings.Default.DisplayMaximumTime)
            {
                leaveTime = CalculateLeaveTime((int)userSettings.MaximumWorkingTime);
            }

            return leaveTime;
        }

        /// <summary>
        ///   Restarts the notification timer for notifying about maximum
        ///   working time reached.
        /// </summary>
        /// <param name="minutes">Delay for the timer</param>
        public void RestartMaxTimeTimer(int minutes)
        {
            if (minutes > 0)
            {
                session.NotifyLevel = 1;
                session.Save();

                notifyTimer.Interval = minutes * 60 * 1000;
                notifyTimer.Start();
            }
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
            TimeSpan workingTime = GetElapsedWorkingTime(out WorkingLevel level);

            if (level == WorkingLevel.MaxTimeViolation)
            {
                NotifyMaximumTimeLimit(false);
            }
            else if (level == WorkingLevel.ApproachingMaxTime)
            {
                NotifyMaximumTimeLimit(true);
            }
            else if (level == WorkingLevel.OverTime)
            {
                NotifyRegularTimeLimit(false);
            }
            else if (level == WorkingLevel.AheadOfClosingTime)
            {
                NotifyRegularTimeLimit(true);
            }

            notifyTimer.Stop();

            if (session.NotifyLevel < 1)
            {
                workingTime = CalculateRemainingTime((int)userSettings.RegularWorkingTime) - new TimeSpan(0, (int)userSettings.NotifyRegAdvance, 0);
                int interval = (int)(workingTime.Ticks / TimeSpan.TicksPerMillisecond);
                if (interval > 0)
                {
                    notifyTimer.Interval = interval;
                    notifyTimer.Start();

                    Debug.WriteLine("[TimeManager] Notify timer started at level " + session.NotifyLevel + " (" + interval + " ms).");
                }
            }
            else if (session.NotifyLevel < 2)
            {
                workingTime = CalculateRemainingTime((int)userSettings.MaximumWorkingTime) - new TimeSpan(0, (int)userSettings.NotifyAdvance, 0);
                int interval = (int)(workingTime.Ticks / TimeSpan.TicksPerMillisecond);
                if (interval > 0)
                {
                    notifyTimer.Interval = interval;
                    notifyTimer.Start();

                    Debug.WriteLine("[TimeManager] Notify timer started at level " + session.NotifyLevel + " (" + interval + " ms).");
                }
            }

            NotifyWorkingTimeUpdated();
        }

        /// <summary>
        ///   Notifies that regular working time has been reached.
        /// </summary>
        private void NotifyRegularTimeLimit(bool ahead)
        {
            if (session.NotifyLevel < 1)
            {
                session.NotifyLevel = 1;
                session.Save();

                NotificationDialog dlg = new NotificationDialog();

                string message;
                if (ahead)
                {
                    message = string.Format(Properties.Resources.AheadOfRegularTimeLimit, GetRemainingMinutes((int)userSettings.RegularWorkingTime));
                }
                else
                {
                    message = Properties.Resources.RegularTimeLimitReached;
                }

                dlg.Initialize(Properties.Resources.BigSmile, message, false);
                dlg.Show();
            }
        }

        /// <summary>
        ///   Notifies that maximum working time has been reached.
        /// </summary>
        /// <param name="approaching">true if we are ahead of maximum working time</param>
        private void NotifyMaximumTimeLimit(bool approaching)
        {
            if (session.NotifyLevel < 2)
            {
                session.NotifyLevel = 2;
                session.Save();

                NotificationDialog dlg = new NotificationDialog();

                string message;
                if (approaching)
                {
                    message = string.Format(Properties.Resources.ApproachingMaximumTimeLimit, GetRemainingMinutes((int)userSettings.MaximumWorkingTime));
                }
                else
                {
                    message = Properties.Resources.MaxmimumTimeLimitReached;
                }

                dlg.Initialize(approaching ? Properties.Resources.Ooooh : Properties.Resources.Sad, message, approaching);
                dlg.Show();
            }
        }

        /// <summary>
        ///   Returns the remaining minutes until time limit.
        /// </summary>
        /// <param name="clearWorkingTimeHours">Number of hours to work</param>
        /// <returns>Remaining minutes</returns>
        int GetRemainingMinutes(int clearWorkingTimeHours)
        {
            return (int)Math.Ceiling((CalculateLeaveTime(clearWorkingTimeHours) - DateTime.Now).TotalMinutes);
        }

        /// <summary>
        ///   Calculates the leave time.
        /// </summary>
        /// <param name="clearWorkingTimeHours">Number of hours to work</param>
        /// <returns>Leave time</returns>
        private DateTime CalculateLeaveTime(int clearWorkingTimeHours) => session.Arrival + TimeSpan.FromHours(clearWorkingTimeHours) + totalAbsence;

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
                                                                 userSettings.BreaksBegin.Hour,
                                                                 userSettings.BreaksBegin.Minute, 0),
                                                    new DateTime(now.Year, now.Month, now.Day,
                                                                 userSettings.BreaksEnd.Hour,
                                                                 userSettings.BreaksEnd.Minute, 0));
            TimeSpan chargeableAbsence = TimeSpan.Zero;
            totalAbsence = TimeSpan.Zero;

            foreach (TimePeriod tp in absence)
            {
                chargeableAbsence += tp.GetIntersection(breakPeriod);
                totalAbsence += tp.Duration;
            }

            if ((session.Arrival.TimeOfDay >= userSettings.BreaksBegin.TimeOfDay) &&
                (session.Arrival.TimeOfDay <= userSettings.BreaksEnd.TimeOfDay))
            {
                TimePeriod tp = new TimePeriod(userSettings.BreaksBegin, session.Arrival);
                chargeableAbsence += tp.GetIntersection(breakPeriod);
            }

            TimeSpan breakAdder = TimeSpan.Zero;

            if (session.Arrival.TimeOfDay <= userSettings.BreaksEnd.TimeOfDay)
            {
                breakAdder = TimeSpan.FromMinutes((double)userSettings.Break);

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
                if (work >= totalAbsence)
                {
                    work -= totalAbsence;
                }
                else
                {
                    work = TimeSpan.Zero;
                }

                if (work > TimeSpan.FromHours((double)userSettings.OutsideLunchWorkspan2))
                {
                    breakAdder = TimeSpan.FromMinutes((double)userSettings.OutsideLunchBreak2);
                }
                else if (work > TimeSpan.FromHours((double)userSettings.OutsideLunchWorkspan1))
                {
                    breakAdder = TimeSpan.FromMinutes((double)userSettings.OutsideLunchBreak1);
                    periodicTimer.Start();

                    Debug.WriteLine("[TimeManager] Periodic timer started.");
                }
                else
                {
                    periodicTimer.Start();
                    Debug.WriteLine("[TimeManager] Periodic timer started.");
                }
            }

            totalAbsence += breakAdder;
            NotifyAbsenceUpdated();
        }

        /// <summary>
        ///   Stores all absence periods to the session.
        /// </summary>
        private void StoreAbsenceInSession()
        {
            session.Absence = string.Empty;

            foreach (TimePeriod tp in absence)
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
                        absence.Add(new TimePeriod(tp));
                    }
                }
            }

            UpdateTotalAbsence();
        }

        private void TotalAbsence_Updated(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] Total absence has been updated.");

            CheckExpiration();
            NotifyLeaveTimeUpdated();
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
        private void UserSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] User settings property '" + e.PropertyName + "' has changed.");

            switch (e.PropertyName)
            {
                case "RegularWorkingTime":
                case "MaximumWorkingTime":
                {
                    CheckExpiration();
                    NotifyLeaveTimeUpdated();

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
                if (Properties.Settings.Default.LowPowerIsStart)
                {
                    startTime = DateTime.Now.Truncate(TimeSpan.FromMinutes(1)) - TimeSpan.FromMinutes((double)userSettings.ArrivalTimeOffset);
                    HandleStart();
                }
                else
                {
                    UpdateTotalAbsence();
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

        private void EodTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] End-of-day timer expired.");

            notifyTimer.Stop();
            periodicTimer.Stop();
            eodTimer.Stop();

            DialogResult result = MessageBox.Show(Properties.Resources.AskSessionAtMidnight,
                                                  Properties.Resources.MessageBoxCaption,
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

        private void NotifyAbsenceUpdated() => AbsenceUpdated?.Invoke(this, new EventArgs());
        private void NotifyWorkingTimeUpdated() => WorkingTimeUpdated?.Invoke(this, new EventArgs());
        private void NotifyLeaveTimeUpdated() => LeaveTimeUpdated?.Invoke(this, new EventArgs());

        private DateTime startTime;
        private Timer notifyTimer = null;
        private Timer periodicTimer = null;
        private Timer eodTimer = null;
        private Properties.Settings userSettings = null;
        private Session session = null;
        private BindingList<TimePeriod> absence;
        private TimeSpan totalAbsence;
    }
}
