// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


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
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public MainWindow()
        {
            wtTimer.Tick += new EventHandler(WtTimer_Tick);

            Program.TimeMgr.AbsenceUpdated += TimeMgr_AbsenceUpdated;
            Program.TimeMgr.WorkingTimeUpdated += TimeMgr_WorkingTimeUpdated;
            Program.TimeMgr.LeaveTimeUpdated += TimeMgr_LeaveTimeUpdated;
            Program.TimeMgr.WorkingStateUpdated += TimeMgr_WorkingStateUpdated;

            InitializeComponent();
            lblLeaveTimeIcon.Image = Properties.Resources.Power;

            UpdateSystemTrayIcon(false);
            icnTrayIcon.Visible = true;

            Properties.Settings.Default.PropertyChanged += DefaultSettings_PropertyChanged;
        }

        /// <summary>
        ///   Updates the working time inside the window.
        /// </summary>
        public void UpdateWorkingTime()
        {
            wtTimer.Stop();

            if (Program.TimeMgr.State == TimeManager.WorkingState.Working)
            {
                TimeSpan elapsedTime = Program.TimeMgr.GetElapsedWorkingTime(out TimeManager.WorkingLevel level);

                switch (level)
                {
                    case TimeManager.WorkingLevel.RegularTime:
                    case TimeManager.WorkingLevel.AheadOfClosingTime:
                    {
                        lblWorkingTime.ForeColor = Color.Black;
                        lblIcon.Image = Properties.Resources.Confused;

                        break;
                    }
                    case TimeManager.WorkingLevel.OverTime:
                    {
                        lblWorkingTime.ForeColor = Color.DarkGreen;
                        lblIcon.Image = Properties.Resources.BigSmile;

                        break;
                    }
                    case TimeManager.WorkingLevel.ApproachingMaxTime:
                    {
                        lblWorkingTime.ForeColor = Color.Orange;
                        lblIcon.Image = Properties.Resources.Ooooh;

                        break;
                    }
                    case TimeManager.WorkingLevel.MaxTimeViolation:
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

                WorkingTimeDisplay wtd = (WorkingTimeDisplay)System.Enum.Parse(typeof(WorkingTimeDisplay), Properties.Settings.Default.WorkingTimeDisplay);
                if (wtd == WorkingTimeDisplay.ElapsedTime)
                {
                    lblWorkingTimeIcon.Image = Properties.Resources.Stopwatch;
                    lblWorkingTime.Text = elapsedTime.ToString(@"hh\hmm\m");
                }
                else
                {
                    TimeSpan remainingTime = Program.TimeMgr.GetRemainingWorkingTime();
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
        /// <param name="updateLabel">true if label should be updated</param>
        public void UpdateLeaveTime(bool updateLabel)
        {
            if (Program.TimeMgr.State == TimeManager.WorkingState.Working)
            {
                string leaveTime = Program.TimeMgr.GetLeaveTime(out bool overTime).ToString(@"HH\:mm");

                if (updateLabel)
                {
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

                icnTrayIcon.Text = string.Format(Properties.Resources.TooltipText, leaveTime);
            }
            else
            {
                if (updateLabel)
                {
                    lblLeaveTime.ForeColor = Color.Black;
                    lblLeaveTime.Text = "--:--";
                }

                icnTrayIcon.Text = string.Format(Properties.Resources.TooltipTextAbsent, Program.TimeMgr.ClockOutTime.ToString(@"HH\:mm"));
            }
        }

        /// <summary>
        ///   Updates the absence inside the window.
        /// </summary>
        private void UpdateAbsence()
        {
            TimeSpan absence = Program.TimeMgr.TotalAbsence;
            string absenceText = "";

            if (absence.Hours > 0)
            {
                absenceText += Program.TimeMgr.TotalAbsence.Hours.ToString("0") + "h ";
            }

            absenceText += Program.TimeMgr.TotalAbsence.Minutes.ToString("0") + "m";
            txtAbsence.Text = absenceText;
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
            WorkingTimeDisplay wtd = (WorkingTimeDisplay)System.Enum.Parse(typeof(WorkingTimeDisplay), Properties.Settings.Default.WorkingTimeDisplay);

            if (wtd == WorkingTimeDisplay.ElapsedTime)
            {
                wtd = WorkingTimeDisplay.RemainingTime;
            }
            else
            {
                wtd = WorkingTimeDisplay.ElapsedTime;
            }

            Properties.Settings.Default.WorkingTimeDisplay = Enum.Format(typeof(WorkingTimeDisplay), wtd, "G");
            UpdateWorkingTime();
            UpdateLeaveTime(true);
        }

        /// <summary>
        ///   Minimizes the main window to the system tray.
        /// </summary>
        private void MinimizeMainWindow()
        {
            WindowState = FormWindowState.Minimized;
            Visible = false;
        }

        /// <summary>
        ///   Restores the main window from system tray.
        /// </summary>
        private void RestoreMainWindow()
        {
            Visible = true;
            WindowState = FormWindowState.Normal;

            Activate();
        }

        /// <summary>
        ///   Updates the system tray icon.
        /// </summary>
        /// <param name="reset">true if icon can be reset to default</param>
        private void UpdateSystemTrayIcon(bool reset)
        {
            OperatingSystem os = Environment.OSVersion;

            if ((Properties.Settings.Default.FlatIconOnNewWindows) &&
                ((os.Platform == PlatformID.Win32NT) && (((os.Version.Major == 6) && (os.Version.Minor >= 2)) || (os.Version.Major >= 10))))
            {
                icnTrayIcon.Icon = Properties.Resources.FlatTrayIcon;
            }
            else if (reset)
            {
                icnTrayIcon.Icon = Icon;
            }
        }

        /// <summary>
        ///   Registers all hotkeys.
        /// </summary>
        private void RegisterHotkeys()
        {
            hkShowMainWin = Program.HotkeyMgr.RegisterHotkey(Properties.Settings.Default.MainWindowHotkey, this);
            if (hkShowMainWin != null)
            {
                hkShowMainWin.Pressed += HkShowMainWin_Pressed;
            }
        }

        /// <summary>
        ///   Unregisters all hotkeys.
        /// </summary>
        private void UnregisterHotkeys()
        {
            Program.HotkeyMgr.UnregisterHotkey(hkShowMainWin);
        }

        /// <summary>
        ///   Handles the event when the window is loaded.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            RegisterHotkeys();
        }

        /// <summary>
        ///   Handles the event when the window has been moved.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainWindowLocation = Location;
            }
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
                UpdateLeaveTime(true);
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
                MinimizeMainWindow();
                e.Cancel = true;
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
            Properties.Settings.Default.Save();
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
            Program.TimeMgr.RestartSession(true);
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
            if (Program.TimeMgr.State == TimeManager.WorkingState.Working)
            {
                if (Properties.Settings.Default.MinimizeOnClockOut)
                {
                    MinimizeMainWindow();
                }

                Program.TimeMgr.State = TimeManager.WorkingState.Absent;
            }
            else
            {
                Program.TimeMgr.State = TimeManager.WorkingState.Working;
            }
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
            new OptionsDialog(this).ShowDialog();
        }

        /// <summary>
        ///   Handles a click on the close button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            MinimizeMainWindow();
        }

        /// <summary>
        ///   Handles a double click on the system tray icon.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void IcnTray_DoubleClick(object sender, EventArgs e)
        {
            RestoreMainWindow();
        }

        /// <summary>
        ///   Handles mouse moves over the system tray icon.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void IcnTrayIcon_MouseMove(object sender, MouseEventArgs e)
        {
            DateTime now = DateTime.Now;

            // avoid too many updates in short time
            if ((now - lastTrayTooltipUpdate).TotalSeconds >= 1)
            {
                UpdateLeaveTime(Visible);
                lastTrayTooltipUpdate = now;
            }
        }

        /// <summary>
        ///   Handles a click on the restore item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmRestore_Click(object sender, EventArgs e)
        {
            RestoreMainWindow();
        }

        /// <summary>
        ///   Handles a click on the options item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmOptions_Click(object sender, EventArgs e)
        {
            new OptionsDialog(this).ShowDialog(this);
        }

        /// <summary>
        ///   Handles a click on the clock-in item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmClockIn_Click(object sender, EventArgs e)
        {
            Program.TimeMgr.State = TimeManager.WorkingState.Working;
        }

        /// <summary>
        ///   Handles a click on the clock-out item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmClockOut_Click(object sender, EventArgs e)
        {
            Program.TimeMgr.State = TimeManager.WorkingState.Absent;
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
            UpdateLeaveTime(Visible);
        }

        /// <summary>
        ///   Handles an update of the working state.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void TimeMgr_WorkingStateUpdated(object sender, EventArgs e)
        {
            if (Program.TimeMgr.State == TimeManager.WorkingState.Working)
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
            }

            UpdateLeaveTime(Visible);
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
                    }

                    UpdateLeaveTime(Visible);
                    break;
                }
                case "MainWindowHotkey":
                {
                    Program.HotkeyMgr.ReregisterHotkey(hkShowMainWin, Properties.Settings.Default.MainWindowHotkey, this);
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
        private void HkShowMainWin_Pressed(object sender, HandledEventArgs e)
        {
            Debug.WriteLine("[MainWindow] Hotkey for showing main window pressed.");

            RestoreMainWindow();
            e.Handled = true;
        }

        private enum WorkingTimeDisplay
        {
            ElapsedTime,
            RemainingTime
        }

        private bool exit = false;
        private Timer wtTimer = new Timer();
        private Hotkey hkShowMainWin = null;
        private DateTime lastTrayTooltipUpdate = DateTime.Now;
    }
}
