// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
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
            exit = false;

            wtTimer = new Timer();
            wtTimer.Tick += new EventHandler(WtTimer_Tick);

            Program.TimeMgr.AbsenceUpdated += TimeMgr_AbsenceUpdated;
            Program.TimeMgr.WorkingTimeUpdated += TimeMgr_WorkingTimeUpdated;
            Program.TimeMgr.LeaveTimeUpdated += TimeMgr_LeaveTimeUpdated;

            InitializeComponent();
            lblLeaveTimeIcon.Image = Properties.Resources.Power;

            if (Properties.Settings.Default.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }

            OperatingSystem os = Environment.OSVersion;
            if ((os.Platform == PlatformID.Win32NT) && (((os.Version.Major == 6) && (os.Version.Minor >= 2)) || (os.Version.Major >= 10)))
            {
                icnTrayIcon.Icon = Properties.Resources.FlatTrayIcon;
            }
            icnTrayIcon.Visible = true;

            Properties.Settings.Default.PropertyChanged += DefaultSettings_PropertyChanged;

            showMainWinHK = new Hotkey(Properties.Settings.Default.MainWindowHotkey);
            showMainWinHK.HotkeyPressed += ShowMainWin_HotkeyPressed;

            HotkeyManager.RegisterHotkey(showMainWinHK);
            Program.TimeMgr.HandleStart();
        }

        /// <summary>
        ///   Updates the working time inside the window.
        /// </summary>
        public void UpdateWorkingTime()
        {
            wtTimer.Stop();

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

            wtTimer.Interval = GetInterval();
            wtTimer.Start();
        }

        /// <summary>
        ///   Updates the leave time inside the window.
        /// </summary>
        /// <param name="updateLabel">true if label should be updated</param>
        public void UpdateLeaveTime(bool updateLabel)
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
        ///   Restores the main window so that it is visible.
        /// </summary>
        private void RestoreMainWindow()
        {
            Visible = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;

            BringToFront();
            Activate();
        }

        /// <summary>
        ///   Handles the event when the window is loading.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StartMinimized)
            {
                Visible = false;
            }
        }

        /// <summary>
        ///   Handles the event when the window has been resized.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
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
                Visible = false;
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
            UpdateWorkingTime();
            UpdateLeaveTime(true);
        }

        /// <summary>
        ///   Handles a click on the leave time text.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void LblLeaveTime_Click(object sender, EventArgs e)
        {
            UpdateWorkingTime();
            UpdateLeaveTime(true);
        }

        /// <summary>
        ///   Handles a click on the reset time button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnResetTime_Click(object sender, EventArgs e)
        {
            Program.TimeMgr.RestartSession(true);

            UpdateWorkingTime();
            UpdateLeaveTime(true);
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
            Visible = false;
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
        ///   Handles a click on the exit item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmExit_Click(object sender, EventArgs e)
        {
            exit = true;
            Close();
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
        void TimeMgr_WorkingTimeUpdated(object sender, EventArgs e)
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
        void TimeMgr_LeaveTimeUpdated(object sender, EventArgs e)
        {
            UpdateLeaveTime(Visible);
        }

        /// <summary>
        ///   Handles the change of a user setting.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void DefaultSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DisplayMaximumTime")
            {
                if (Visible)
                {
                    UpdateWorkingTime();
                }

                UpdateLeaveTime(Visible);
            }

            if (e.PropertyName == "MainWindowHotkey")
            {
                showMainWinHK.Key = Properties.Settings.Default.MainWindowHotkey;
            }
        }

        /// <summary>
        ///   Handles the key press of the hotkey.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ShowMainWin_HotkeyPressed(object sender, EventArgs e)
        {
            Debug.WriteLine("[MainWindow] Hotkey pressed.");

            if (Visible)
            {
                Activate();
            }
            else
            {
                RestoreMainWindow();
            }
        }

        private enum WorkingTimeDisplay
        {
            ElapsedTime,
            RemainingTime
        }

        private bool exit;
        private Timer wtTimer = null;
        private Hotkey showMainWinHK = null;
        private DateTime lastTrayTooltipUpdate = DateTime.Now;
    }
}
