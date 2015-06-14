using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;


namespace ClockIn
{
    public partial class MainWindow : Form
    {
        private enum WorkingTimeDisplay
        {
            ElapsedTime,
            RemainingTime
        }

        public MainWindow()
        {
            exit = false;

            wtTimer = new Timer();
            wtTimer.Tick += new EventHandler(wtTimer_Tick);

            Program.TimeMgr.WorkingTimeUpdated += new EventHandler(TimeMgr_WorkingTimeUpdated);
            Program.TimeMgr.LeaveTimeUpdated += new EventHandler(TimeMgr_LeaveTimeUpdated);

            InitializeComponent();

            Properties.Settings.Default.PropertyChanged += DefaultSettings_PropertyChanged;

            showMainWinHK = new Hotkey(Properties.Settings.Default.MainWindowHotkey);
            showMainWinHK.HotkeyPressed += ShowMainWin_HotkeyPressed;

            HotkeyManager.RegisterHotkey(showMainWinHK);
        }

        public void updateWorkingTime()
        {
            wtTimer.Stop();

            TimeManager.WorkingLevel level;
            TimeSpan elapsedTime = Program.TimeMgr.getCurrentElapsedWorkingTime(out level);

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
                TimeSpan remainingTime = Program.TimeMgr.getCurrentRemainingWorkingTime();
                if (remainingTime.Seconds > 0)
                {
                    remainingTime = new TimeSpan(remainingTime.Hours, remainingTime.Minutes + 1, 0);
                }

                lblWorkingTimeIcon.Image = Properties.Resources.Timer;
                lblWorkingTime.Text = remainingTime.ToString(@"\-hh\hmm\m");
            }

            wtTimer.Interval = getInterval();
            wtTimer.Start();
        }

        public void updateLeaveTime()
        {
            bool overTime;
            DateTime leaveTime = Program.TimeMgr.getCurrentLeaveTime(out overTime);

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

        private int getInterval()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000 - now.Millisecond);
        }

        private void switchWorkingTimeDisplay()
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
            updateWorkingTime();
            updateLeaveTime();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Hide();

            lblLeaveTimeIcon.Image = Properties.Resources.Power;
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void MainWindow_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                updateWorkingTime();
                updateLeaveTime();
            }
            else
            {
                wtTimer.Stop();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            wtTimer.Stop();
            Properties.Settings.Default.Save();
        }

        private void dtpArrival_Validated(object sender, EventArgs e)
        {
            Program.TimeMgr.updateArrival(dtpArrival.Value);
            updateWorkingTime();
            updateLeaveTime();
        }

        private void nmcBreaks_Validated(object sender, EventArgs e)
        {
            // workaround because bound property is not updated when number has been entered by keyboard
            Session.Default.Break = nmcBreaks.Value;

            Program.TimeMgr.updateBreaks();
            updateWorkingTime();
            updateLeaveTime();
        }

        private void lblWorkingTimeIcon_Click(object sender, EventArgs e)
        {
            switchWorkingTimeDisplay();
        }

        private void lblWorkingTime_Click(object sender, EventArgs e)
        {
            switchWorkingTimeDisplay();
        }

        private void lblLeaveTimeIcon_Click(object sender, EventArgs e)
        {
            updateWorkingTime();
            updateLeaveTime();
        }

        private void lblLeaveTime_Click(object sender, EventArgs e)
        {
            updateWorkingTime();
            updateLeaveTime();
        }

        private void lblBegin_DoubleClick(object sender, EventArgs e)
        {
            Program.TimeMgr.restartSession(true);

            updateWorkingTime();
            updateLeaveTime();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string text = string.Format(Properties.Resources.AboutText, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            MessageBox.Show(text, Properties.Resources.AboutCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            new OptionsDialog(this).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void icnTray_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void itmRestore_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void itmOptions_Click(object sender, EventArgs e)
        {
            new OptionsDialog(this).ShowDialog(this);
        }

        private void itmExit_Click(object sender, EventArgs e)
        {
            exit = true;
            Close();
        }

        private void wtTimer_Tick(object sender, EventArgs e)
        {
            updateWorkingTime();
        }

        void TimeMgr_WorkingTimeUpdated(object sender, EventArgs e)
        {
            if (Visible)
            {
                updateWorkingTime();
            }
        }

        void TimeMgr_LeaveTimeUpdated(object sender, EventArgs e)
        {
            if (Visible)
            {
                updateLeaveTime();
            }
        }

        private void DefaultSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DisplayMaximumTime")
            {
                if (Visible)
                {
                    updateWorkingTime();
                    updateLeaveTime();
                }
            }

            if (e.PropertyName == "MainWindowHotkey")
            {
                showMainWinHK.Key = Properties.Settings.Default.MainWindowHotkey;
            }
        }

        private void ShowMainWin_HotkeyPressed(object sender, EventArgs e)
        {
            if (!Visible)
            {
                Show();
                WindowState = FormWindowState.Normal;
                BringToFront();
            }
        }

        private bool exit;
        private Timer wtTimer = null;
        private Hotkey showMainWinHK = null;
    }
}
