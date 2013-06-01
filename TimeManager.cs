using System;
using System.Windows.Forms;
using Microsoft.Win32;


namespace ClockIn
{
    class TimeManager
    {
        public TimeManager()
        {
            userSettings = Properties.Settings.Default;
            session = Session.Default;
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            notifyTimer = new Timer();
            notifyTimer.Tick += new EventHandler(rwtTimer_Tick);

            // take time snapshot
            startTime = DateTime.Now;

            handleStart();
        }

        public void updateArrival(DateTime time)
        {
            DateTime cur = DateTime.Now;
            session.Arrival = new DateTime(cur.Year, cur.Month, cur.Day, time.Hour, time.Minute, 0);

            checkExpiration();
            session.Save();
        }

        public void updateBreaks()
        {
            checkExpiration();
            session.Save();
        }

        public void updateWorkingTime()
        {
            checkExpiration();
        }

        public TimeSpan getCurrentWorkingTime()
        {
            DateTime cur = DateTime.Now;

            TimeSpan workingTime = cur - session.Arrival;
            TimeSpan chargeableBreak = calculateChargeableBreak(session.Arrival, cur);

            if (chargeableBreak >= workingTime)
            {
                workingTime = TimeSpan.Zero;
            }
            else
            {
                workingTime -= chargeableBreak;
            }

            return workingTime;
        }

        private void handleStart()
        {
            if (session.Arrival.Date == startTime.Date)
            {
                if (userSettings.NewSessionOnStartup)
                {
                    restartSession();
                }
                else if (userSettings.AskSessionOnStartup)
                {
                    DialogResult result = MessageBox.Show(Properties.Resources.AskSessionOnStartup,
                                                          Properties.Resources.MessageBoxCaption,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        restartSession();
                    }
                    else
                    {
                        checkExpiration();
                    }
                }
                else
                {
                    checkExpiration();
                }
            }
            else
            {
                restartSession();
            }

            session.Save();
        }

        private void restartSession()
        {
            session.Arrival = startTime;
            session.Break = userSettings.Break;
            session.NotifyLevel = 0;

            setupTimers();
        }

        private void setupTimers()
        {
            notifyTimer.Stop();

            if (session.NotifyLevel < 1)
            {
                notifyTimer.Interval = (int)(calculateWorkingTime((int)userSettings.RegularWorkingTime).Ticks / TimeSpan.TicksPerMillisecond);
                notifyTimer.Start();
            }
            else if (session.NotifyLevel < 2)
            {
                TimeSpan workingTime = calculateWorkingTime((int)userSettings.MaximumWorkingTime) - new TimeSpan(0, (int)userSettings.NotifyAdvance, 0);
                notifyTimer.Interval = (int)(workingTime.Ticks / TimeSpan.TicksPerMillisecond);
                notifyTimer.Start();
            }
        }

        public void restartMaxTimeTimer(int minutes)
        {
            session.NotifyLevel = 1;
            notifyTimer.Interval = minutes * 60 * 1000;
            notifyTimer.Start();
        }

        private void checkExpiration()
        {
            TimeSpan workingTime = getCurrentWorkingTime();

            if (workingTime >= new TimeSpan((int)userSettings.MaximumWorkingTime, 0, 0))
            {
                notifyMaximumTimeLimit(false);
            }
            else if (workingTime >= new TimeSpan((int)userSettings.MaximumWorkingTime, -(int)userSettings.NotifyAdvance, 0))
            {
                notifyMaximumTimeLimit(true);
            }
            else if (workingTime >= new TimeSpan((int)userSettings.RegularWorkingTime, 0, 0))
            {
                notifyRegularTimeLimit();
            }

            onWorkingTimeUpdated(new EventArgs());
            setupTimers();
        }

        private void notifyRegularTimeLimit()
        {
            if (session.NotifyLevel < 1)
            {
                session.NotifyLevel = 1;

                NotificationDialog dlg = new NotificationDialog();
                dlg.initialize(1, Properties.Resources.RegularTimeLimitReached, false);
                dlg.Show();
            }
        }

