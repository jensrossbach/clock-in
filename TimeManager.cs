using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;

namespace ClockIn
{
    class TimeManager
    {
        public event EventHandler AbsenceUpdated;
        public event EventHandler WorkingTimeUpdated;
        public event EventHandler LeaveTimeUpdated;

        private DateTime startTime;
        private Timer notifyTimer = null;
        private Timer periodicTimer = null;
        private Properties.Settings userSettings = null;
        private Session session = null;
        private BindingList<TimePeriod> absence;
        private TimeSpan totalAbsence;

        public enum WorkingLevel
        {
            RegularTime,
            OverTime,
            ApproachingMaxTime,
            MaxTimeViolation
        }

        public TimeManager()
        {
            userSettings = Properties.Settings.Default;
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

            // take time snapshot
            startTime = DateTime.Now - TimeSpan.FromMinutes((double)userSettings.ArrivalTimeOffset);

            HandleStart();
        }

        public BindingList<TimePeriod> Absence
        {
            get
            {
                return absence;
            }
        }

        public TimeSpan TotalAbsence
        {
            get
            {
                return totalAbsence;
            }
        }

        public void UpdateArrival(DateTime time)
        {
            DateTime cur = DateTime.Now;
            session.Arrival = new DateTime(cur.Year, cur.Month, cur.Day, time.Hour, time.Minute, 0);

            CalculateTotelAbsence();
            NotifyAbsenceUpdated(new EventArgs());

            CheckExpiration();
            session.Save();
        }

        public void UpdateAbsence()
        {
            CalculateTotelAbsence();
            StoreAbsenceInSession();

            NotifyAbsenceUpdated(new EventArgs());
        }

        public void UpdateWorkingTime()
        {
            CheckExpiration();
        }

        public void UpdateLeaveTime()
        {
            NotifyLeaveTimeUpdated(new EventArgs());
        }

        public void ContinueSession()
        {
            Debug.WriteLine("[TimeManager] Continue last session.");

            LoadAbsenceFromSession();
            CheckExpiration();
        }

        public void RestartSession(bool toCurTime)
        {
            Debug.WriteLine("[TimeManager] Restart session (" + (toCurTime ? "now" : "to start") + ").");

            session.Arrival = toCurTime ? DateTime.Now : startTime;
            session.NotifyLevel = 0;
            session.Absence = string.Empty;

            absence.Clear();

            CalculateTotelAbsence();
            NotifyAbsenceUpdated(new EventArgs());

            SetupTimers();
        }

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
            else if (workingTime >= (TimeSpan.FromHours((double)userSettings.MaximumWorkingTime) -
                                     TimeSpan.FromMinutes((double)userSettings.NotifyAdvance)))
            {
                level = WorkingLevel.ApproachingMaxTime;
            }
            else if (workingTime >= TimeSpan.FromHours((double)userSettings.RegularWorkingTime))
            {
                level = WorkingLevel.OverTime;
            }
            else
            {
                level = WorkingLevel.RegularTime;
            }

            return workingTime;
        }

        public TimeSpan GetCurrentRemainingWorkingTime()
        {
            bool overTime;
            DateTime leaveTime = GetCurrentLeaveTime(out overTime);
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
        }

        private void SetupTimers()
        {
            notifyTimer.Stop();

            if (session.NotifyLevel < 1)
            {
                int interval = (int)(CalculateWorkingTime((int)userSettings.RegularWorkingTime).Ticks / TimeSpan.TicksPerMillisecond);
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

        public void RestartMaxTimeTimer(int minutes)
        {
            if (minutes > 0)
            {
                session.NotifyLevel = 1;
                notifyTimer.Interval = minutes * 60 * 1000;
                notifyTimer.Start();
            }
        }

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
                NotifyRegularTimeLimit();
            }

            NotifyWorkingTimeUpdated(new EventArgs());
            SetupTimers();
        }

        private void NotifyRegularTimeLimit()
        {
            if (session.NotifyLevel < 1)
            {
                session.NotifyLevel = 1;

                NotificationDialog dlg = new NotificationDialog();
                dlg.Initialize(Properties.Resources.BigSmile, Properties.Resources.RegularTimeLimitReached, false);
                dlg.Show();
            }
        }

        private void NotifyMaximumTimeLimit(bool approaching)
        {
            if (session.NotifyLevel < 2)
            {
                session.NotifyLevel = 2;

                NotificationDialog dlg = new NotificationDialog();
                dlg.Initialize(approaching ? Properties.Resources.Ooooh : Properties.Resources.Sad, Properties.Resources.MaxmimumTimeLimitReached, approaching);
                dlg.Show();
            }
        }

        private DateTime CalculateLeaveTime(int clearWorkingTimeHours) => session.Arrival + TimeSpan.FromHours(clearWorkingTimeHours) + totalAbsence;
        private TimeSpan CalculateWorkingTime(int clearWorkingTimeHours) => CalculateLeaveTime(clearWorkingTimeHours) - DateTime.Now;

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

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] Power mode has changed:  MOD " + e.Mode);

            if (e.Mode == PowerModes.Resume)
            {
                startTime = DateTime.Now;
                if (Properties.Settings.Default.LowPowerIsStart)
                {
                    HandleStart();
                }
                else
                {
                    CalculateTotelAbsence();
                    NotifyAbsenceUpdated(new EventArgs());

                    CheckExpiration();
                }
            }
        }

        private void Absence_ListChanged(object sender, ListChangedEventArgs e)
        {
            Debug.WriteLine("[TimeManager] Absence list has changed.");

            UpdateAbsence();
            UpdateWorkingTime();
            UpdateLeaveTime();
        }

        private void NotifyTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] Notify timer expired.");
            notifyTimer.Stop();

            CheckExpiration();
        }

        private void PeriodicTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("[TimeManager] Periodic timer expired.");
            periodicTimer.Stop();

            CalculateTotelAbsence();
            UpdateWorkingTime();
            UpdateLeaveTime();
        }

        private void NotifyAbsenceUpdated(EventArgs e) => AbsenceUpdated?.Invoke(this, e);
        private void NotifyWorkingTimeUpdated(EventArgs e) => WorkingTimeUpdated?.Invoke(this, e);
        private void NotifyLeaveTimeUpdated(EventArgs e) => LeaveTimeUpdated?.Invoke(this, e);
    }
}
