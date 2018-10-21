// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
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

            if (Properties.Settings.Default.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
            }

            Properties.Settings.Default.PropertyChanged += DefaultSettings_PropertyChanged;

            showMainWinHK = new Hotkey(Properties.Settings.Default.MainWindowHotkey);
            showMainWinHK.HotkeyPressed += ShowMainWin_HotkeyPressed;

            HotkeyManager.RegisterHotkey(showMainWinHK);
        }

        /// <summary>
        ///   Updates the working time inside the window.
        /// </summary>
        public void UpdateWorkingTime()
        {
            wtTimer.Stop();

            TimeManager.WorkingLevel level;
            TimeSpan elapsedTime = Program.TimeMgr.GetCurrentElapsedWorkingTime(out level);

            if (elapsedTime.TotalMinutes > (int)(Properties.Settings.Default.MaximumWorkingTime * 60))
            {
                lblWorkingTime.ForeColor = Color.Red;
                lblIcon.Image = Properties.Resources.Sad;
            }
            else if (elapsedTime.TotalMinutes > (int)((Properties.Settings.Default.MaximumWorkingTime * 60) - Properties.Settings.Default.NotifyAdvance))
            {
                lblWorkingTime.ForeColor = Color.Orange;
                lblIcon.Image = Properties.Resources.Ooooh;
            }
            else if (elapsedTime.TotalMinutes > (int)(Properties.Settings.Default.RegularWorkingTime * 60))
            {
                lblWorkingTime.ForeColor = Color.DarkGreen;
                lblIcon.Image = Properties.Resources.BigSmile;
            }
            else
            {
                lblWorkingTime.ForeColor = Color.Black;
                lblIcon.Image = Properties.Resources.Confused;
            }

            WorkingTimeDisplay wtd = (WorkingTimeDisplay)System.Enum.Parse(typeof(WorkingTimeDisplay), Properties.Settings.Default.WorkingTimeDisplay);
            if (wtd == WorkingTimeDisplay.ElapsedTime)
            {
                lblWorkingTimeIcon.Image = Properties.Resources.Stopwatch;
                lblWorkingTime.Text = elapsedTime.ToString(@"hh\hmm\m");
            }
            else
            {
                TimeSpan remainingTime = Program.TimeMgr.GetCurrentRemainingWorkingTime();
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
        public void UpdateLeaveTime()
        {
            bool overTime;
            DateTime leaveTime = Program.TimeMgr.GetCurrentLeaveTime(out overTime);

            if (overTime)
            {
                lblLeaveTime.ForeColor = Color.Red;
            }
            else
            {
                lblLeaveTime.ForeColor = Color.Black;
            }
            
            lblLeaveTime.Text = leaveTime.ToString(@"HH\:mm");
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

            Properties.Settings.Default.WorkingTimeDisplay = System.Enum.Format(typeof(WorkingTimeDisplay), wtd, "G");
            UpdateWorkingTime();
            UpdateLeaveTime();
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
                Hide();
            }

            lblLeaveTimeIcon.Image = Properties.Resources.Power;
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
                Hide();
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
                Hide();
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
            Program.TimeMgr.UpdateArrival(dtpArrival.Value);
            UpdateWorkingTime();
            UpdateLeaveTime();
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
            UpdateLeaveTime();
        }

        /// <summary>
        ///   Handles a click on the leave time text.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void LblLeaveTime_Click(object sender, EventArgs e)
        {
            UpdateWorkingTime();
            UpdateLeaveTime();
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
            UpdateLeaveTime();
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
            Hide();
        }

        /// <summary>
        ///   Handles a double click on the system tray icon.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void IcnTray_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        /// <summary>
        ///   Handles a click on the restore item in the system tray menu.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void ItmRestore_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
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
            if (Visible)
            {
                UpdateLeaveTime();
            }
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
                    UpdateLeaveTime();
                }
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
            if (!Visible)
            {
                Show();
                WindowState = FormWindowState.Normal;
                BringToFront();
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
    }
}
