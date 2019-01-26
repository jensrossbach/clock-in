// ClockIn
// Copyright (C) 2012-2019 Jens Rossbach, All Rights Reserved.


using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


namespace ClockIn
{
    public partial class MainWindow : Form
    {
        private enum WorkingTimeDisplay
        {
            ElapsedTime,
            RemainingTime
        }

        private enum WorkingStateAction
        {
            ClockIn,
            ClockOut,
            Toggle
        }


        private bool exit = false;

        private Hotkey hkShowMainWin = null;
        private Hotkey hkClockInOut = null;

        private Timer wtTimer = new Timer();
        private DateTime lastTrayTooltipUpdate = DateTime.Now;

        private TimeManager timeMgr = null;
        private HotkeyManager hotkeyMgr = null;
        private Properties.Settings settings = null;


        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public MainWindow()
        {
            timeMgr = Program.TimeMgr;
            hotkeyMgr = Program.HotkeyMgr;
            settings = Properties.Settings.Default;

            wtTimer.Tick += new EventHandler(WtTimer_Tick);

            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            timeMgr.AbsenceUpdated += TimeMgr_AbsenceUpdated;
            timeMgr.WorkingTimeUpdated += TimeMgr_WorkingTimeUpdated;
            timeMgr.LeaveTimeUpdated += TimeMgr_LeaveTimeUpdated;
            timeMgr.WorkingLevelUpdated += TimeMgr_WorkingLevelUpdated;
            timeMgr.WorkingStateUpdated += TimeMgr_WorkingStateUpdated;
            timeMgr.WorkingTimeAlert += TimeMgr_WorkingTimeAlert;

            InitializeComponent();
            lblLeaveTimeIcon.Image = Properties.Resources.Power;

            UpdateSystemTrayIcon(false);
            icnTrayIcon.Visible = true;

            settings.PropertyChanged += DefaultSettings_PropertyChanged;

            RegisterHotkey("MainWindowHotkey", settings.MainWindowHotkey);
            RegisterHotkey("ClockInOutHotkey", settings.ClockInOutHotkey);
        }


        /// <summary>
        ///   Registers a hotkey.
        /// </summary>
        /// <param name="hotkey">Name of hotkey (from settings) to register</param>
        /// <param name="key">Key combination to assign to the hotkey</param>
        /// <param name="showWarning">
        ///   true to show a warning notification in case of an error,
        ///   false to throw an exception instead
        /// </param>
        /// <exception cref="HotkeyRegisterException">
        ///   Thrown when an error occurs in case argument 'showWarning' is false.
        /// </exception>
        public void RegisterHotkey(string hotkey, Keys key, bool showWarning = true)
        {
            switch (hotkey)
            {
                case "MainWindowHotkey":
                {
                    RegisterHotkey(ref hkShowMainWin, key, HkShowMainWin_Press, showWarning);
                    break;
                }
                case "ClockInOutHotkey":
                {
                    RegisterHotkey(ref hkClockInOut, key, HkClockInOut_Press, showWarning);
                    break;
                }
            }
        }

        /// <summary>
        ///   Handles messages for the main window.
        /// </summary>
        /// <param name="m">Message to handle</param>
        protected override void WndProc(ref Message m)
        {
            if (!hotkeyMgr.ProcessMessage(ref m))
            {
                base.WndProc(ref m);
            }
        }

