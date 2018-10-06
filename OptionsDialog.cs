using System;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;


namespace ClockIn
{
    public partial class OptionsDialog : Form
    {
        public const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public OptionsDialog(MainWindow mainWin)
        {
            mainWindow = mainWin;
            InitializeComponent();
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            rbtContinueSession.Checked = Properties.Settings.Default.ContinueSessionOnStartup;
            rbtNewSession.Checked = Properties.Settings.Default.NewSessionOnStartup;
            rbtQueryStartBehavior.Checked = Properties.Settings.Default.AskSessionOnStartup;
            CheckAutoLaunch();

            if (Properties.Settings.Default.SoundFile != "")
            {
                dlgSelectSound.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.SoundFile);
                lblSoundFile.Text = Path.GetFileNameWithoutExtension(Properties.Settings.Default.SoundFile);
            }
        }

        private void OptionsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.ContinueSessionOnStartup = rbtContinueSession.Checked;
            Properties.Settings.Default.NewSessionOnStartup = rbtNewSession.Checked;
            Properties.Settings.Default.AskSessionOnStartup = rbtQueryStartBehavior.Checked;
            SetAutoLaunch(cbxAutoLaunch.Checked);

            Properties.Settings.Default.Save();
        }

        private void NmcRegularTime_Validating(object sender, CancelEventArgs e)
        {
            if ((int)(nmcRegularTime.Value * 60) > (int)(Properties.Settings.Default.MaximumWorkingTime * 60))
            {
                MessageBox.Show(Properties.Resources.RegularTimeGreaterMaxTime, Properties.Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else if ((int)Properties.Settings.Default.Break > (int)(nmcRegularTime.Value * 60))
            {
                MessageBox.Show(Properties.Resources.BreakGreaterRegularMaxTime, Properties.Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void NmcRegularTime_Validated(object sender, EventArgs e)
        {
            Program.TimeMgr.UpdateWorkingTime();
            Program.TimeMgr.UpdateLeaveTime();
        }

        private void NmcMaxTime_Validating(object sender, CancelEventArgs e)
        {
            if ((int)(nmcMaxTime.Value * 60) <= (int)(Properties.Settings.Default.RegularWorkingTime * 60))
            {
                MessageBox.Show(Properties.Resources.RegularTimeGreaterMaxTime, Properties.Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else if ((int)Properties.Settings.Default.Break > (int)(nmcMaxTime.Value * 60))
            {
                MessageBox.Show(Properties.Resources.BreakGreaterRegularMaxTime, Properties.Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void NmcMaxTime_Validated(object sender, EventArgs e)
        {
            Program.TimeMgr.UpdateWorkingTime();
            Program.TimeMgr.UpdateLeaveTime();
        }

        private void NmcBreak_Validating(object sender, CancelEventArgs e)
        {
            if ((int)nmcBreak.Value > (int)(Properties.Settings.Default.RegularWorkingTime * 60))
            {
                MessageBox.Show(Properties.Resources.BreakGreaterRegularMaxTime, Properties.Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void DtpBreaksBegin_Validating(object sender, CancelEventArgs e)
        {
            if (dtpBreaksBegin.Value >= Properties.Settings.Default.BreaksEnd)
            {
                MessageBox.Show(Properties.Resources.BreaksBeginAfterBreaksEnd, Properties.Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void DtpBreaksBegin_Validated(object sender, EventArgs e)
        {
            Program.TimeMgr.UpdateWorkingTime();
            Program.TimeMgr.UpdateLeaveTime();
        }

        private void DtpBreaksEnd_Validating(object sender, CancelEventArgs e)
        {
            if (dtpBreaksEnd.Value < Properties.Settings.Default.BreaksBegin)
            {
                MessageBox.Show(Properties.Resources.BreaksBeginAfterBreaksEnd, Properties.Resources.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void DtpBreaksEnd_Validated(object sender, EventArgs e)
        {
            Program.TimeMgr.UpdateWorkingTime();
            Program.TimeMgr.UpdateLeaveTime();
        }

        private void BtnSelectSound_Click(object sender, EventArgs e)
        {
            DialogResult res = dlgSelectSound.ShowDialog();
            if (res == DialogResult.OK)
            {
                Properties.Settings.Default.SoundFile = dlgSelectSound.FileName;
                lblSoundFile.Text = Path.GetFileNameWithoutExtension(Properties.Settings.Default.SoundFile);
            }
        }

        private void TxtHotkey_Enter(object sender, EventArgs e)
        {
            HotkeyManager.HotkeysEnabled = false;
        }

        private void txtHotkey_Leave(object sender, EventArgs e)
        {
            HotkeyManager.HotkeysEnabled = true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetAutoLaunch(bool enable)
        {
            Microsoft.Win32.RegistryKey startupKey;

            if (enable)
            {
                startupKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RunKey, true);
                startupKey.SetValue(Assembly.GetExecutingAssembly().GetName().Name, Application.ExecutablePath.ToString());
                startupKey.Close();
            }
            else
            {
                startupKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RunKey, true);
                startupKey.DeleteValue(Assembly.GetExecutingAssembly().GetName().Name, false);
                startupKey.Close();
            }
        }

        private void CheckAutoLaunch()
        {
            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RunKey);
            if (startupKey.GetValue(Assembly.GetExecutingAssembly().GetName().Name) == null)
            {
                cbxAutoLaunch.Checked = false;
            }
            else
            {
                cbxAutoLaunch.Checked = true;
            }
        }

        private MainWindow mainWindow = null;
    }
}
