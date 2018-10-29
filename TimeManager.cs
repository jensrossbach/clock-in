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
            userSettings = Properties.Settings.Default;

            // take time snapshot
            startTime = DateTime.Now - TimeSpan.FromMinutes((double)userSettings.ArrivalTimeOffset);

            session = Session.Default;
            absence = new BindingList<TimePeriod>();
            totalAbsence = TimeSpan.Zero;

            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            absence.ListChanged += Absence_ListChanged;

            notifyTimer = new Timer();
            notifyTimer.Tick += new EventHandler(NotifyTimer_Tick);

            periodicTimer = new Timer();
            periodicTimer.Tick += new EventHandler(PeriodicTimer_Tick);
            periodicTimer.Interval = 60000;

            eodTimer = new Timer();
            eodTimer.Tick += EodTimer_Tick;

            HandleStart();
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
        ///   Updates the arrival time.
        ///   This also recalculates time values and restarts timers.
        /// </summary>
        /// <param name="time">New arrival time</param>
        public void UpdateArrival(DateTime time)
        {
            DateTime cur = DateTime.Now;
            session.Arrival = new DateTime(cur.Year, cur.Month, cur.Day, time.Hour, time.Minute, 0);

            CalculateTotelAbsence();
            NotifyAbsenceUpdated(new EventArgs());

            CheckExpiration();
            session.Save();
        }

        /// <summary>
        ///   Recalculates the total absence.
        /// </summary>
        public void UpdateAbsence()
        {
            CalculateTotelAbsence();
            StoreAbsenceInSession();

            NotifyAbsenceUpdated(new EventArgs());
        }

        /// <summary>
        ///   Updates the working time.
        /// </summary>
        public void UpdateWorkingTime()
        {
            CheckExpiration();
        }

        /// <summary>
        ///   Updates the leave time.
        /// </summary>
        public void UpdateLeaveTime()
        {
            NotifyLeaveTimeUpdated(new EventArgs());
        }

        /// <summary>
        ///   Continues last session earlier from the day.
        /// </summary>
        public void ContinueSession()
        {
            Debug.WriteLine("[TimeManager] Continue last session.");

            LoadAbsenceFromSession();
            CheckExpiration();
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

            session.Arrival = toCurTime ? DateTime.Now : startTime;
            session.NotifyLevel = 0;
            session.Absence = string.Empty;

            absence.Clear();

            CalculateTotelAbsence();
            NotifyAbsenceUpdated(new EventArgs());

            SetupNotificationTimer();
        }

        /// <summary>
        ///   Calculates the elapsed working time.
        /// </summary>
        /// <param name="level">Working level which has been reached</param>
        /// <returns>Elapsed working time</returns>
        public TimeSpan GetCurrentElapsedWorkingTime(out WorkingLevel level)
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
        ///   Returns the current remaining working time.
        /// </summary>
        /// <returns>Remaining working time</returns>
        public TimeSpan GetCurrentRemainingWorkingTime()
        {
            DateTime leaveTime = GetCurrentLeaveTime(out bool overTime);
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
        ///   Retuens the current leave time.
        /// </summary>
        /// <param name="level">
        ///     true if regular working time has been reached, false otherwise
        /// </param>
        /// <returns>Leave time</returns>
        public DateTime GetCurrentLeaveTime(out bool overTime)
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
        ///   Handles application start.
        /// </summary>
        private void HandleStart()
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

            session.Save();
            SetupEoDTimer();
        }

        /// <summary>
        ///   Configures and starts the notification timer.
        /// </summary>
        private void SetupNotificationTimer()
        {
            notifyTimer.Stop();

            if (session.NotifyLevel < 1)
            {
                TimeSpan workingTime = CalculateWorkingTime((int)userSettings.RegularWorkingTime) - new TimeSpan(0, (int)userSettings.NotifyRegAdvance, 0);
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
                TimeSpan workingTime = CalculateWorkingTime((int)userSettings.MaximumWorkingTime) - new TimeSpan(0, (int)userSettings.NotifyAdvance, 0);
                int interval = (int)(workingTime.Ticks / TimeSpan.TicksPerMillisecond);
                if (interval > 0)
                {
                    notifyTimer.Interval = interval;
                    notifyTimer.Start();

                    Debug.WriteLine("[TimeManager] Notify timer started at level " + session.NotifyLevel + " (" + interval + " ms).");
                }
            }
        }

        /// <summary>
        ///   Configures and starts the end-of-day timer.
        /// </summary>
        void SetupEoDTimer()
        {
            eodTimer.Stop();
            eodTimer.Interval = (int)(DateTime.Today.AddDays(1.0) - DateTime.Now).TotalMilliseconds;
            eodTimer.Start();

            Debug.WriteLine("[TimeManager] End-of-day timer started (" + eodTimer.Interval + " ms).");
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
                notifyTimer.Interval = minutes * 60 * 1000;
                notifyTimer.Start();
            }
        }

        /// <summary>
        ///   Checks if any time limit has been reached and notifies the user.
        /// </summary>
        private void CheckExpiration()
        {
            TimeSpan workingTime = GetCurrentElapsedWorkingTime(out WorkingLevel level);

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

            NotifyWorkingTimeUpdated(new EventArgs());
            SetupNotificationTimer();
        }

        /// <summary>
        ///   Notifies that regular working time has been reached.
        /// </summary>
        private void NotifyRegularTimeLimit(bool ahead)
        {
            if (session.NotifyLevel < 1)
            {
                session.NotifyLevel = 1;

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
        ///   Calculates the working time.
        /// </summary>
        /// <param name="clearWorkingTimeHours">Number of hours to work</param>
        /// <returns>Working time</returns>
        private TimeSpan CalculateWorkingTime(int clearWorkingTimeHours) => CalculateLeaveTime(clearWorkingTimeHours) - DateTime.Now;

        /// <summary>
        ///   Calculates the total absence time span considering chargeable breaks.
        /// </summary>
        private void CalculateTotelAbsence()
        {
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

                periodicTimer.Stop();
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

            CalculateTotelAbsence();
            NotifyAbsenceUpdated(new EventArgs());
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
                    startTime = DateTime.Now;
                    HandleStart();
                }
                else
                {
                    CalculateTotelAbsence();
                    NotifyAbsenceUpdated(new EventArgs());

                    CheckExpiration();
                    SetupEoDTimer();
                }
            }
        }

        /// <summary>
        ///   Handles absence list change events.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void Absence_ListChanged(object sender, ListChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] Absence list has changed.");

            UpdateAbsence();
            UpdateWorkingTime();
            UpdateLeaveTime();
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

            CalculateTotelAbsence();
            UpdateWorkingTime();
            UpdateLeaveTime();
        }

        private void EodTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] End-of-day timer expired.");
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
                CheckExpiration();
            }

            SetupEoDTimer();
        }

        private void NotifyAbsenceUpdated(EventArgs e) => AbsenceUpdated?.Invoke(this, e);
        private void NotifyWorkingTimeUpdated(EventArgs e) => WorkingTimeUpdated?.Invoke(this, e);
        private void NotifyLeaveTimeUpdated(EventArgs e) => LeaveTimeUpdated?.Invoke(this, e);

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