        /// <summary>
        ///   Updates the working time inside the window.
        /// </summary>
        private void UpdateWorkingTime()
        {
            wtTimer.Stop();

            if (timeMgr.WorkingState == WorkingState.Working)
            {
                TimeSpan elapsedTime = timeMgr.GetElapsedWorkingTime();

                switch (timeMgr.WorkingLevel)
                {
                    case WorkingLevel.RegularTime:
                    case WorkingLevel.AheadOfClosingTime:
                    {
                        lblWorkingTime.ForeColor = Color.Black;
                        lblIcon.Image = Properties.Resources.Confused;

                        break;
                    }
                    case WorkingLevel.OverTime:
                    {
                        lblWorkingTime.ForeColor = Color.DarkGreen;
                        lblIcon.Image = Properties.Resources.BigSmile;

                        break;
                    }
                    case WorkingLevel.ApproachingMaxTime:
                    {
                        lblWorkingTime.ForeColor = Color.Orange;
                        lblIcon.Image = Properties.Resources.Ooooh;

                        break;
                    }
                    case WorkingLevel.MaxTimeViolation:
                    {
                        lblWorkingTime.ForeColor = Color.Red;
                        lblIcon.Image = Properties.Resources.Sad;

                        break;
                    }
                    default:
                    {
                        // cannot happen
                        break;
                    }
                }

                WorkingTimeDisplay wtd = (WorkingTimeDisplay)System.Enum.Parse(typeof(WorkingTimeDisplay), settings.WorkingTimeDisplay);
                if (wtd == WorkingTimeDisplay.ElapsedTime)
                {
                    lblWorkingTimeIcon.Image = Properties.Resources.Stopwatch;
                    lblWorkingTime.Text = elapsedTime.ToString(@"hh\hmm\m");
                }
                else
                {
                    TimeSpan remainingTime = timeMgr.GetRemainingWorkingTime();
                    if (remainingTime.Seconds > 0)
                    {
                        remainingTime = new TimeSpan(remainingTime.Hours, remainingTime.Minutes + 1, 0);
                    }

                    lblWorkingTimeIcon.Image = Properties.Resources.Timer;
                    lblWorkingTime.Text = remainingTime.ToString(@"\-hh\hmm\m");
                }

                pnlTimeDisplay.BackColor = Color.White;

                wtTimer.Interval = GetInterval();
                wtTimer.Start();
            }
            else
            {
                lblWorkingTime.ForeColor = Color.Black;
                lblWorkingTime.Text = "--h--m";
                lblWorkingTimeIcon.Image = Properties.Resources.Timer;
                lblIcon.Image = Properties.Resources.Cool;
                pnlTimeDisplay.BackColor = Color.LightGoldenrodYellow;
            }
        }

        /// <summary>
        ///   Updates the leave time inside the window.
        /// </summary>
        private void UpdateLeaveTime()
        {
            if (timeMgr.WorkingState == WorkingState.Working)
            {
                string leaveTime = timeMgr.GetLeaveTime(out bool overTime).ToString(@"HH\:mm");

                if (overTime)
                {
                    lblLeaveTime.ForeColor = Color.Red;
                }
                else
                {
                    lblLeaveTime.ForeColor = Color.Black;
                }

                lblLeaveTime.Text = leaveTime;
            }
            else
            {
                lblLeaveTime.ForeColor = Color.Black;
                lblLeaveTime.Text = "--:--";
            }
        }

        /// <summary>
        ///   Updates the absence inside the window.
        /// </summary>
        private void UpdateAbsence()
        {
            TimeSpan absence = timeMgr.TotalAbsence;
            string absenceText = "";

            if (absence.Hours > 0)
            {
                absenceText += timeMgr.TotalAbsence.Hours.ToString("0") + "h ";
            }

            absenceText += timeMgr.TotalAbsence.Minutes.ToString("0") + "m";
            txtAbsence.Text = absenceText;
        }

