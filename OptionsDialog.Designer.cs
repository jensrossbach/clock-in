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
            this.lblMinBeforeMax = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpLastSession = new System.Windows.Forms.GroupBox();
            this.rbtQueryStartBehavior = new System.Windows.Forms.RadioButton();
            this.rbtContinueSession = new System.Windows.Forms.RadioButton();
            this.rbtNewSession = new System.Windows.Forms.RadioButton();
            this.cbxAutoLaunch = new System.Windows.Forms.CheckBox();
            this.cbxLowPowerIsStart = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblBreaks = new System.Windows.Forms.Label();
            this.lblBreaksMin = new System.Windows.Forms.Label();
            this.grpBreaksPeriod = new System.Windows.Forms.GroupBox();
            this.lblBreakMin = new System.Windows.Forms.Label();
            this.lblBreak = new System.Windows.Forms.Label();
            this.nmcBreak = new System.Windows.Forms.NumericUpDown();
            this.dtpBreaksEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBreaksEnd = new System.Windows.Forms.Label();
            this.lblBreaksBegin = new System.Windows.Forms.Label();
            this.dtpBreaksBegin = new System.Windows.Forms.DateTimePicker();
            this.lblAdder2Min = new System.Windows.Forms.Label();
            this.nmcAdder2 = new System.Windows.Forms.NumericUpDown();
            this.lblAdder1Min = new System.Windows.Forms.Label();
            this.lblAdder2 = new System.Windows.Forms.Label();
            this.nmcWorkspan2 = new System.Windows.Forms.NumericUpDown();
            this.lblWorkspan2H = new System.Windows.Forms.Label();
            this.lblWorkspan2 = new System.Windows.Forms.Label();
            this.lblWorkSpan1H = new System.Windows.Forms.Label();
            this.lblAdder1 = new System.Windows.Forms.Label();
            this.nmcAdder1 = new System.Windows.Forms.NumericUpDown();
            this.nmcWorkspan1 = new System.Windows.Forms.NumericUpDown();
            this.lblWorkspan1 = new System.Windows.Forms.Label();
            this.btnSelectSound = new System.Windows.Forms.Button();
            this.cbxPlaySound = new System.Windows.Forms.CheckBox();
            this.nmcNotifyMaxAdvance = new System.Windows.Forms.NumericUpDown();
            this.cbxNotifyMaxTime = new System.Windows.Forms.CheckBox();
            this.cbxNotifyRegularTime = new System.Windows.Forms.CheckBox();
            this.nmcMaxTime = new System.Windows.Forms.NumericUpDown();
            this.nmcRegularTime = new System.Windows.Forms.NumericUpDown();
            this.nmcBreaksDuration = new System.Windows.Forms.NumericUpDown();
            this.dlgSelectSound = new System.Windows.Forms.OpenFileDialog();
            this.lblSoundFile = new System.Windows.Forms.Label();
            this.cbxNotificationAlwayOnTop = new System.Windows.Forms.CheckBox();
            this.lblHotkey = new System.Windows.Forms.Label();
            this.tbcOptions = new System.Windows.Forms.TabControl();
            this.tbpTimePeriods = new System.Windows.Forms.TabPage();
            this.grpOtherPeriod = new System.Windows.Forms.GroupBox();
            this.tbpNotifications = new System.Windows.Forms.TabPage();
            this.lblMinBeforeReg = new System.Windows.Forms.Label();
            this.nmcNotifyRegAdvance = new System.Windows.Forms.NumericUpDown();
            this.tbpMisc = new System.Windows.Forms.TabPage();
            this.cbxFlatIcon = new System.Windows.Forms.CheckBox();
            this.cbxMinimized = new System.Windows.Forms.CheckBox();
            this.lblOffsetMinutes = new System.Windows.Forms.Label();
            this.nmcArrivalTimeOffset = new System.Windows.Forms.NumericUpDown();
            this.lblArrivalTimeOffset = new System.Windows.Forms.Label();
            this.grpAbsence = new System.Windows.Forms.GroupBox();
            this.cbxClockInAtWakeup = new System.Windows.Forms.CheckBox();
            this.cbxClockInAtStart = new System.Windows.Forms.CheckBox();
            this.txtHotkey = new ClockIn.HotkeyControl();
            this.grpLastSession.SuspendLayout();
            this.grpBreaksPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcAdder2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcWorkspan2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcAdder1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcWorkspan1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyMaxAdvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcRegularTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreaksDuration)).BeginInit();
            this.tbcOptions.SuspendLayout();
            this.tbpTimePeriods.SuspendLayout();
            this.grpOtherPeriod.SuspendLayout();
            this.tbpNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyRegAdvance)).BeginInit();
            this.tbpMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcArrivalTimeOffset)).BeginInit();
            this.grpAbsence.SuspendLayout();
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
            // lblMinBeforeMax
            // 
            resources.ApplyResources(this.lblMinBeforeMax, "lblMinBeforeMax");
            this.lblMinBeforeMax.Name = "lblMinBeforeMax";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // grpLastSession
            // 
            this.grpLastSession.Controls.Add(this.rbtQueryStartBehavior);
            this.grpLastSession.Controls.Add(this.rbtContinueSession);
            this.grpLastSession.Controls.Add(this.rbtNewSession);
            resources.ApplyResources(this.grpLastSession, "grpLastSession");
            this.grpLastSession.Name = "grpLastSession";
            this.grpLastSession.TabStop = false;
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
            this.grpBreaksPeriod.Controls.Add(this.lblBreakMin);
            this.grpBreaksPeriod.Controls.Add(this.lblBreak);
            this.grpBreaksPeriod.Controls.Add(this.nmcBreak);
            this.grpBreaksPeriod.Controls.Add(this.dtpBreaksEnd);
            this.grpBreaksPeriod.Controls.Add(this.lblBreaksEnd);
            this.grpBreaksPeriod.Controls.Add(this.lblBreaksBegin);
            this.grpBreaksPeriod.Controls.Add(this.dtpBreaksBegin);
            resources.ApplyResources(this.grpBreaksPeriod, "grpBreaksPeriod");
            this.grpBreaksPeriod.Name = "grpBreaksPeriod";
            this.grpBreaksPeriod.TabStop = false;
            // 
            // lblBreakMin
            // 
            resources.ApplyResources(this.lblBreakMin, "lblBreakMin");
            this.lblBreakMin.Name = "lblBreakMin";
            // 
            // lblBreak
            // 
            resources.ApplyResources(this.lblBreak, "lblBreak");
            this.lblBreak.Name = "lblBreak";
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
            this.nmcBreak.Validating += new System.ComponentModel.CancelEventHandler(this.NmcBreak_Validating);
            // 
            // dtpBreaksEnd
            // 
            resources.ApplyResources(this.dtpBreaksEnd, "dtpBreaksEnd");
            this.dtpBreaksEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "BreaksEnd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpBreaksEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBreaksEnd.Name = "dtpBreaksEnd";
            this.dtpBreaksEnd.ShowUpDown = true;
            this.dtpBreaksEnd.Value = global::ClockIn.Properties.Settings.Default.BreaksEnd;
            this.dtpBreaksEnd.Validating += new System.ComponentModel.CancelEventHandler(this.DtpBreaksEnd_Validating);
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
            this.dtpBreaksBegin.Validating += new System.ComponentModel.CancelEventHandler(this.DtpBreaksBegin_Validating);
            // 
            // lblAdder2Min
            // 
            resources.ApplyResources(this.lblAdder2Min, "lblAdder2Min");
            this.lblAdder2Min.Name = "lblAdder2Min";
            // 
            // nmcAdder2
            // 
            this.nmcAdder2.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchBreak2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcAdder2, "nmcAdder2");
            this.nmcAdder2.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nmcAdder2.Name = "nmcAdder2";
            this.nmcAdder2.Value = global::ClockIn.Properties.Settings.Default.OutsideLunchBreak2;
            this.nmcAdder2.Validating += new System.ComponentModel.CancelEventHandler(this.NmcAdder2_Validating);
            // 
            // lblAdder1Min
            // 
            resources.ApplyResources(this.lblAdder1Min, "lblAdder1Min");
            this.lblAdder1Min.Name = "lblAdder1Min";
            // 
            // lblAdder2
            // 
            resources.ApplyResources(this.lblAdder2, "lblAdder2");
            this.lblAdder2.Name = "lblAdder2";
            // 
            // nmcWorkspan2
            // 
            this.nmcWorkspan2.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchWorkspan2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcWorkspan2.DecimalPlaces = 1;
            this.nmcWorkspan2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            resources.ApplyResources(this.nmcWorkspan2, "nmcWorkspan2");
            this.nmcWorkspan2.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmcWorkspan2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmcWorkspan2.Name = "nmcWorkspan2";
            this.nmcWorkspan2.Value = global::ClockIn.Properties.Settings.Default.OutsideLunchWorkspan2;
            this.nmcWorkspan2.Validating += new System.ComponentModel.CancelEventHandler(this.NmcWorkspan2_Validating);
            // 
            // lblWorkspan2H
            // 
            resources.ApplyResources(this.lblWorkspan2H, "lblWorkspan2H");
            this.lblWorkspan2H.Name = "lblWorkspan2H";
            // 
            // lblWorkspan2
            // 
            resources.ApplyResources(this.lblWorkspan2, "lblWorkspan2");
            this.lblWorkspan2.Name = "lblWorkspan2";
            // 
            // lblWorkSpan1H
            // 
            resources.ApplyResources(this.lblWorkSpan1H, "lblWorkSpan1H");
            this.lblWorkSpan1H.Name = "lblWorkSpan1H";
            // 
            // lblAdder1
            // 
            resources.ApplyResources(this.lblAdder1, "lblAdder1");
            this.lblAdder1.Name = "lblAdder1";
            // 
            // nmcAdder1
            // 
            this.nmcAdder1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchBreak1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcAdder1, "nmcAdder1");
            this.nmcAdder1.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nmcAdder1.Name = "nmcAdder1";
            this.nmcAdder1.Value = global::ClockIn.Properties.Settings.Default.OutsideLunchBreak1;
            this.nmcAdder1.Validating += new System.ComponentModel.CancelEventHandler(this.NmcAdder1_Validating);
            // 
            // nmcWorkspan1
            // 
            this.nmcWorkspan1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchWorkspan1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcWorkspan1.DecimalPlaces = 1;
            this.nmcWorkspan1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            resources.ApplyResources(this.nmcWorkspan1, "nmcWorkspan1");
            this.nmcWorkspan1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmcWorkspan1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmcWorkspan1.Name = "nmcWorkspan1";
            this.nmcWorkspan1.Value = global::ClockIn.Properties.Settings.Default.OutsideLunchWorkspan1;
            this.nmcWorkspan1.Validating += new System.ComponentModel.CancelEventHandler(this.NmcWorkspan1_Validating);
            // 
            // lblWorkspan1
            // 
            resources.ApplyResources(this.lblWorkspan1, "lblWorkspan1");
            this.lblWorkspan1.Name = "lblWorkspan1";
            // 
            // btnSelectSound
            // 
            this.btnSelectSound.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::ClockIn.Properties.Settings.Default, "PlaySound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnSelectSound.Enabled = global::ClockIn.Properties.Settings.Default.PlaySound;
            resources.ApplyResources(this.btnSelectSound, "btnSelectSound");
            this.btnSelectSound.Name = "btnSelectSound";
            this.btnSelectSound.UseVisualStyleBackColor = true;
            this.btnSelectSound.Click += new System.EventHandler(this.BtnSelectSound_Click);
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
            // nmcNotifyMaxAdvance
            // 
            this.nmcNotifyMaxAdvance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "NotifyAdvance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcNotifyMaxAdvance, "nmcNotifyMaxAdvance");
            this.nmcNotifyMaxAdvance.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmcNotifyMaxAdvance.Name = "nmcNotifyMaxAdvance";
            this.nmcNotifyMaxAdvance.Value = global::ClockIn.Properties.Settings.Default.NotifyAdvance;
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
            this.nmcMaxTime.Validating += new System.ComponentModel.CancelEventHandler(this.NmcMaxTime_Validating);
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
            this.nmcRegularTime.Validating += new System.ComponentModel.CancelEventHandler(this.NmcRegularTime_Validating);
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
            // tbcOptions
            // 
            this.tbcOptions.Controls.Add(this.tbpTimePeriods);
            this.tbcOptions.Controls.Add(this.tbpNotifications);
            this.tbcOptions.Controls.Add(this.tbpMisc);
            resources.ApplyResources(this.tbcOptions, "tbcOptions");
            this.tbcOptions.Name = "tbcOptions";
            this.tbcOptions.SelectedIndex = 0;
            // 
            // tbpTimePeriods
            // 
            this.tbpTimePeriods.Controls.Add(this.lblRegularTimeH);
            this.tbpTimePeriods.Controls.Add(this.grpBreaksPeriod);
            this.tbpTimePeriods.Controls.Add(this.lblRegularTime);
            this.tbpTimePeriods.Controls.Add(this.nmcRegularTime);
            this.tbpTimePeriods.Controls.Add(this.lblMaxTime);
            this.tbpTimePeriods.Controls.Add(this.nmcMaxTime);
            this.tbpTimePeriods.Controls.Add(this.lblMaxTimeH);
            this.tbpTimePeriods.Controls.Add(this.grpOtherPeriod);
            resources.ApplyResources(this.tbpTimePeriods, "tbpTimePeriods");
            this.tbpTimePeriods.Name = "tbpTimePeriods";
            this.tbpTimePeriods.UseVisualStyleBackColor = true;
            // 
            // grpOtherPeriod
            // 
            this.grpOtherPeriod.Controls.Add(this.lblAdder2Min);
            this.grpOtherPeriod.Controls.Add(this.nmcAdder1);
            this.grpOtherPeriod.Controls.Add(this.lblAdder1Min);
            this.grpOtherPeriod.Controls.Add(this.nmcAdder2);
            this.grpOtherPeriod.Controls.Add(this.lblAdder2);
            this.grpOtherPeriod.Controls.Add(this.lblWorkSpan1H);
            this.grpOtherPeriod.Controls.Add(this.lblWorkspan2H);
            this.grpOtherPeriod.Controls.Add(this.lblWorkspan2);
            this.grpOtherPeriod.Controls.Add(this.lblWorkspan1);
            this.grpOtherPeriod.Controls.Add(this.nmcWorkspan1);
            this.grpOtherPeriod.Controls.Add(this.nmcWorkspan2);
            this.grpOtherPeriod.Controls.Add(this.lblAdder1);
            resources.ApplyResources(this.grpOtherPeriod, "grpOtherPeriod");
            this.grpOtherPeriod.Name = "grpOtherPeriod";
            this.grpOtherPeriod.TabStop = false;
            // 
            // tbpNotifications
            // 
            this.tbpNotifications.Controls.Add(this.lblMinBeforeReg);
            this.tbpNotifications.Controls.Add(this.nmcNotifyRegAdvance);
            this.tbpNotifications.Controls.Add(this.cbxNotifyRegularTime);
            this.tbpNotifications.Controls.Add(this.cbxNotifyMaxTime);
            this.tbpNotifications.Controls.Add(this.lblHotkey);
            this.tbpNotifications.Controls.Add(this.nmcNotifyMaxAdvance);
            this.tbpNotifications.Controls.Add(this.cbxNotificationAlwayOnTop);
            this.tbpNotifications.Controls.Add(this.lblMinBeforeMax);
            this.tbpNotifications.Controls.Add(this.lblSoundFile);
            this.tbpNotifications.Controls.Add(this.cbxPlaySound);
            this.tbpNotifications.Controls.Add(this.btnSelectSound);
            this.tbpNotifications.Controls.Add(this.txtHotkey);
            resources.ApplyResources(this.tbpNotifications, "tbpNotifications");
            this.tbpNotifications.Name = "tbpNotifications";
            this.tbpNotifications.UseVisualStyleBackColor = true;
            // 
            // lblMinBeforeReg
            // 
            resources.ApplyResources(this.lblMinBeforeReg, "lblMinBeforeReg");
            this.lblMinBeforeReg.Name = "lblMinBeforeReg";
            // 
            // nmcNotifyRegAdvance
            // 
            this.nmcNotifyRegAdvance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "NotifyRegAdvance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcNotifyRegAdvance, "nmcNotifyRegAdvance");
            this.nmcNotifyRegAdvance.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmcNotifyRegAdvance.Name = "nmcNotifyRegAdvance";
            this.nmcNotifyRegAdvance.Value = global::ClockIn.Properties.Settings.Default.NotifyRegAdvance;
            // 
            // tbpMisc
            // 
            this.tbpMisc.Controls.Add(this.cbxFlatIcon);
            this.tbpMisc.Controls.Add(this.cbxMinimized);
            this.tbpMisc.Controls.Add(this.lblOffsetMinutes);
            this.tbpMisc.Controls.Add(this.nmcArrivalTimeOffset);
            this.tbpMisc.Controls.Add(this.lblArrivalTimeOffset);
            this.tbpMisc.Controls.Add(this.cbxAutoLaunch);
            this.tbpMisc.Controls.Add(this.grpLastSession);
            this.tbpMisc.Controls.Add(this.cbxLowPowerIsStart);
            this.tbpMisc.Controls.Add(this.grpAbsence);
            resources.ApplyResources(this.tbpMisc, "tbpMisc");
            this.tbpMisc.Name = "tbpMisc";
            this.tbpMisc.UseVisualStyleBackColor = true;
            // 
            // cbxFlatIcon
            // 
            resources.ApplyResources(this.cbxFlatIcon, "cbxFlatIcon");
            this.cbxFlatIcon.Checked = global::ClockIn.Properties.Settings.Default.FlatIconOnNewWindows;
            this.cbxFlatIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxFlatIcon.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "FlatIconOnNewWindows", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxFlatIcon.Name = "cbxFlatIcon";
            this.cbxFlatIcon.UseVisualStyleBackColor = true;
            // 
            // cbxMinimized
            // 
            resources.ApplyResources(this.cbxMinimized, "cbxMinimized");
            this.cbxMinimized.Checked = global::ClockIn.Properties.Settings.Default.StartMinimized;
            this.cbxMinimized.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "StartMinimized", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxMinimized.Name = "cbxMinimized";
            this.cbxMinimized.UseVisualStyleBackColor = true;
            // 
            // lblOffsetMinutes
            // 
            resources.ApplyResources(this.lblOffsetMinutes, "lblOffsetMinutes");
            this.lblOffsetMinutes.Name = "lblOffsetMinutes";
            // 
            // nmcArrivalTimeOffset
            // 
            this.nmcArrivalTimeOffset.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "ArrivalTimeOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcArrivalTimeOffset, "nmcArrivalTimeOffset");
            this.nmcArrivalTimeOffset.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nmcArrivalTimeOffset.Name = "nmcArrivalTimeOffset";
            this.nmcArrivalTimeOffset.Value = global::ClockIn.Properties.Settings.Default.ArrivalTimeOffset;
            // 
            // lblArrivalTimeOffset
            // 
            resources.ApplyResources(this.lblArrivalTimeOffset, "lblArrivalTimeOffset");
            this.lblArrivalTimeOffset.Name = "lblArrivalTimeOffset";
            // 
            // grpAbsence
            // 
            this.grpAbsence.Controls.Add(this.cbxClockInAtWakeup);
            this.grpAbsence.Controls.Add(this.cbxClockInAtStart);
            resources.ApplyResources(this.grpAbsence, "grpAbsence");
            this.grpAbsence.Name = "grpAbsence";
            this.grpAbsence.TabStop = false;
            // 
            // cbxClockInAtWakeup
            // 
            resources.ApplyResources(this.cbxClockInAtWakeup, "cbxClockInAtWakeup");
            this.cbxClockInAtWakeup.Checked = global::ClockIn.Properties.Settings.Default.ClockInAtWakeup;
            this.cbxClockInAtWakeup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxClockInAtWakeup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "ClockInAtWakeup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxClockInAtWakeup.Name = "cbxClockInAtWakeup";
            this.cbxClockInAtWakeup.UseVisualStyleBackColor = true;
            // 
            // cbxClockInAtStart
            // 
            resources.ApplyResources(this.cbxClockInAtStart, "cbxClockInAtStart");
            this.cbxClockInAtStart.Checked = global::ClockIn.Properties.Settings.Default.ClockInAtStart;
            this.cbxClockInAtStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxClockInAtStart.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "ClockInAtStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxClockInAtStart.Name = "cbxClockInAtStart";
            this.cbxClockInAtStart.UseVisualStyleBackColor = true;
            // 
            // txtHotkey
            // 
            this.txtHotkey.DataBindings.Add(new System.Windows.Forms.Binding("Hotkey", global::ClockIn.Properties.Settings.Default, "MainWindowHotkey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHotkey.Hotkey = global::ClockIn.Properties.Settings.Default.MainWindowHotkey;
            resources.ApplyResources(this.txtHotkey, "txtHotkey");
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.Enter += new System.EventHandler(this.TxtHotkey_Enter);
            this.txtHotkey.Leave += new System.EventHandler(this.TxtHotkey_Leave);
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbcOptions);
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
            this.grpLastSession.ResumeLayout(false);
            this.grpLastSession.PerformLayout();
            this.grpBreaksPeriod.ResumeLayout(false);
            this.grpBreaksPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcAdder2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcWorkspan2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcAdder1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcWorkspan1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyMaxAdvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcRegularTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreaksDuration)).EndInit();
            this.tbcOptions.ResumeLayout(false);
            this.tbpTimePeriods.ResumeLayout(false);
            this.tbpTimePeriods.PerformLayout();
            this.grpOtherPeriod.ResumeLayout(false);
            this.grpOtherPeriod.PerformLayout();
            this.tbpNotifications.ResumeLayout(false);
            this.tbpNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyRegAdvance)).EndInit();
            this.tbpMisc.ResumeLayout(false);
            this.tbpMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcArrivalTimeOffset)).EndInit();
            this.grpAbsence.ResumeLayout(false);
            this.grpAbsence.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRegularTime;
        private System.Windows.Forms.Label lblRegularTimeH;
        private System.Windows.Forms.Label lblMaxTime;
        private System.Windows.Forms.Label lblMaxTimeH;
        private System.Windows.Forms.CheckBox cbxNotifyRegularTime;
        private System.Windows.Forms.CheckBox cbxNotifyMaxTime;
        private System.Windows.Forms.Label lblMinBeforeMax;
        private System.Windows.Forms.CheckBox cbxPlaySound;
        private System.Windows.Forms.Button btnSelectSound;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpLastSession;
        private System.Windows.Forms.RadioButton rbtQueryStartBehavior;
        private System.Windows.Forms.RadioButton rbtContinueSession;
        private System.Windows.Forms.RadioButton rbtNewSession;
        private System.Windows.Forms.NumericUpDown nmcRegularTime;
        private System.Windows.Forms.NumericUpDown nmcMaxTime;
        private System.Windows.Forms.NumericUpDown nmcNotifyMaxAdvance;
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
        private System.Windows.Forms.TabControl tbcOptions;
        private System.Windows.Forms.TabPage tbpTimePeriods;
        private System.Windows.Forms.TabPage tbpNotifications;
        private System.Windows.Forms.TabPage tbpMisc;
        private System.Windows.Forms.Label lblAdder2Min;
        private System.Windows.Forms.Label lblAdder1Min;
        private System.Windows.Forms.NumericUpDown nmcAdder2;
        private System.Windows.Forms.Label lblAdder2;
        private System.Windows.Forms.Label lblWorkspan2H;
        private System.Windows.Forms.NumericUpDown nmcWorkspan2;
        private System.Windows.Forms.Label lblWorkspan2;
        private System.Windows.Forms.NumericUpDown nmcAdder1;
        private System.Windows.Forms.Label lblAdder1;
        private System.Windows.Forms.Label lblWorkSpan1H;
        private System.Windows.Forms.NumericUpDown nmcWorkspan1;
        private System.Windows.Forms.Label lblWorkspan1;
        private System.Windows.Forms.Label lblBreakMin;
        private System.Windows.Forms.Label lblBreak;
        private System.Windows.Forms.NumericUpDown nmcBreak;
        private System.Windows.Forms.GroupBox grpOtherPeriod;
        private System.Windows.Forms.NumericUpDown nmcArrivalTimeOffset;
        private System.Windows.Forms.Label lblArrivalTimeOffset;
        private System.Windows.Forms.Label lblOffsetMinutes;
        private System.Windows.Forms.CheckBox cbxMinimized;
        private System.Windows.Forms.Label lblMinBeforeReg;
        private System.Windows.Forms.NumericUpDown nmcNotifyRegAdvance;
        private System.Windows.Forms.CheckBox cbxFlatIcon;
        private System.Windows.Forms.CheckBox cbxClockInAtWakeup;
        private System.Windows.Forms.CheckBox cbxClockInAtStart;
        private System.Windows.Forms.GroupBox grpAbsence;
    }
}