        private void notifyMaximumTimeLimit(bool approaching)
        {
            if (session.NotifyLevel < 2)
            {
                session.NotifyLevel = 2;

                NotificationDialog dlg = new NotificationDialog();
                dlg.initialize(approaching ? 2 : 3, Properties.Resources.MaxmimumTimeLimitReached, approaching);
                dlg.Show();
            }
        }

        private TimeSpan calculateChargeableBreak(DateTime beginTime, DateTime endTime)
        {
            if ((endTime.TimeOfDay < userSettings.BreaksBegin.TimeOfDay) ||
                (beginTime.TimeOfDay > userSettings.BreaksEnd.TimeOfDay))
            {
                // working time completey before or behind break period
                return TimeSpan.Zero;
            }
            else
            {
                TimeSpan breakSpan = new TimeSpan(0, (int)session.Break, 0);

                if (beginTime.TimeOfDay < userSettings.BreaksBegin.TimeOfDay)
                {
                    TimeSpan sinceBreaksBegin = endTime.TimeOfDay - userSettings.BreaksBegin.TimeOfDay;
                    Console.Out.WriteLine("calculateChargeableBreak: bS=" + breakSpan.ToString() + ", sBB=" + sinceBreaksBegin.ToString());
                    return (sinceBreaksBegin > breakSpan) ? breakSpan : sinceBreaksBegin;
                }
                else
                {
                    TimeSpan tillBreaksEnd = userSettings.BreaksEnd.TimeOfDay - beginTime.TimeOfDay;
                    Console.Out.WriteLine("calculateChargeableBreak: bS=" + breakSpan.ToString() + ", tBE=" + tillBreaksEnd.ToString());
                    return (tillBreaksEnd > breakSpan) ? breakSpan : tillBreaksEnd;
                }
            }
        }

        private TimeSpan calculateWorkingTime(int clearWorkingTimeHours)
        {
            TimeSpan clearWorkingTime = new TimeSpan(clearWorkingTimeHours, 0, 0);
            DateTime endTime = session.Arrival + clearWorkingTime;
            TimeSpan sessionBreak = new TimeSpan(0, (int)session.Break, 0);

            if ((session.Arrival.TimeOfDay < userSettings.BreaksBegin.TimeOfDay) && (endTime.TimeOfDay > userSettings.BreaksBegin.TimeOfDay))
            {
                endTime += sessionBreak;
            }
            else if ((session.Arrival.TimeOfDay >= userSettings.BreaksBegin.TimeOfDay) && (session.Arrival.TimeOfDay < userSettings.BreaksEnd.TimeOfDay))
            {
                TimeSpan remainingBreak = userSettings.BreaksEnd.TimeOfDay - session.Arrival.TimeOfDay;
                endTime += (remainingBreak < sessionBreak) ? remainingBreak  : sessionBreak;
            }
            Console.Out.WriteLine("calculateWorkingTime: end=" + endTime.ToString() + "(cWTH=" + clearWorkingTimeHours + ")");

            return endTime - DateTime.Now;
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {
                startTime = DateTime.Now;
                if (Properties.Settings.Default.LowPowerIsStart)
                {
                    handleStart();
                }
                else
                {
                    checkExpiration();
                }
            }
        }

        private void rwtTimer_Tick(object sender, EventArgs e)
        {
            notifyTimer.Stop();
            checkExpiration();
        }

        private void onWorkingTimeUpdated(EventArgs e)
        {
            if (WorkingTimeUpdated != null)
            {
                WorkingTimeUpdated(this, e);
            }
        }

        public event EventHandler WorkingTimeUpdated;

        private DateTime startTime;
        private Timer notifyTimer = null;
        private Properties.Settings userSettings = null;
        private Session session = null;
    }
}
