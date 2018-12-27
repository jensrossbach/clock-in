// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   Dialog window for settings and options
    /// </summary>
    public partial class OptionsDialog : Form
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public OptionsDialog(MainWindow mainWin)
        {
            mainWindow = mainWin;
            InitializeComponent();
        }

        /// <summary>
        ///   Registry key for application auto launch
        /// </summary>
        public const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        ///   Validates the value for regular working time.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateRegularWorkingTime(decimal value, bool showWarning)
        {
            bool ret = false;

            if ((int)(value * 60) > (int)(Properties.Settings.Default.MaximumWorkingTime * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.RegularTimeGreaterMaxTime, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }
            else if ((int)Properties.Settings.Default.Break > (int)(value * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.BreakGreaterRegularMaxTime, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for maximum working time.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateMaximumWorkingTime(decimal value, bool showWarning)
        {
            bool ret = false;

            if ((int)(value * 60) <= (int)(Properties.Settings.Default.RegularWorkingTime * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.RegularTimeGreaterMaxTime, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }
            else if ((int)Properties.Settings.Default.Break > (int)(value * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.BreakGreaterRegularMaxTime, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for break period begin.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateBreaksBegin(DateTime value, bool showWarning)
        {
            bool ret = false;

            if (value >= Properties.Settings.Default.BreaksEnd)
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.BreaksBeginAfterBreaksEnd, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for break period end.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateBreaksEnd(DateTime value, bool showWarning)
        {
            bool ret = false;

            if (value < Properties.Settings.Default.BreaksBegin)
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.BreaksBeginAfterBreaksEnd, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for chargeable break duration.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateBreak(decimal value, bool showWarning)
        {
            bool ret = false;

            if ((int)value > (int)(Properties.Settings.Default.RegularWorkingTime * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.BreakGreaterRegularMaxTime, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for first lateshift workspan.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateWorkspan1(decimal value, bool showWarning)
        {
            bool ret = false;

            if ((int)(value * 60) > (int)(Properties.Settings.Default.OutsideLunchWorkspan2 * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.OutsideLunchWorkspan1Greater2, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }
            else if ((int)Properties.Settings.Default.OutsideLunchBreak1 > (int)(value * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.OutsideLunchAdderGreaterThanWorkspan, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for second lateshift workspan.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateWorkspan2(decimal value, bool showWarning)
        {
            bool ret = false;

            if ((int)(value * 60) <= (int)(Properties.Settings.Default.OutsideLunchWorkspan1 * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.OutsideLunchWorkspan1Greater2, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }
            else if ((int)Properties.Settings.Default.OutsideLunchBreak2 > (int)(value * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.OutsideLunchAdderGreaterThanWorkspan, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for first lateshift break adder.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateAdder1(decimal value, bool showWarning)
        {
            bool ret = false;

            if ((int)value > (int)(Properties.Settings.Default.OutsideLunchWorkspan1 * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.OutsideLunchAdderGreaterThanWorkspan, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Validates the value for second lateshift break adder.
        /// </summary>
        /// <param name="value">Value to be validated</param>
        /// <param name="showWarning">true if message box should be shown in case of invalid value</param>
        /// <returns>true if value is invalid, false otherwise</returns>
        private bool ValidateAdder2(decimal value, bool showWarning)
        {
            bool ret = false;

            if ((int)value > (int)(Properties.Settings.Default.OutsideLunchWorkspan2 * 60))
            {
                if (showWarning)
                {
                    MessageBox.Show(Properties.Resources.OutsideLunchAdderGreaterThanWorkspan, Properties.Resources.WindowCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                ret = true;
            }

            return ret;
        }

        /// <summary>
        ///   Enables or disables application auto launch in the registry.
        /// </summary>
        /// <param name="enable">true to enable auto launch, false otherwise</param>
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

        /// <summary>
        ///   Checks if application auto launch is enabled in the registry
        ///   and configures checkbox accordingly.
        /// </summary>
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

        private void Default_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[OptionsDialog] Setting '" + e.SettingName + "' is about to be changed.");

            switch (e.SettingName)
            {
                case "RegularWorkingTime":
                {
                    e.Cancel = ValidateRegularWorkingTime((decimal)e.NewValue, false);
                    break;
                }
                case "MaximumWorkingTime":
                {
                    e.Cancel = ValidateMaximumWorkingTime((decimal)e.NewValue, false);
                    break;
                }
                case "BreaksBegin":
                {
                    e.Cancel = ValidateBreaksBegin((DateTime)e.NewValue, false);
                    break;
                }
                case "BreaksEnd":
                {
                    e.Cancel = ValidateBreaksEnd((DateTime)e.NewValue, false);
                    break;
                }
                case "Break":
                {
                    e.Cancel = ValidateBreak((decimal)e.NewValue, false);
                    break;
                }
                case "OutsideLunchWorkspan1":
                {
                    e.Cancel = ValidateWorkspan1((decimal)e.NewValue, false);
                    break;
                }
                case "OutsideLunchWorkspan2":
                {
                    e.Cancel = ValidateWorkspan2((decimal)e.NewValue, false);
                    break;
                }
                case "OutsideLunchBreak1":
                {
                    e.Cancel = ValidateAdder1((decimal)e.NewValue, false);
                    break;
                }
                case "OutsideLunchBreak2":
                {
                    e.Cancel = ValidateAdder2((decimal)e.NewValue, false);
                    break;
                }
            }
        }

        /// <summary>
        ///   Handles the event when the dialog window is loading.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
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

            Properties.Settings.Default.SettingChanging += Default_SettingChanging;
        }

        /// <summary>
        ///   Handles the event when the dialog window has been closed.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void OptionsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.ContinueSessionOnStartup = rbtContinueSession.Checked;
            Properties.Settings.Default.NewSessionOnStartup = rbtNewSession.Checked;
            Properties.Settings.Default.AskSessionOnStartup = rbtQueryStartBehavior.Checked;
            SetAutoLaunch(cbxAutoLaunch.Checked);

            Properties.Settings.Default.Save();
        }

        /// <summary>
        ///   Handles the event when the regular time text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NmcRegularTime_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateRegularWorkingTime(nmcRegularTime.Value, true);
        }

        /// <summary>
        ///   Handles the event when the maximum time text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NmcMaxTime_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateMaximumWorkingTime(nmcMaxTime.Value, true);
        }

        /// <summary>
        ///   Handles the event when the breaks begin text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void DtpBreaksBegin_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateBreaksBegin(dtpBreaksBegin.Value, true);
        }

        /// <summary>
        ///   Handles the event when the breaks end text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void DtpBreaksEnd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateBreaksEnd(dtpBreaksEnd.Value, true);
        }

        /// <summary>
        ///   Handles the event when the break text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NmcBreak_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateBreak(nmcBreak.Value, true);
        }

        /// <summary>
        ///   Handles the event when the workspan 1 text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NmcWorkspan1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateWorkspan1(nmcWorkspan1.Value, true);
        }

        /// <summary>
        ///   Handles the event when the workspan 2 text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NmcWorkspan2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateWorkspan2(nmcWorkspan2.Value, true);
        }

        /// <summary>
        ///   Handles the event when the adder 1 text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NmcAdder1_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateAdder1(nmcAdder1.Value, true);
        }

        /// <summary>
        ///   Handles the event when the adder 2 text box is about to
        ///   validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NmcAdder2_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateAdder2(nmcAdder2.Value, true);
        }

        /// <summary>
        ///   Handles a click on the Select Sound button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnSelectSound_Click(object sender, EventArgs e)
        {
            DialogResult res = dlgSelectSound.ShowDialog();
            if (res == DialogResult.OK)
            {
                Properties.Settings.Default.SoundFile = dlgSelectSound.FileName;
                lblSoundFile.Text = Path.GetFileNameWithoutExtension(Properties.Settings.Default.SoundFile);
            }
        }

        /// <summary>
        ///   Handles a click on the hotkeys button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnHotkeys_Click(object sender, EventArgs e)
        {
            new HotkeysDialog().ShowDialog(this);
        }

        /// <summary>
        ///   Handles a click on the close button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private MainWindow mainWindow = null;
    }
}
