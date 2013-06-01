using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;


namespace ClockIn
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            exit = false;

            wtTimer = new Timer();
            wtTimer.Tick += new EventHandler(wtTimer_Tick);

            Program.TimeMgr.WorkingTimeUpdated += new EventHandler(TimeMgr_WorkingTimeUpdated);

            InitializeComponent();
        }

        public void updateWorkingTime()
        {
            wtTimer.Stop();

            TimeSpan workingTime = Program.TimeMgr.getCurrentWorkingTime();

            if (workingTime.TotalMinutes > (int)(Properties.Settings.Default.MaximumWorkingTime * 60))
            {
                lblWorkingTime.ForeColor = Color.Red;
                lblIcon.ImageIndex = 3;
            }
            else if (workingTime.TotalMinutes > (int)((Properties.Settings.Default.MaximumWorkingTime * 60) - Properties.Settings.Default.NotifyAdvance))
            {
                lblWorkingTime.ForeColor = Color.Orange;
                lblIcon.ImageIndex = 2;
            }
            else if (workingTime.TotalMinutes > (int)(Properties.Settings.Default.RegularWorkingTime * 60))
            {
                lblWorkingTime.ForeColor = Color.DarkGreen;
                lblIcon.ImageIndex = 1;
            }
            else
            {
                lblWorkingTime.ForeColor = Color.Black;
                lblIcon.ImageIndex = 0;
            }

            lblWorkingTime.Text = workingTime.ToString(@"hh\:mm");

            wtTimer.Interval = getInterval();
            wtTimer.Start();
        }

        private int getInterval()
        {
            DateTime now = DateTime.Now;
            return ((60 - now.Second) * 1000 - now.Millisecond);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Hide();
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

        private void dtpArrival_ValueChanged(object sender, EventArgs e)
        {
            Program.TimeMgr.updateArrival(dtpArrival.Value);
            updateWorkingTime();
        }

        private void nmcBreaks_ValueChanged(object sender, EventArgs e)
        {
            Program.TimeMgr.updateBreaks();
            updateWorkingTime();
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
        }

        private void itmRestore_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string text = string.Format(Properties.Resources.AboutText, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            MessageBox.Show(text, Properties.Resources.AboutCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool exit;
        Timer wtTimer = null;
    }
}
