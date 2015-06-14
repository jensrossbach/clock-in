namespace ClockIn
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.lblRegularTime = new System.Windows.Forms.Label();
            this.lblRegularTimeH = new System.Windows.Forms.Label();
            this.lblMaxTime = new System.Windows.Forms.Label();
            this.lblMaxTimeH = new System.Windows.Forms.Label();
            this.lblMinBefore = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBreak = new System.Windows.Forms.Label();
            this.lblBreakMin = new System.Windows.Forms.Label();
            this.grpStartup = new System.Windows.Forms.GroupBox();
            this.cbxAutoLaunch = new System.Windows.Forms.CheckBox();
            this.cbxLowPowerIsStart = new System.Windows.Forms.CheckBox();
            this.rbtQueryStartBehavior = new System.Windows.Forms.RadioButton();
            this.rbtContinueSession = new System.Windows.Forms.RadioButton();
            this.rbtNewSession = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblBreaks = new System.Windows.Forms.Label();
            this.lblBreaksMin = new System.Windows.Forms.Label();
            this.grpBreaksPeriod = new System.Windows.Forms.GroupBox();
            this.dtpBreaksEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBreaksEnd = new System.Windows.Forms.Label();
            this.lblBreaksBegin = new System.Windows.Forms.Label();
            this.dtpBreaksBegin = new System.Windows.Forms.DateTimePicker();
            this.btnSelectSound = new System.Windows.Forms.Button();
            this.cbxPlaySound = new System.Windows.Forms.CheckBox();
            this.nmcNotifyAdvance = new System.Windows.Forms.NumericUpDown();
            this.cbxNotifyMaxTime = new System.Windows.Forms.CheckBox();
            this.cbxNotifyRegularTime = new System.Windows.Forms.CheckBox();
            this.nmcBreak = new System.Windows.Forms.NumericUpDown();
            this.nmcMaxTime = new System.Windows.Forms.NumericUpDown();
            this.nmcRegularTime = new System.Windows.Forms.NumericUpDown();
            this.nmcBreaksDuration = new System.Windows.Forms.NumericUpDown();
            this.dlgSelectSound = new System.Windows.Forms.OpenFileDialog();
            this.lblSoundFile = new System.Windows.Forms.Label();
            this.cbxNotificationAlwayOnTop = new System.Windows.Forms.CheckBox();
            this.lblHotkey = new System.Windows.Forms.Label();
            this.txtHotkey = new ClockIn.HotkeyControl();
            this.grpStartup.SuspendLayout();
            this.grpBreaksPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyAdvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcRegularTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreaksDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegularTime
            // 
            resources.ApplyResources(this.lblRegularTime, "lblRegularTime");
            this.lblRegularTime.Name = "lblRegularTime";
            // 
            // lblRegularTimeH
            // 
            resources.ApplyResources(this.lblRegularTimeH, "lblRegularTimeH");
            this.lblRegularTimeH.Name = "lblRegularTimeH";
            // 
            // lblMaxTime
            // 
            resources.ApplyResources(this.lblMaxTime, "lblMaxTime");
            this.lblMaxTime.Name = "lblMaxTime";
            // 
            // lblMaxTimeH
            // 
            resources.ApplyResources(this.lblMaxTimeH, "lblMaxTimeH");
            this.lblMaxTimeH.Name = "lblMaxTimeH";
            // 
            // lblMinBefore
            // 
            resources.ApplyResources(this.lblMinBefore, "lblMinBefore");
            this.lblMinBefore.Name = "lblMinBefore";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblBreak
            // 
            resources.ApplyResources(this.lblBreak, "lblBreak");
            this.lblBreak.Name = "lblBreak";
            // 
            // lblBreakMin
            // 
            resources.ApplyResources(this.lblBreakMin, "lblBreakMin");
            this.lblBreakMin.Name = "lblBreakMin";
            // 
            // grpStartup
            // 
            this.grpStartup.Controls.Add(this.cbxAutoLaunch);
            this.grpStartup.Controls.Add(this.cbxLowPowerIsStart);
            this.grpStartup.Controls.Add(this.rbtQueryStartBehavior);
            this.grpStartup.Controls.Add(this.rbtContinueSession);
            this.grpStartup.Controls.Add(this.rbtNewSession);
            resources.ApplyResources(this.grpStartup, "grpStartup");
            this.grpStartup.Name = "grpStartup";
            this.grpStartup.TabStop = false;
            // 
            // cbxAutoLaunch
            // 
            resources.ApplyResources(this.cbxAutoLaunch, "cbxAutoLaunch");
            this.cbxAutoLaunch.Name = "cbxAutoLaunch";
            this.cbxAutoLaunch.UseVisualStyleBackColor = true;
            // 
            // cbxLowPowerIsStart
            // 
            resources.ApplyResources(this.cbxLowPowerIsStart, "cbxLowPowerIsStart");
            this.cbxLowPowerIsStart.Checked = global::ClockIn.Properties.Settings.Default.LowPowerIsStart;
            this.cbxLowPowerIsStart.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "LowPowerIsStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxLowPowerIsStart.Name = "cbxLowPowerIsStart";
            this.cbxLowPowerIsStart.UseVisualStyleBackColor = true;
            // 
            // rbtQueryStartBehavior
            // 
            resources.ApplyResources(this.rbtQueryStartBehavior, "rbtQueryStartBehavior");
            this.rbtQueryStartBehavior.Checked = true;
            this.rbtQueryStartBehavior.Name = "rbtQueryStartBehavior";
            this.rbtQueryStartBehavior.TabStop = true;
            this.rbtQueryStartBehavior.UseVisualStyleBackColor = true;
            // 
            // rbtContinueSession
            // 
            resources.ApplyResources(this.rbtContinueSession, "rbtContinueSession");
            this.rbtContinueSession.Name = "rbtContinueSession";
            this.rbtContinueSession.UseVisualStyleBackColor = true;
            // 
            // rbtNewSession
            // 
            resources.ApplyResources(this.rbtNewSession, "rbtNewSession");
            this.rbtNewSession.Name = "rbtNewSession";
            this.rbtNewSession.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            // 
            // lblBreaks
            // 
            resources.ApplyResources(this.lblBreaks, "lblBreaks");
            this.lblBreaks.Name = "lblBreaks";
            // 
            // lblBreaksMin
            // 
            resources.ApplyResources(this.lblBreaksMin, "lblBreaksMin");
            this.lblBreaksMin.Name = "lblBreaksMin";
            // 
            // grpBreaksPeriod
            // 
            this.grpBreaksPeriod.Controls.Add(this.dtpBreaksEnd);
            this.grpBreaksPeriod.Controls.Add(this.lblBreaksEnd);
            this.grpBreaksPeriod.Controls.Add(this.lblBreaksBegin);
            this.grpBreaksPeriod.Controls.Add(this.dtpBreaksBegin);
            resources.ApplyResources(this.grpBreaksPeriod, "grpBreaksPeriod");
            this.grpBreaksPeriod.Name = "grpBreaksPeriod";
            this.grpBreaksPeriod.TabStop = false;
            // 
            // dtpBreaksEnd
            // 
            resources.ApplyResources(this.dtpBreaksEnd, "dtpBreaksEnd");
            this.dtpBreaksEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "BreaksEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpBreaksEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBreaksEnd.Name = "dtpBreaksEnd";
            this.dtpBreaksEnd.ShowUpDown = true;
            this.dtpBreaksEnd.Value = global::ClockIn.Properties.Settings.Default.BreaksEnd;
            this.dtpBreaksEnd.Validating += new System.ComponentModel.CancelEventHandler(this.dtpBreaksEnd_Validating);
            this.dtpBreaksEnd.Validated += new System.EventHandler(this.dtpBreaksEnd_Validated);
            // 
            // lblBreaksEnd
            // 
            resources.ApplyResources(this.lblBreaksEnd, "lblBreaksEnd");
            this.lblBreaksEnd.Name = "lblBreaksEnd";
            // 
            // lblBreaksBegin
            // 
            resources.ApplyResources(this.lblBreaksBegin, "lblBreaksBegin");
            this.lblBreaksBegin.Name = "lblBreaksBegin";
            // 
            // dtpBreaksBegin
            // 
            resources.ApplyResources(this.dtpBreaksBegin, "dtpBreaksBegin");
            this.dtpBreaksBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "BreaksBegin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpBreaksBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBreaksBegin.Name = "dtpBreaksBegin";
            this.dtpBreaksBegin.ShowUpDown = true;
            this.dtpBreaksBegin.Value = global::ClockIn.Properties.Settings.Default.BreaksBegin;
            this.dtpBreaksBegin.Validating += new System.ComponentModel.CancelEventHandler(this.dtpBreaksBegin_Validating);
            this.dtpBreaksBegin.Validated += new System.EventHandler(this.dtpBreaksBegin_Validated);
            // 
            // btnSelectSound
            // 
            this.btnSelectSound.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::ClockIn.Properties.Settings.Default, "PlaySound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnSelectSound.Enabled = global::ClockIn.Properties.Settings.Default.PlaySound;
            resources.ApplyResources(this.btnSelectSound, "btnSelectSound");
            this.btnSelectSound.Name = "btnSelectSound";
            this.btnSelectSound.UseVisualStyleBackColor = true;
            this.btnSelectSound.Click += new System.EventHandler(this.btnSelectSound_Click);
            // 
            // cbxPlaySound
            // 
            resources.ApplyResources(this.cbxPlaySound, "cbxPlaySound");
            this.cbxPlaySound.Checked = global::ClockIn.Properties.Settings.Default.PlaySound;
            this.cbxPlaySound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPlaySound.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "PlaySound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxPlaySound.Name = "cbxPlaySound";
            this.cbxPlaySound.UseVisualStyleBackColor = true;
            // 
            // nmcNotifyAdvance
            // 
            this.nmcNotifyAdvance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "NotifyAdvance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcNotifyAdvance, "nmcNotifyAdvance");
            this.nmcNotifyAdvance.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmcNotifyAdvance.Name = "nmcNotifyAdvance";
            this.nmcNotifyAdvance.Value = global::ClockIn.Properties.Settings.Default.NotifyAdvance;
            // 
            // cbxNotifyMaxTime
            // 
            resources.ApplyResources(this.cbxNotifyMaxTime, "cbxNotifyMaxTime");
            this.cbxNotifyMaxTime.Checked = global::ClockIn.Properties.Settings.Default.NotifyOnMaximumLimit;
            this.cbxNotifyMaxTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNotifyMaxTime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "NotifyOnMaximumLimit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxNotifyMaxTime.Name = "cbxNotifyMaxTime";
            this.cbxNotifyMaxTime.UseVisualStyleBackColor = true;
            // 
            // cbxNotifyRegularTime
            // 
            resources.ApplyResources(this.cbxNotifyRegularTime, "cbxNotifyRegularTime");
            this.cbxNotifyRegularTime.Checked = global::ClockIn.Properties.Settings.Default.NotifyOnRegularLimit;
            this.cbxNotifyRegularTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNotifyRegularTime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "NotifyOnRegularLimit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxNotifyRegularTime.Name = "cbxNotifyRegularTime";
            this.cbxNotifyRegularTime.UseVisualStyleBackColor = true;
            // 
            // nmcBreak
            // 
            this.nmcBreak.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "Break", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcBreak, "nmcBreak");
            this.nmcBreak.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nmcBreak.Name = "nmcBreak";
            this.nmcBreak.Value = global::ClockIn.Properties.Settings.Default.Break;
            this.nmcBreak.Validating += new System.ComponentModel.CancelEventHandler(this.nmcBreak_Validating);
            // 
            // nmcMaxTime
            // 
            this.nmcMaxTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "MaximumWorkingTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcMaxTime.DecimalPlaces = 1;
            this.nmcMaxTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            resources.ApplyResources(this.nmcMaxTime, "nmcMaxTime");
            this.nmcMaxTime.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmcMaxTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmcMaxTime.Name = "nmcMaxTime";
            this.nmcMaxTime.Value = global::ClockIn.Properties.Settings.Default.MaximumWorkingTime;
            this.nmcMaxTime.Validating += new System.ComponentModel.CancelEventHandler(this.nmcMaxTime_Validating);
            this.nmcMaxTime.Validated += new System.EventHandler(this.nmcMaxTime_Validated);
            // 
            // nmcRegularTime
            // 
            this.nmcRegularTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "RegularWorkingTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcRegularTime.DecimalPlaces = 1;
            this.nmcRegularTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            resources.ApplyResources(this.nmcRegularTime, "nmcRegularTime");
            this.nmcRegularTime.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmcRegularTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmcRegularTime.Name = "nmcRegularTime";
            this.nmcRegularTime.Value = global::ClockIn.Properties.Settings.Default.RegularWorkingTime;
            this.nmcRegularTime.Validating += new System.ComponentModel.CancelEventHandler(this.nmcRegularTime_Validating);
            this.nmcRegularTime.Validated += new System.EventHandler(this.nmcRegularTime_Validated);
            // 
            // nmcBreaksDuration
            // 
            this.nmcBreaksDuration.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "BreaksDuration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcBreaksDuration, "nmcBreaksDuration");
            this.nmcBreaksDuration.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nmcBreaksDuration.Name = "nmcBreaksDuration";
            this.nmcBreaksDuration.Value = global::ClockIn.Properties.Settings.Default.Break;
            // 
            // dlgSelectSound
            // 
            resources.ApplyResources(this.dlgSelectSound, "dlgSelectSound");
            // 
            // lblSoundFile
            // 
            resources.ApplyResources(this.lblSoundFile, "lblSoundFile");
            this.lblSoundFile.Name = "lblSoundFile";
            // 
            // cbxNotificationAlwayOnTop
            // 
            resources.ApplyResources(this.cbxNotificationAlwayOnTop, "cbxNotificationAlwayOnTop");
            this.cbxNotificationAlwayOnTop.Checked = global::ClockIn.Properties.Settings.Default.NotificationAlwaysOnTop;
            this.cbxNotificationAlwayOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNotificationAlwayOnTop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "NotificationAlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxNotificationAlwayOnTop.Name = "cbxNotificationAlwayOnTop";
            this.cbxNotificationAlwayOnTop.UseVisualStyleBackColor = true;
            // 
            // lblHotkey
            // 
            resources.ApplyResources(this.lblHotkey, "lblHotkey");
            this.lblHotkey.Name = "lblHotkey";
            // 
            // txtHotkey
            // 
            this.txtHotkey.DataBindings.Add(new System.Windows.Forms.Binding("Hotkey", global::ClockIn.Properties.Settings.Default, "MainWindowHotkey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHotkey.Hotkey = global::ClockIn.Properties.Settings.Default.MainWindowHotkey;
            resources.ApplyResources(this.txtHotkey, "txtHotkey");
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.Enter += new System.EventHandler(this.txtHotkey_Enter);
            this.txtHotkey.Leave += new System.EventHandler(this.txtHotkey_Leave);
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtHotkey);
            this.Controls.Add(this.lblHotkey);
            this.Controls.Add(this.cbxNotificationAlwayOnTop);
            this.Controls.Add(this.lblSoundFile);
            this.Controls.Add(this.grpBreaksPeriod);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpStartup);
            this.Controls.Add(this.btnSelectSound);
            this.Controls.Add(this.cbxPlaySound);
            this.Controls.Add(this.lblMinBefore);
            this.Controls.Add(this.nmcNotifyAdvance);
            this.Controls.Add(this.cbxNotifyMaxTime);
            this.Controls.Add(this.cbxNotifyRegularTime);
            this.Controls.Add(this.lblBreakMin);
            this.Controls.Add(this.nmcBreak);
            this.Controls.Add(this.lblBreak);
            this.Controls.Add(this.lblMaxTimeH);
            this.Controls.Add(this.nmcMaxTime);
            this.Controls.Add(this.lblMaxTime);
            this.Controls.Add(this.lblRegularTimeH);
            this.Controls.Add(this.nmcRegularTime);
            this.Controls.Add(this.lblRegularTime);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ClockIn.Properties.Settings.Default, "OptionsDialogLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = global::ClockIn.Properties.Settings.Default.OptionsDialogLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionsDialog_FormClosed);
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.grpStartup.ResumeLayout(false);
            this.grpStartup.PerformLayout();
            this.grpBreaksPeriod.ResumeLayout(false);
            this.grpBreaksPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyAdvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcRegularTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreaksDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegularTime;
        private System.Windows.Forms.Label lblRegularTimeH;
        private System.Windows.Forms.Label lblMaxTime;
        private System.Windows.Forms.Label lblMaxTimeH;
        private System.Windows.Forms.CheckBox cbxNotifyRegularTime;
        private System.Windows.Forms.CheckBox cbxNotifyMaxTime;
        private System.Windows.Forms.Label lblMinBefore;
        private System.Windows.Forms.CheckBox cbxPlaySound;
        private System.Windows.Forms.Button btnSelectSound;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBreak;
        private System.Windows.Forms.Label lblBreakMin;
        private System.Windows.Forms.GroupBox grpStartup;
        private System.Windows.Forms.RadioButton rbtQueryStartBehavior;
        private System.Windows.Forms.RadioButton rbtContinueSession;
        private System.Windows.Forms.RadioButton rbtNewSession;
        private System.Windows.Forms.NumericUpDown nmcRegularTime;
        private System.Windows.Forms.NumericUpDown nmcMaxTime;
        private System.Windows.Forms.NumericUpDown nmcBreak;
        private System.Windows.Forms.NumericUpDown nmcNotifyAdvance;
        private System.Windows.Forms.CheckBox cbxLowPowerIsStart;
        private System.Windows.Forms.DateTimePicker dtpBreaksBegin;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblBreaks;
        private System.Windows.Forms.NumericUpDown nmcBreaksDuration;
        private System.Windows.Forms.Label lblBreaksMin;
        private System.Windows.Forms.GroupBox grpBreaksPeriod;
        private System.Windows.Forms.Label lblBreaksBegin;
        private System.Windows.Forms.Label lblBreaksEnd;
        private System.Windows.Forms.DateTimePicker dtpBreaksEnd;
        private System.Windows.Forms.OpenFileDialog dlgSelectSound;
        private System.Windows.Forms.Label lblSoundFile;
        private System.Windows.Forms.CheckBox cbxAutoLaunch;
        private System.Windows.Forms.CheckBox cbxNotificationAlwayOnTop;
        private System.Windows.Forms.Label lblHotkey;
        private HotkeyControl txtHotkey;
    }
}