        /// <summary>
        ///   Updates the system tray icon.
        /// </summary>
        /// <param name="reset">true if icon can be reset to default</param>
        private void UpdateSystemTrayIcon(bool reset)
        {
            OperatingSystem os = Environment.OSVersion;

            if ((settings.FlatIconOnNewWindows) &&
                ((os.Platform == PlatformID.Win32NT) && (((os.Version.Major == 6) && (os.Version.Minor >= 2)) || (os.Version.Major >= 10))))
            {
                if (timeMgr.WorkingState == WorkingState.Working)
                {
                    switch (timeMgr.WorkingLevel)
                    {
                        case WorkingLevel.RegularTime:
                        case WorkingLevel.AheadOfClosingTime:
                        {
                            icnTrayIcon.Icon = Properties.Resources.Modern;
                            break;
                        }
                        case WorkingLevel.OverTime:
                        {
                            icnTrayIcon.Icon = Properties.Resources.ModernGreen;
                            break;
                        }
                        case WorkingLevel.ApproachingMaxTime:
                        {
                            icnTrayIcon.Icon = Properties.Resources.ModernOrange;
                            break;
                        }
                        case WorkingLevel.MaxTimeViolation:
                        {
                            icnTrayIcon.Icon = Properties.Resources.ModernRed;
                            break;
                        }
                    }
                }
                else
                {
                    icnTrayIcon.Icon = Properties.Resources.ModernYellow;
                }
            }
            else if (reset)
            {
                if (timeMgr.WorkingState == WorkingState.Working)
                {
                    switch (timeMgr.WorkingLevel)
                    {
                        case WorkingLevel.RegularTime:
                        case WorkingLevel.AheadOfClosingTime:
                        {
                            icnTrayIcon.Icon = Properties.Resources.Classic;
                            break;
                        }
                        case WorkingLevel.OverTime:
                        {
                            icnTrayIcon.Icon = Properties.Resources.ClassicBigSmile;
                            break;
                        }
                        case WorkingLevel.ApproachingMaxTime:
                        {
                            icnTrayIcon.Icon = Properties.Resources.ClassicOoooh;
                            break;
                        }
                        case WorkingLevel.MaxTimeViolation:
                        {
                            icnTrayIcon.Icon = Properties.Resources.ClassicSad;
                            break;
                        }
                    }
                }
                else
                {
                    icnTrayIcon.Icon = Properties.Resources.ClassicCool;
                }
            }
        }

        private void UpdateSystemTrayIconTooltip()
        {
            if (timeMgr.WorkingState == WorkingState.Working)
            {
                string leaveTime = timeMgr.GetLeaveTime(out bool overTime).ToString(@"HH\:mm");

                if (overTime)
                {
                    icnTrayIcon.Text = string.Format(Properties.Resources.TooltipTextOvertime, leaveTime);
                }
                else
                {
                    icnTrayIcon.Text = string.Format(Properties.Resources.TooltipText, leaveTime);
                }
            }
            else
            {
                icnTrayIcon.Text = string.Format(Properties.Resources.TooltipTextAbsent, timeMgr.ClockOutTime.ToString(@"HH\:mm"));
            }
        }

        /// <summary>
        ///   Calculates the interval until next full minute.
        /// </summary>
        private int GetInterval()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000 - now.Millisecond);
        }

        /// <summary>
        ///   Switches the working time display between elapsed and remaining time.
        /// </summary>
        private void SwitchWorkingTimeDisplay()
        {
            WorkingTimeDisplay wtd = (WorkingTimeDisplay)System.Enum.Parse(typeof(WorkingTimeDisplay), settings.WorkingTimeDisplay);

            if (wtd == WorkingTimeDisplay.ElapsedTime)
            {
                wtd = WorkingTimeDisplay.RemainingTime;
            }
            else
            {
                wtd = WorkingTimeDisplay.ElapsedTime;
            }

            settings.WorkingTimeDisplay = Enum.Format(typeof(WorkingTimeDisplay), wtd, "G");

            UpdateWorkingTime();
            UpdateLeaveTime();

            UpdateSystemTrayIcon(true);
            UpdateSystemTrayIconTooltip();
        }

        /// <summary>
        ///   Minimizes the main window to the system tray.
        /// </summary>
        private void Minimize()
        {
            Visible = false;
        }

        /// <summary>
        ///   Restores the main window from system tray.
        /// </summary>
        public void Restore()
        {
            Visible = true;
            Activate();
        }

        /// <summary>
        ///   Switches the working state.
        /// </summary>
        /// <param name="action">Switch action to perform</param>
        private void SwitchWorkingState(WorkingStateAction action)
        {
            if ((action == WorkingStateAction.ClockOut) ||
                ((action == WorkingStateAction.Toggle) && (timeMgr.WorkingState == WorkingState.Working)))
            {
                if (Visible && settings.MinimizeOnClockOut)
                {
                    Minimize();
                }

                timeMgr.WorkingState = WorkingState.Absent;
            }
            else if ((action == WorkingStateAction.ClockIn) ||
                     ((action == WorkingStateAction.Toggle) && (timeMgr.WorkingState == WorkingState.Absent)))
            {
                timeMgr.WorkingState = WorkingState.Working;
            }
        }

        /// <summary>
        ///   Registers or reregisters a hotkey.
        /// </summary>
        /// <param name="hotkey">Hotkey to register or reregister (will be newly assigned when null)</param>
        /// <param name="key">Key combination to assign to the hotkey</param>
        /// <param name="handler">Event handler for handling hotkey presses (only needed when registering new hotkey)</param>
        /// <param name="showWarning">
        ///   true to show a warning notification in case of an error,
        ///   false to throw an exception instead
        /// </param>
        /// <exception cref="ArgumentException">
        ///   Thrown when argument 'handler' is null in case argument 'hotkey' is not null.
        /// </exception>
        /// <exception cref="HotkeyRegisterException">
        ///   Thrown when an error occurs in case argument 'showWarning' is false.
        /// </exception>
        private void RegisterHotkey(ref Hotkey hotkey, Keys key, HandledEventHandler handler, bool showWarning)
        {
            try
            {
                if (hotkey == null)
                {
                    if (handler == null)
                    {
                        throw new ArgumentException("Event handler is required when registering new hotkey", "handler");
                    }

                    hotkey = hotkeyMgr.RegisterHotkey(key, this);
                    hotkey.Press += handler;
                }
                else
                {
                    hotkeyMgr.ReregisterHotkey(hotkey, key, this);
                }
            }
            catch (HotkeyRegisterException e) when (showWarning)
            {
                icnTrayIcon.ShowBalloonTip(5000, "ClockIn", e.Message, ToolTipIcon.Warning);
            }
        }

        /// <summary>
        ///   Unregisters all hotkeys.
        /// </summary>
        private void UnregisterHotkeys()
        {
            hotkeyMgr.UnregisterHotkey(hkShowMainWin);
            hotkeyMgr.UnregisterHotkey(hkClockInOut);
        }

        /// <summary>
        ///   Handles the event when the window is loaded.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Location = settings.MainWindowLocation;
        }

        /// <summary>
        ///   Handles the event when the visibility of the window has changed.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateAbsence();
                UpdateWorkingTime();
                UpdateLeaveTime();
            }
            else
            {
                wtTimer.Stop();
            }
        }

        /// <summary>
        ///   Handles the event when the window is about to be closed.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                Minimize();
                e.Cancel = true;
            }
            else
            {
                if (WindowState == FormWindowState.Normal)
                {
                    settings.MainWindowLocation = Location;
                }
                else
                {
                    settings.MainWindowLocation = RestoreBounds.Location;
                }
            }
        }

        /// <summary>
        ///   Handles the event when the window has been closed.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            wtTimer.Stop();
            settings.Save();
            UnregisterHotkeys();
        }

        /// <summary>
        ///   Handles the event when the arrival time text box has validated the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void DtpArrival_Validated(object sender, EventArgs e)
        {
            Session.Default.NotifyPropertyValidated("Arrival");
        }

        /// <summary>
        ///   Handles a double click on the arrival time label.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void LblBegin_DoubleClick(object sender, EventArgs e)
        {
            timeMgr.RestartSession(true, false);
        }

        /// <summary>
        ///   Handles a click on the working time icon.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void LblWorkingTimeIcon_Click(object sender, EventArgs e)
        {
            SwitchWorkingTimeDisplay();
        }

        /// <summary>
        ///   Handles a click on the working time text.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void LblWorkingTime_Click(object sender, EventArgs e)
        {
            SwitchWorkingTimeDisplay();
        }

        /// <summary>
        ///   Handles a click on the leave time icon.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void LblLeaveTimeIcon_Click(object sender, EventArgs e)
        {
            Session.Default.NotifyPropertyValidated("Arrival");
        }

        /// <summary>
        ///   Handles a click on the leave time text.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void LblLeaveTime_Click(object sender, EventArgs e)
        {
            Session.Default.NotifyPropertyValidated("Arrival");
        }

        /// <summary>
        ///   Handles a click on the reset time button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnResetTime_Click(object sender, EventArgs e)
        {
            timeMgr.RestartSession(true, false);
        }

        /// <summary>
        ///   Handles a click on the absence button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnAbsence_Click(object sender, EventArgs e)
        {
            new AbsenceDialog().ShowDialog(this);
        }

        /// <summary>
        ///   Handles a click on the clock in/out button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnClockInOut_Click(object sender, EventArgs e)
        {
            SwitchWorkingState(WorkingStateAction.Toggle);
        }

        /// <summary>
        ///   Handles a click on the about button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            object[] attribs = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

            string copyright = "";
            if (attribs.Length > 0)
            {
                copyright = ((AssemblyCopyrightAttribute)attribs[0]).Copyright;
            }

            string text = string.Format(Properties.Resources.AboutText, Assembly.GetExecutingAssembly().GetName().Version.ToString(), copyright);
            MessageBox.Show(text, Properties.Resources.AboutCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///   Handles a click on the options button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnOptions_Click(object sender, EventArgs e)
        {
            using (OptionsDialog dialog = new OptionsDialog(this))
            {
                dialog.ShowDialog(this);
            }
        }

        /// <summary>
        ///   Handles a click on the close button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Minimize();
        }

        /// <summary>
        ///   Handles a double click on the system tray icon.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void IcnTray_DoubleClick(object sender, EventArgs e)
        {
            Restore();
        }

        /// <summary>
        ///   Handles a click on the restore item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmRestore_Click(object sender, EventArgs e)
        {
            Restore();
        }

        /// <summary>
        ///   Handles a click on the options item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmOptions_Click(object sender, EventArgs e)
        {
            using (OptionsDialog dialog = new OptionsDialog(this))
            {
                dialog.ShowDialog(this);
            }
        }

        /// <summary>
        ///   Handles a click on the clock-in item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmClockIn_Click(object sender, EventArgs e)
        {
            SwitchWorkingState(WorkingStateAction.ClockIn);
        }

        /// <summary>
        ///   Handles a click on the clock-out item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmClockOut_Click(object sender, EventArgs e)
        {
            SwitchWorkingState(WorkingStateAction.ClockOut);
        }

        /// <summary>
        ///   Handles a click on the exit item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmExit_Click(object sender, EventArgs e)
        {
            exit = true;

            Close();
            Application.ExitThread();
        }

        /// <summary>
        ///   Handles the expiration of the working time update timer.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void WtTimer_Tick(object sender, EventArgs e)
        {
            UpdateWorkingTime();
        }

        /// <summary>
        ///   Handles session switch events.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if ((e.Reason == SessionSwitchReason.SessionUnlock) &&
                (timeMgr.WorkingState == WorkingState.Absent) &&
                settings.ClockInAtUnlock)
            {
                if (settings.AskClockInAtUnlock)
                {
                    DialogResult result = MessageBox.Show(Properties.Resources.AskWorkingStateOnWinUnlock,
                                                          Properties.Resources.WindowCaption,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        SwitchWorkingState(WorkingStateAction.ClockIn);
                    }
                }
                else
                {
                    SwitchWorkingState(WorkingStateAction.ClockIn);
                }
            }
        }

        /// <summary>
        ///   Handles an update of the absence.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TimeMgr_AbsenceUpdated(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateAbsence();
            }
        }

        /// <summary>
        ///   Handles an update of the working time.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TimeMgr_WorkingTimeUpdated(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateWorkingTime();
            }
        }

        /// <summary>
        ///   Handles an update of the leave time.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TimeMgr_LeaveTimeUpdated(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateLeaveTime();
            }

            UpdateSystemTrayIconTooltip();
        }

        /// <summary>
        ///   Handles an update of the working level.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TimeMgr_WorkingLevelUpdated(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateLeaveTime();
            }

            UpdateSystemTrayIcon(true);
            UpdateSystemTrayIconTooltip();
        }

        /// <summary>
        ///   Handles an update of the working state.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TimeMgr_WorkingStateUpdated(object sender, WorkingStateUpdatedEventArgs e)
        {
            switch (e.WorkingStateUpdate)
            {
                case WorkingStateUpdate.ClockIn:
                {
                    if (settings.NotifyOnClockInOut)
                    {
                        icnTrayIcon.ShowBalloonTip(5000, "ClockIn", Properties.Resources.ClockInNotification, ToolTipIcon.None);
                    }

                    break;
                }
                case WorkingStateUpdate.ClockOut:
                {
                    if (settings.NotifyOnClockInOut)
                    {
                        icnTrayIcon.ShowBalloonTip(5000, "ClockIn", Properties.Resources.ClockOutNotification, ToolTipIcon.None);
                    }

                    break;
                }
                case WorkingStateUpdate.Error:
                {
                    icnTrayIcon.ShowBalloonTip(5000, "ClockIn", Properties.Resources.OverlappingAbsencePeriod, ToolTipIcon.Error);
                    break;
                }
            }

            if (timeMgr.WorkingState == WorkingState.Working)
            {
                Text = Properties.Resources.WindowCaption;

                btnClockInOut.Text = Properties.Resources.ClockOut;
                itmClockIn.Enabled = false;
                itmClockOut.Enabled = true;
            }
            else
            {
                Text = Properties.Resources.WindowCaptionAbsent;

                btnClockInOut.Text = Properties.Resources.ClockIn;
                itmClockIn.Enabled = true;
                itmClockOut.Enabled = false;
            }

            if (Visible)
            {
                UpdateAbsence();
                UpdateWorkingTime();
                UpdateLeaveTime();
            }

            UpdateSystemTrayIcon(true);
            UpdateSystemTrayIconTooltip();
        }

        /// <summary>
        ///   Handles a working time alert.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TimeMgr_WorkingTimeAlert(object sender, WorkingTimeAlertEventArgs e)
        {
            Image icon = null;
            string message = null;

            switch (e.WorkingLevel)
            {
                case WorkingLevel.AheadOfClosingTime:
                {
                    icon = Properties.Resources.BigSmile;
                    message = string.Format(Properties.Resources.AheadOfRegularTimeLimit, e.AheadTime);

                    break;
                }
                case WorkingLevel.OverTime:
                {
                    icon = Properties.Resources.BigSmile;
                    message = Properties.Resources.RegularTimeLimitReached;

                    break;
                }
                case WorkingLevel.ApproachingMaxTime:
                {
                    icon = Properties.Resources.Ooooh;
                    message = string.Format(Properties.Resources.ApproachingMaximumTimeLimit, e.AheadTime);

                    break;
                }
                case WorkingLevel.MaxTimeViolation:
                {
                    icon = Properties.Resources.Sad;
                    message = Properties.Resources.MaxmimumTimeLimitReached;

                    break;
                }
            }

            if (settings.SystemNotifications)
            {
                icnTrayIcon.ShowBalloonTip(5000, "ClockIn", message, ToolTipIcon.None);
            }
            else
            {
                new NotificationDialog(icon, message, e.WorkingLevel == WorkingLevel.MaxTimeViolation).Show();
            }
        }

        /// <summary>
        ///   Handles the change of a user setting.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void DefaultSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "DisplayMaximumTime":
                {
                    if (Visible)
                    {
                        UpdateWorkingTime();
                        UpdateLeaveTime();
                    }

                    UpdateSystemTrayIconTooltip();
                    break;
                }
                case "FlatIconOnNewWindows":
                {
                    UpdateSystemTrayIcon(true);
                    break;
                }
            }
        }

        /// <summary>
        ///   Handles the key press of the show main window hotkey.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void HkShowMainWin_Press(object sender, HandledEventArgs e)
        {
            Debug.WriteLine("[MainWindow] Hotkey for showing main window pressed.");

            Restore();
            e.Handled = true;
        }

        /// <summary>
        ///   Handles the key press of the clock in/out hotkey.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void HkClockInOut_Press(object sender, HandledEventArgs e)
        {
            Debug.WriteLine("[MainWindow] Hotkey for clocking in/out pressed.");
            SwitchWorkingState(WorkingStateAction.Toggle);
        }
    }
}
