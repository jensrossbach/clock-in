﻿namespace ClockIn
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
            this.components = new System.ComponentModel.Container();
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
            this.tbcOptions = new System.Windows.Forms.TabControl();
            this.tbpTimePeriods = new System.Windows.Forms.TabPage();
            this.grpOtherPeriod = new System.Windows.Forms.GroupBox();
            this.tbpNotifications = new System.Windows.Forms.TabPage();
            this.grpWorkingTime = new System.Windows.Forms.GroupBox();
            this.cbxSystemNotifications = new System.Windows.Forms.CheckBox();
            this.nmcNotifyRegAdvance = new System.Windows.Forms.NumericUpDown();
            this.lblMinBeforeReg = new System.Windows.Forms.Label();
            this.cbxNotifyOnClockInOut = new System.Windows.Forms.CheckBox();
            this.tbpMisc = new System.Windows.Forms.TabPage();
            this.cbxFlatIcon = new System.Windows.Forms.CheckBox();
            this.cbxMinimized = new System.Windows.Forms.CheckBox();
            this.lblOffsetMinutes = new System.Windows.Forms.Label();
            this.nmcArrivalTimeOffset = new System.Windows.Forms.NumericUpDown();
            this.lblArrivalTimeOffset = new System.Windows.Forms.Label();
            this.grpAbsence = new System.Windows.Forms.GroupBox();
            this.cbxConfirmOnClockIn = new System.Windows.Forms.CheckBox();
            this.cbxMinimizeOnClockOut = new System.Windows.Forms.CheckBox();
            this.cbxClockInAtWakeup = new System.Windows.Forms.CheckBox();
            this.cbxClockInAtStart = new System.Windows.Forms.CheckBox();
            this.btnHotkeys = new System.Windows.Forms.Button();
            this.erpValidation = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.grpWorkingTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyRegAdvance)).BeginInit();
            this.tbpMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcArrivalTimeOffset)).BeginInit();
            this.grpAbsence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegularTime
            // 
            resources.ApplyResources(this.lblRegularTime, "lblRegularTime");
            this.erpValidation.SetError(this.lblRegularTime, resources.GetString("lblRegularTime.Error"));
            this.erpValidation.SetIconAlignment(this.lblRegularTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblRegularTime.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblRegularTime, ((int)(resources.GetObject("lblRegularTime.IconPadding"))));
            this.lblRegularTime.Name = "lblRegularTime";
            // 
            // lblRegularTimeH
            // 
            resources.ApplyResources(this.lblRegularTimeH, "lblRegularTimeH");
            this.erpValidation.SetError(this.lblRegularTimeH, resources.GetString("lblRegularTimeH.Error"));
            this.erpValidation.SetIconAlignment(this.lblRegularTimeH, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblRegularTimeH.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblRegularTimeH, ((int)(resources.GetObject("lblRegularTimeH.IconPadding"))));
            this.lblRegularTimeH.Name = "lblRegularTimeH";
            // 
            // lblMaxTime
            // 
            resources.ApplyResources(this.lblMaxTime, "lblMaxTime");
            this.erpValidation.SetError(this.lblMaxTime, resources.GetString("lblMaxTime.Error"));
            this.erpValidation.SetIconAlignment(this.lblMaxTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblMaxTime.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblMaxTime, ((int)(resources.GetObject("lblMaxTime.IconPadding"))));
            this.lblMaxTime.Name = "lblMaxTime";
            // 
            // lblMaxTimeH
            // 
            resources.ApplyResources(this.lblMaxTimeH, "lblMaxTimeH");
            this.erpValidation.SetError(this.lblMaxTimeH, resources.GetString("lblMaxTimeH.Error"));
            this.erpValidation.SetIconAlignment(this.lblMaxTimeH, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblMaxTimeH.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblMaxTimeH, ((int)(resources.GetObject("lblMaxTimeH.IconPadding"))));
            this.lblMaxTimeH.Name = "lblMaxTimeH";
            // 
            // lblMinBeforeMax
            // 
            resources.ApplyResources(this.lblMinBeforeMax, "lblMinBeforeMax");
            this.erpValidation.SetError(this.lblMinBeforeMax, resources.GetString("lblMinBeforeMax.Error"));
            this.erpValidation.SetIconAlignment(this.lblMinBeforeMax, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblMinBeforeMax.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblMinBeforeMax, ((int)(resources.GetObject("lblMinBeforeMax.IconPadding"))));
            this.lblMinBeforeMax.Name = "lblMinBeforeMax";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.erpValidation.SetError(this.btnClose, resources.GetString("btnClose.Error"));
            this.erpValidation.SetIconAlignment(this.btnClose, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnClose.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.btnClose, ((int)(resources.GetObject("btnClose.IconPadding"))));
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // grpLastSession
            // 
            resources.ApplyResources(this.grpLastSession, "grpLastSession");
            this.grpLastSession.Controls.Add(this.rbtQueryStartBehavior);
            this.grpLastSession.Controls.Add(this.rbtContinueSession);
            this.grpLastSession.Controls.Add(this.rbtNewSession);
            this.erpValidation.SetError(this.grpLastSession, resources.GetString("grpLastSession.Error"));
            this.erpValidation.SetIconAlignment(this.grpLastSession, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpLastSession.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.grpLastSession, ((int)(resources.GetObject("grpLastSession.IconPadding"))));
            this.grpLastSession.Name = "grpLastSession";
            this.grpLastSession.TabStop = false;
            // 
            // rbtQueryStartBehavior
            // 
            resources.ApplyResources(this.rbtQueryStartBehavior, "rbtQueryStartBehavior");
            this.rbtQueryStartBehavior.Checked = true;
            this.erpValidation.SetError(this.rbtQueryStartBehavior, resources.GetString("rbtQueryStartBehavior.Error"));
            this.erpValidation.SetIconAlignment(this.rbtQueryStartBehavior, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rbtQueryStartBehavior.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.rbtQueryStartBehavior, ((int)(resources.GetObject("rbtQueryStartBehavior.IconPadding"))));
            this.rbtQueryStartBehavior.Name = "rbtQueryStartBehavior";
            this.rbtQueryStartBehavior.TabStop = true;
            this.rbtQueryStartBehavior.UseVisualStyleBackColor = true;
            // 
            // rbtContinueSession
            // 
            resources.ApplyResources(this.rbtContinueSession, "rbtContinueSession");
            this.erpValidation.SetError(this.rbtContinueSession, resources.GetString("rbtContinueSession.Error"));
            this.erpValidation.SetIconAlignment(this.rbtContinueSession, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rbtContinueSession.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.rbtContinueSession, ((int)(resources.GetObject("rbtContinueSession.IconPadding"))));
            this.rbtContinueSession.Name = "rbtContinueSession";
            this.rbtContinueSession.UseVisualStyleBackColor = true;
            // 
            // rbtNewSession
            // 
            resources.ApplyResources(this.rbtNewSession, "rbtNewSession");
            this.erpValidation.SetError(this.rbtNewSession, resources.GetString("rbtNewSession.Error"));
            this.erpValidation.SetIconAlignment(this.rbtNewSession, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rbtNewSession.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.rbtNewSession, ((int)(resources.GetObject("rbtNewSession.IconPadding"))));
            this.rbtNewSession.Name = "rbtNewSession";
            this.rbtNewSession.UseVisualStyleBackColor = true;
            // 
            // cbxAutoLaunch
            // 
            resources.ApplyResources(this.cbxAutoLaunch, "cbxAutoLaunch");
            this.erpValidation.SetError(this.cbxAutoLaunch, resources.GetString("cbxAutoLaunch.Error"));
            this.erpValidation.SetIconAlignment(this.cbxAutoLaunch, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxAutoLaunch.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxAutoLaunch, ((int)(resources.GetObject("cbxAutoLaunch.IconPadding"))));
            this.cbxAutoLaunch.Name = "cbxAutoLaunch";
            this.cbxAutoLaunch.UseVisualStyleBackColor = true;
            // 
            // cbxLowPowerIsStart
            // 
            resources.ApplyResources(this.cbxLowPowerIsStart, "cbxLowPowerIsStart");
            this.cbxLowPowerIsStart.Checked = global::ClockIn.Properties.Settings.Default.LowPowerIsStart;
            this.cbxLowPowerIsStart.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "LowPowerIsStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxLowPowerIsStart, resources.GetString("cbxLowPowerIsStart.Error"));
            this.erpValidation.SetIconAlignment(this.cbxLowPowerIsStart, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxLowPowerIsStart.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxLowPowerIsStart, ((int)(resources.GetObject("cbxLowPowerIsStart.IconPadding"))));
            this.cbxLowPowerIsStart.Name = "cbxLowPowerIsStart";
            this.cbxLowPowerIsStart.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.erpValidation.SetError(this.dateTimePicker1, resources.GetString("dateTimePicker1.Error"));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.erpValidation.SetIconAlignment(this.dateTimePicker1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dateTimePicker1.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.dateTimePicker1, ((int)(resources.GetObject("dateTimePicker1.IconPadding"))));
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            // 
            // lblBreaks
            // 
            resources.ApplyResources(this.lblBreaks, "lblBreaks");
            this.erpValidation.SetError(this.lblBreaks, resources.GetString("lblBreaks.Error"));
            this.erpValidation.SetIconAlignment(this.lblBreaks, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblBreaks.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblBreaks, ((int)(resources.GetObject("lblBreaks.IconPadding"))));
            this.lblBreaks.Name = "lblBreaks";
            // 
            // lblBreaksMin
            // 
            resources.ApplyResources(this.lblBreaksMin, "lblBreaksMin");
            this.erpValidation.SetError(this.lblBreaksMin, resources.GetString("lblBreaksMin.Error"));
            this.erpValidation.SetIconAlignment(this.lblBreaksMin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblBreaksMin.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblBreaksMin, ((int)(resources.GetObject("lblBreaksMin.IconPadding"))));
            this.lblBreaksMin.Name = "lblBreaksMin";
            // 
            // grpBreaksPeriod
            // 
            resources.ApplyResources(this.grpBreaksPeriod, "grpBreaksPeriod");
            this.grpBreaksPeriod.Controls.Add(this.lblBreakMin);
            this.grpBreaksPeriod.Controls.Add(this.lblBreak);
            this.grpBreaksPeriod.Controls.Add(this.nmcBreak);
            this.grpBreaksPeriod.Controls.Add(this.dtpBreaksEnd);
            this.grpBreaksPeriod.Controls.Add(this.lblBreaksEnd);
            this.grpBreaksPeriod.Controls.Add(this.lblBreaksBegin);
            this.grpBreaksPeriod.Controls.Add(this.dtpBreaksBegin);
            this.erpValidation.SetError(this.grpBreaksPeriod, resources.GetString("grpBreaksPeriod.Error"));
            this.erpValidation.SetIconAlignment(this.grpBreaksPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpBreaksPeriod.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.grpBreaksPeriod, ((int)(resources.GetObject("grpBreaksPeriod.IconPadding"))));
            this.grpBreaksPeriod.Name = "grpBreaksPeriod";
            this.grpBreaksPeriod.TabStop = false;
            // 
            // lblBreakMin
            // 
            resources.ApplyResources(this.lblBreakMin, "lblBreakMin");
            this.erpValidation.SetError(this.lblBreakMin, resources.GetString("lblBreakMin.Error"));
            this.erpValidation.SetIconAlignment(this.lblBreakMin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblBreakMin.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblBreakMin, ((int)(resources.GetObject("lblBreakMin.IconPadding"))));
            this.lblBreakMin.Name = "lblBreakMin";
            // 
            // lblBreak
            // 
            resources.ApplyResources(this.lblBreak, "lblBreak");
            this.erpValidation.SetError(this.lblBreak, resources.GetString("lblBreak.Error"));
            this.erpValidation.SetIconAlignment(this.lblBreak, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblBreak.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblBreak, ((int)(resources.GetObject("lblBreak.IconPadding"))));
            this.lblBreak.Name = "lblBreak";
            // 
            // nmcBreak
            // 
            resources.ApplyResources(this.nmcBreak, "nmcBreak");
            this.nmcBreak.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "Break", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.nmcBreak, resources.GetString("nmcBreak.Error"));
            this.erpValidation.SetIconAlignment(this.nmcBreak, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcBreak.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcBreak, ((int)(resources.GetObject("nmcBreak.IconPadding"))));
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
            this.erpValidation.SetError(this.dtpBreaksEnd, resources.GetString("dtpBreaksEnd.Error"));
            this.dtpBreaksEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.erpValidation.SetIconAlignment(this.dtpBreaksEnd, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dtpBreaksEnd.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.dtpBreaksEnd, ((int)(resources.GetObject("dtpBreaksEnd.IconPadding"))));
            this.dtpBreaksEnd.Name = "dtpBreaksEnd";
            this.dtpBreaksEnd.ShowUpDown = true;
            this.dtpBreaksEnd.Value = global::ClockIn.Properties.Settings.Default.BreaksEnd;
            this.dtpBreaksEnd.Validating += new System.ComponentModel.CancelEventHandler(this.DtpBreaksEnd_Validating);
            // 
            // lblBreaksEnd
            // 
            resources.ApplyResources(this.lblBreaksEnd, "lblBreaksEnd");
            this.erpValidation.SetError(this.lblBreaksEnd, resources.GetString("lblBreaksEnd.Error"));
            this.erpValidation.SetIconAlignment(this.lblBreaksEnd, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblBreaksEnd.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblBreaksEnd, ((int)(resources.GetObject("lblBreaksEnd.IconPadding"))));
            this.lblBreaksEnd.Name = "lblBreaksEnd";
            // 
            // lblBreaksBegin
            // 
            resources.ApplyResources(this.lblBreaksBegin, "lblBreaksBegin");
            this.erpValidation.SetError(this.lblBreaksBegin, resources.GetString("lblBreaksBegin.Error"));
            this.erpValidation.SetIconAlignment(this.lblBreaksBegin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblBreaksBegin.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblBreaksBegin, ((int)(resources.GetObject("lblBreaksBegin.IconPadding"))));
            this.lblBreaksBegin.Name = "lblBreaksBegin";
            // 
            // dtpBreaksBegin
            // 
            resources.ApplyResources(this.dtpBreaksBegin, "dtpBreaksBegin");
            this.dtpBreaksBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "BreaksBegin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.dtpBreaksBegin, resources.GetString("dtpBreaksBegin.Error"));
            this.dtpBreaksBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.erpValidation.SetIconAlignment(this.dtpBreaksBegin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("dtpBreaksBegin.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.dtpBreaksBegin, ((int)(resources.GetObject("dtpBreaksBegin.IconPadding"))));
            this.dtpBreaksBegin.Name = "dtpBreaksBegin";
            this.dtpBreaksBegin.ShowUpDown = true;
            this.dtpBreaksBegin.Value = global::ClockIn.Properties.Settings.Default.BreaksBegin;
            this.dtpBreaksBegin.Validating += new System.ComponentModel.CancelEventHandler(this.DtpBreaksBegin_Validating);
            // 
            // lblAdder2Min
            // 
            resources.ApplyResources(this.lblAdder2Min, "lblAdder2Min");
            this.erpValidation.SetError(this.lblAdder2Min, resources.GetString("lblAdder2Min.Error"));
            this.erpValidation.SetIconAlignment(this.lblAdder2Min, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblAdder2Min.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblAdder2Min, ((int)(resources.GetObject("lblAdder2Min.IconPadding"))));
            this.lblAdder2Min.Name = "lblAdder2Min";
            // 
            // nmcAdder2
            // 
            resources.ApplyResources(this.nmcAdder2, "nmcAdder2");
            this.nmcAdder2.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchBreak2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.nmcAdder2, resources.GetString("nmcAdder2.Error"));
            this.erpValidation.SetIconAlignment(this.nmcAdder2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcAdder2.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcAdder2, ((int)(resources.GetObject("nmcAdder2.IconPadding"))));
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
            this.erpValidation.SetError(this.lblAdder1Min, resources.GetString("lblAdder1Min.Error"));
            this.erpValidation.SetIconAlignment(this.lblAdder1Min, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblAdder1Min.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblAdder1Min, ((int)(resources.GetObject("lblAdder1Min.IconPadding"))));
            this.lblAdder1Min.Name = "lblAdder1Min";
            // 
            // lblAdder2
            // 
            resources.ApplyResources(this.lblAdder2, "lblAdder2");
            this.erpValidation.SetError(this.lblAdder2, resources.GetString("lblAdder2.Error"));
            this.erpValidation.SetIconAlignment(this.lblAdder2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblAdder2.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblAdder2, ((int)(resources.GetObject("lblAdder2.IconPadding"))));
            this.lblAdder2.Name = "lblAdder2";
            // 
            // nmcWorkspan2
            // 
            resources.ApplyResources(this.nmcWorkspan2, "nmcWorkspan2");
            this.nmcWorkspan2.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchWorkspan2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcWorkspan2.DecimalPlaces = 1;
            this.erpValidation.SetError(this.nmcWorkspan2, resources.GetString("nmcWorkspan2.Error"));
            this.erpValidation.SetIconAlignment(this.nmcWorkspan2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcWorkspan2.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcWorkspan2, ((int)(resources.GetObject("nmcWorkspan2.IconPadding"))));
            this.nmcWorkspan2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            this.erpValidation.SetError(this.lblWorkspan2H, resources.GetString("lblWorkspan2H.Error"));
            this.erpValidation.SetIconAlignment(this.lblWorkspan2H, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblWorkspan2H.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblWorkspan2H, ((int)(resources.GetObject("lblWorkspan2H.IconPadding"))));
            this.lblWorkspan2H.Name = "lblWorkspan2H";
            // 
            // lblWorkspan2
            // 
            resources.ApplyResources(this.lblWorkspan2, "lblWorkspan2");
            this.erpValidation.SetError(this.lblWorkspan2, resources.GetString("lblWorkspan2.Error"));
            this.erpValidation.SetIconAlignment(this.lblWorkspan2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblWorkspan2.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblWorkspan2, ((int)(resources.GetObject("lblWorkspan2.IconPadding"))));
            this.lblWorkspan2.Name = "lblWorkspan2";
            // 
            // lblWorkSpan1H
            // 
            resources.ApplyResources(this.lblWorkSpan1H, "lblWorkSpan1H");
            this.erpValidation.SetError(this.lblWorkSpan1H, resources.GetString("lblWorkSpan1H.Error"));
            this.erpValidation.SetIconAlignment(this.lblWorkSpan1H, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblWorkSpan1H.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblWorkSpan1H, ((int)(resources.GetObject("lblWorkSpan1H.IconPadding"))));
            this.lblWorkSpan1H.Name = "lblWorkSpan1H";
            // 
            // lblAdder1
            // 
            resources.ApplyResources(this.lblAdder1, "lblAdder1");
            this.erpValidation.SetError(this.lblAdder1, resources.GetString("lblAdder1.Error"));
            this.erpValidation.SetIconAlignment(this.lblAdder1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblAdder1.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblAdder1, ((int)(resources.GetObject("lblAdder1.IconPadding"))));
            this.lblAdder1.Name = "lblAdder1";
            // 
            // nmcAdder1
            // 
            resources.ApplyResources(this.nmcAdder1, "nmcAdder1");
            this.nmcAdder1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchBreak1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.nmcAdder1, resources.GetString("nmcAdder1.Error"));
            this.erpValidation.SetIconAlignment(this.nmcAdder1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcAdder1.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcAdder1, ((int)(resources.GetObject("nmcAdder1.IconPadding"))));
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
            resources.ApplyResources(this.nmcWorkspan1, "nmcWorkspan1");
            this.nmcWorkspan1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "OutsideLunchWorkspan1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcWorkspan1.DecimalPlaces = 1;
            this.erpValidation.SetError(this.nmcWorkspan1, resources.GetString("nmcWorkspan1.Error"));
            this.erpValidation.SetIconAlignment(this.nmcWorkspan1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcWorkspan1.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcWorkspan1, ((int)(resources.GetObject("nmcWorkspan1.IconPadding"))));
            this.nmcWorkspan1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            this.erpValidation.SetError(this.lblWorkspan1, resources.GetString("lblWorkspan1.Error"));
            this.erpValidation.SetIconAlignment(this.lblWorkspan1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblWorkspan1.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblWorkspan1, ((int)(resources.GetObject("lblWorkspan1.IconPadding"))));
            this.lblWorkspan1.Name = "lblWorkspan1";
            // 
            // btnSelectSound
            // 
            resources.ApplyResources(this.btnSelectSound, "btnSelectSound");
            this.erpValidation.SetError(this.btnSelectSound, resources.GetString("btnSelectSound.Error"));
            this.erpValidation.SetIconAlignment(this.btnSelectSound, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnSelectSound.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.btnSelectSound, ((int)(resources.GetObject("btnSelectSound.IconPadding"))));
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
            this.erpValidation.SetError(this.cbxPlaySound, resources.GetString("cbxPlaySound.Error"));
            this.erpValidation.SetIconAlignment(this.cbxPlaySound, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxPlaySound.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxPlaySound, ((int)(resources.GetObject("cbxPlaySound.IconPadding"))));
            this.cbxPlaySound.Name = "cbxPlaySound";
            this.cbxPlaySound.UseVisualStyleBackColor = true;
            // 
            // nmcNotifyMaxAdvance
            // 
            resources.ApplyResources(this.nmcNotifyMaxAdvance, "nmcNotifyMaxAdvance");
            this.nmcNotifyMaxAdvance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "NotifyAdvance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.nmcNotifyMaxAdvance, resources.GetString("nmcNotifyMaxAdvance.Error"));
            this.erpValidation.SetIconAlignment(this.nmcNotifyMaxAdvance, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcNotifyMaxAdvance.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcNotifyMaxAdvance, ((int)(resources.GetObject("nmcNotifyMaxAdvance.IconPadding"))));
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
            this.erpValidation.SetError(this.cbxNotifyMaxTime, resources.GetString("cbxNotifyMaxTime.Error"));
            this.erpValidation.SetIconAlignment(this.cbxNotifyMaxTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxNotifyMaxTime.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxNotifyMaxTime, ((int)(resources.GetObject("cbxNotifyMaxTime.IconPadding"))));
            this.cbxNotifyMaxTime.Name = "cbxNotifyMaxTime";
            this.cbxNotifyMaxTime.UseVisualStyleBackColor = true;
            // 
            // cbxNotifyRegularTime
            // 
            resources.ApplyResources(this.cbxNotifyRegularTime, "cbxNotifyRegularTime");
            this.cbxNotifyRegularTime.Checked = global::ClockIn.Properties.Settings.Default.NotifyOnRegularLimit;
            this.cbxNotifyRegularTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNotifyRegularTime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "NotifyOnRegularLimit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxNotifyRegularTime, resources.GetString("cbxNotifyRegularTime.Error"));
            this.erpValidation.SetIconAlignment(this.cbxNotifyRegularTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxNotifyRegularTime.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxNotifyRegularTime, ((int)(resources.GetObject("cbxNotifyRegularTime.IconPadding"))));
            this.cbxNotifyRegularTime.Name = "cbxNotifyRegularTime";
            this.cbxNotifyRegularTime.UseVisualStyleBackColor = true;
            // 
            // nmcMaxTime
            // 
            resources.ApplyResources(this.nmcMaxTime, "nmcMaxTime");
            this.nmcMaxTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "MaximumWorkingTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcMaxTime.DecimalPlaces = 1;
            this.erpValidation.SetError(this.nmcMaxTime, resources.GetString("nmcMaxTime.Error"));
            this.erpValidation.SetIconAlignment(this.nmcMaxTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcMaxTime.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcMaxTime, ((int)(resources.GetObject("nmcMaxTime.IconPadding"))));
            this.nmcMaxTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            resources.ApplyResources(this.nmcRegularTime, "nmcRegularTime");
            this.nmcRegularTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "RegularWorkingTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nmcRegularTime.DecimalPlaces = 1;
            this.erpValidation.SetError(this.nmcRegularTime, resources.GetString("nmcRegularTime.Error"));
            this.erpValidation.SetIconAlignment(this.nmcRegularTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcRegularTime.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcRegularTime, ((int)(resources.GetObject("nmcRegularTime.IconPadding"))));
            this.nmcRegularTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
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
            resources.ApplyResources(this.nmcBreaksDuration, "nmcBreaksDuration");
            this.nmcBreaksDuration.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "BreaksDuration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.nmcBreaksDuration, resources.GetString("nmcBreaksDuration.Error"));
            this.erpValidation.SetIconAlignment(this.nmcBreaksDuration, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcBreaksDuration.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcBreaksDuration, ((int)(resources.GetObject("nmcBreaksDuration.IconPadding"))));
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
            this.lblSoundFile.AutoEllipsis = true;
            this.erpValidation.SetError(this.lblSoundFile, resources.GetString("lblSoundFile.Error"));
            this.erpValidation.SetIconAlignment(this.lblSoundFile, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblSoundFile.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblSoundFile, ((int)(resources.GetObject("lblSoundFile.IconPadding"))));
            this.lblSoundFile.Name = "lblSoundFile";
            // 
            // cbxNotificationAlwayOnTop
            // 
            resources.ApplyResources(this.cbxNotificationAlwayOnTop, "cbxNotificationAlwayOnTop");
            this.cbxNotificationAlwayOnTop.Checked = global::ClockIn.Properties.Settings.Default.NotificationAlwaysOnTop;
            this.cbxNotificationAlwayOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNotificationAlwayOnTop.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "NotificationAlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxNotificationAlwayOnTop, resources.GetString("cbxNotificationAlwayOnTop.Error"));
            this.erpValidation.SetIconAlignment(this.cbxNotificationAlwayOnTop, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxNotificationAlwayOnTop.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxNotificationAlwayOnTop, ((int)(resources.GetObject("cbxNotificationAlwayOnTop.IconPadding"))));
            this.cbxNotificationAlwayOnTop.Name = "cbxNotificationAlwayOnTop";
            this.cbxNotificationAlwayOnTop.UseVisualStyleBackColor = true;
            // 
            // tbcOptions
            // 
            resources.ApplyResources(this.tbcOptions, "tbcOptions");
            this.tbcOptions.Controls.Add(this.tbpTimePeriods);
            this.tbcOptions.Controls.Add(this.tbpNotifications);
            this.tbcOptions.Controls.Add(this.tbpMisc);
            this.erpValidation.SetError(this.tbcOptions, resources.GetString("tbcOptions.Error"));
            this.erpValidation.SetIconAlignment(this.tbcOptions, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbcOptions.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.tbcOptions, ((int)(resources.GetObject("tbcOptions.IconPadding"))));
            this.tbcOptions.Name = "tbcOptions";
            this.tbcOptions.SelectedIndex = 0;
            // 
            // tbpTimePeriods
            // 
            resources.ApplyResources(this.tbpTimePeriods, "tbpTimePeriods");
            this.tbpTimePeriods.Controls.Add(this.lblRegularTimeH);
            this.tbpTimePeriods.Controls.Add(this.grpBreaksPeriod);
            this.tbpTimePeriods.Controls.Add(this.lblRegularTime);
            this.tbpTimePeriods.Controls.Add(this.nmcRegularTime);
            this.tbpTimePeriods.Controls.Add(this.lblMaxTime);
            this.tbpTimePeriods.Controls.Add(this.nmcMaxTime);
            this.tbpTimePeriods.Controls.Add(this.lblMaxTimeH);
            this.tbpTimePeriods.Controls.Add(this.grpOtherPeriod);
            this.erpValidation.SetError(this.tbpTimePeriods, resources.GetString("tbpTimePeriods.Error"));
            this.erpValidation.SetIconAlignment(this.tbpTimePeriods, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbpTimePeriods.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.tbpTimePeriods, ((int)(resources.GetObject("tbpTimePeriods.IconPadding"))));
            this.tbpTimePeriods.Name = "tbpTimePeriods";
            this.tbpTimePeriods.UseVisualStyleBackColor = true;
            // 
            // grpOtherPeriod
            // 
            resources.ApplyResources(this.grpOtherPeriod, "grpOtherPeriod");
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
            this.erpValidation.SetError(this.grpOtherPeriod, resources.GetString("grpOtherPeriod.Error"));
            this.erpValidation.SetIconAlignment(this.grpOtherPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpOtherPeriod.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.grpOtherPeriod, ((int)(resources.GetObject("grpOtherPeriod.IconPadding"))));
            this.grpOtherPeriod.Name = "grpOtherPeriod";
            this.grpOtherPeriod.TabStop = false;
            // 
            // tbpNotifications
            // 
            resources.ApplyResources(this.tbpNotifications, "tbpNotifications");
            this.tbpNotifications.Controls.Add(this.grpWorkingTime);
            this.tbpNotifications.Controls.Add(this.cbxNotifyOnClockInOut);
            this.erpValidation.SetError(this.tbpNotifications, resources.GetString("tbpNotifications.Error"));
            this.erpValidation.SetIconAlignment(this.tbpNotifications, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbpNotifications.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.tbpNotifications, ((int)(resources.GetObject("tbpNotifications.IconPadding"))));
            this.tbpNotifications.Name = "tbpNotifications";
            this.tbpNotifications.UseVisualStyleBackColor = true;
            // 
            // grpWorkingTime
            // 
            resources.ApplyResources(this.grpWorkingTime, "grpWorkingTime");
            this.grpWorkingTime.Controls.Add(this.cbxNotifyRegularTime);
            this.grpWorkingTime.Controls.Add(this.cbxSystemNotifications);
            this.grpWorkingTime.Controls.Add(this.nmcNotifyRegAdvance);
            this.grpWorkingTime.Controls.Add(this.lblMinBeforeReg);
            this.grpWorkingTime.Controls.Add(this.cbxNotificationAlwayOnTop);
            this.grpWorkingTime.Controls.Add(this.nmcNotifyMaxAdvance);
            this.grpWorkingTime.Controls.Add(this.btnSelectSound);
            this.grpWorkingTime.Controls.Add(this.lblSoundFile);
            this.grpWorkingTime.Controls.Add(this.lblMinBeforeMax);
            this.grpWorkingTime.Controls.Add(this.cbxPlaySound);
            this.grpWorkingTime.Controls.Add(this.cbxNotifyMaxTime);
            this.erpValidation.SetError(this.grpWorkingTime, resources.GetString("grpWorkingTime.Error"));
            this.erpValidation.SetIconAlignment(this.grpWorkingTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpWorkingTime.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.grpWorkingTime, ((int)(resources.GetObject("grpWorkingTime.IconPadding"))));
            this.grpWorkingTime.Name = "grpWorkingTime";
            this.grpWorkingTime.TabStop = false;
            // 
            // cbxSystemNotifications
            // 
            resources.ApplyResources(this.cbxSystemNotifications, "cbxSystemNotifications");
            this.cbxSystemNotifications.Checked = global::ClockIn.Properties.Settings.Default.SystemNotifications;
            this.cbxSystemNotifications.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "SystemNotifications", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxSystemNotifications, resources.GetString("cbxSystemNotifications.Error"));
            this.erpValidation.SetIconAlignment(this.cbxSystemNotifications, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxSystemNotifications.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxSystemNotifications, ((int)(resources.GetObject("cbxSystemNotifications.IconPadding"))));
            this.cbxSystemNotifications.Name = "cbxSystemNotifications";
            this.cbxSystemNotifications.UseVisualStyleBackColor = true;
            // 
            // nmcNotifyRegAdvance
            // 
            resources.ApplyResources(this.nmcNotifyRegAdvance, "nmcNotifyRegAdvance");
            this.nmcNotifyRegAdvance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "NotifyRegAdvance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.nmcNotifyRegAdvance, resources.GetString("nmcNotifyRegAdvance.Error"));
            this.erpValidation.SetIconAlignment(this.nmcNotifyRegAdvance, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcNotifyRegAdvance.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcNotifyRegAdvance, ((int)(resources.GetObject("nmcNotifyRegAdvance.IconPadding"))));
            this.nmcNotifyRegAdvance.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmcNotifyRegAdvance.Name = "nmcNotifyRegAdvance";
            this.nmcNotifyRegAdvance.Value = global::ClockIn.Properties.Settings.Default.NotifyRegAdvance;
            // 
            // lblMinBeforeReg
            // 
            resources.ApplyResources(this.lblMinBeforeReg, "lblMinBeforeReg");
            this.erpValidation.SetError(this.lblMinBeforeReg, resources.GetString("lblMinBeforeReg.Error"));
            this.erpValidation.SetIconAlignment(this.lblMinBeforeReg, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblMinBeforeReg.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblMinBeforeReg, ((int)(resources.GetObject("lblMinBeforeReg.IconPadding"))));
            this.lblMinBeforeReg.Name = "lblMinBeforeReg";
            // 
            // cbxNotifyOnClockInOut
            // 
            resources.ApplyResources(this.cbxNotifyOnClockInOut, "cbxNotifyOnClockInOut");
            this.cbxNotifyOnClockInOut.Checked = global::ClockIn.Properties.Settings.Default.NotifyOnClockInOut;
            this.cbxNotifyOnClockInOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNotifyOnClockInOut.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "NotifyOnClockInOut", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxNotifyOnClockInOut, resources.GetString("cbxNotifyOnClockInOut.Error"));
            this.erpValidation.SetIconAlignment(this.cbxNotifyOnClockInOut, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxNotifyOnClockInOut.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxNotifyOnClockInOut, ((int)(resources.GetObject("cbxNotifyOnClockInOut.IconPadding"))));
            this.cbxNotifyOnClockInOut.Name = "cbxNotifyOnClockInOut";
            this.cbxNotifyOnClockInOut.UseVisualStyleBackColor = true;
            // 
            // tbpMisc
            // 
            resources.ApplyResources(this.tbpMisc, "tbpMisc");
            this.tbpMisc.Controls.Add(this.cbxFlatIcon);
            this.tbpMisc.Controls.Add(this.cbxMinimized);
            this.tbpMisc.Controls.Add(this.lblOffsetMinutes);
            this.tbpMisc.Controls.Add(this.nmcArrivalTimeOffset);
            this.tbpMisc.Controls.Add(this.lblArrivalTimeOffset);
            this.tbpMisc.Controls.Add(this.cbxAutoLaunch);
            this.tbpMisc.Controls.Add(this.grpLastSession);
            this.tbpMisc.Controls.Add(this.cbxLowPowerIsStart);
            this.tbpMisc.Controls.Add(this.grpAbsence);
            this.erpValidation.SetError(this.tbpMisc, resources.GetString("tbpMisc.Error"));
            this.erpValidation.SetIconAlignment(this.tbpMisc, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbpMisc.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.tbpMisc, ((int)(resources.GetObject("tbpMisc.IconPadding"))));
            this.tbpMisc.Name = "tbpMisc";
            this.tbpMisc.UseVisualStyleBackColor = true;
            // 
            // cbxFlatIcon
            // 
            resources.ApplyResources(this.cbxFlatIcon, "cbxFlatIcon");
            this.cbxFlatIcon.Checked = global::ClockIn.Properties.Settings.Default.FlatIconOnNewWindows;
            this.cbxFlatIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxFlatIcon.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "FlatIconOnNewWindows", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxFlatIcon, resources.GetString("cbxFlatIcon.Error"));
            this.erpValidation.SetIconAlignment(this.cbxFlatIcon, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxFlatIcon.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxFlatIcon, ((int)(resources.GetObject("cbxFlatIcon.IconPadding"))));
            this.cbxFlatIcon.Name = "cbxFlatIcon";
            this.cbxFlatIcon.UseVisualStyleBackColor = true;
            // 
            // cbxMinimized
            // 
            resources.ApplyResources(this.cbxMinimized, "cbxMinimized");
            this.cbxMinimized.Checked = global::ClockIn.Properties.Settings.Default.StartMinimized;
            this.cbxMinimized.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "StartMinimized", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxMinimized, resources.GetString("cbxMinimized.Error"));
            this.erpValidation.SetIconAlignment(this.cbxMinimized, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxMinimized.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxMinimized, ((int)(resources.GetObject("cbxMinimized.IconPadding"))));
            this.cbxMinimized.Name = "cbxMinimized";
            this.cbxMinimized.UseVisualStyleBackColor = true;
            // 
            // lblOffsetMinutes
            // 
            resources.ApplyResources(this.lblOffsetMinutes, "lblOffsetMinutes");
            this.erpValidation.SetError(this.lblOffsetMinutes, resources.GetString("lblOffsetMinutes.Error"));
            this.erpValidation.SetIconAlignment(this.lblOffsetMinutes, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblOffsetMinutes.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblOffsetMinutes, ((int)(resources.GetObject("lblOffsetMinutes.IconPadding"))));
            this.lblOffsetMinutes.Name = "lblOffsetMinutes";
            // 
            // nmcArrivalTimeOffset
            // 
            resources.ApplyResources(this.nmcArrivalTimeOffset, "nmcArrivalTimeOffset");
            this.nmcArrivalTimeOffset.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "ArrivalTimeOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.nmcArrivalTimeOffset, resources.GetString("nmcArrivalTimeOffset.Error"));
            this.erpValidation.SetIconAlignment(this.nmcArrivalTimeOffset, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("nmcArrivalTimeOffset.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.nmcArrivalTimeOffset, ((int)(resources.GetObject("nmcArrivalTimeOffset.IconPadding"))));
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
            this.erpValidation.SetError(this.lblArrivalTimeOffset, resources.GetString("lblArrivalTimeOffset.Error"));
            this.erpValidation.SetIconAlignment(this.lblArrivalTimeOffset, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblArrivalTimeOffset.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.lblArrivalTimeOffset, ((int)(resources.GetObject("lblArrivalTimeOffset.IconPadding"))));
            this.lblArrivalTimeOffset.Name = "lblArrivalTimeOffset";
            // 
            // grpAbsence
            // 
            resources.ApplyResources(this.grpAbsence, "grpAbsence");
            this.grpAbsence.Controls.Add(this.cbxConfirmOnClockIn);
            this.grpAbsence.Controls.Add(this.cbxMinimizeOnClockOut);
            this.grpAbsence.Controls.Add(this.cbxClockInAtWakeup);
            this.grpAbsence.Controls.Add(this.cbxClockInAtStart);
            this.erpValidation.SetError(this.grpAbsence, resources.GetString("grpAbsence.Error"));
            this.erpValidation.SetIconAlignment(this.grpAbsence, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpAbsence.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.grpAbsence, ((int)(resources.GetObject("grpAbsence.IconPadding"))));
            this.grpAbsence.Name = "grpAbsence";
            this.grpAbsence.TabStop = false;
            // 
            // cbxConfirmOnClockIn
            // 
            resources.ApplyResources(this.cbxConfirmOnClockIn, "cbxConfirmOnClockIn");
            this.cbxConfirmOnClockIn.Checked = global::ClockIn.Properties.Settings.Default.ConfirmAbsenceOnClockIn;
            this.cbxConfirmOnClockIn.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "ConfirmAbsenceOnClockIn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxConfirmOnClockIn, resources.GetString("cbxConfirmOnClockIn.Error"));
            this.erpValidation.SetIconAlignment(this.cbxConfirmOnClockIn, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxConfirmOnClockIn.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxConfirmOnClockIn, ((int)(resources.GetObject("cbxConfirmOnClockIn.IconPadding"))));
            this.cbxConfirmOnClockIn.Name = "cbxConfirmOnClockIn";
            this.cbxConfirmOnClockIn.UseVisualStyleBackColor = true;
            // 
            // cbxMinimizeOnClockOut
            // 
            resources.ApplyResources(this.cbxMinimizeOnClockOut, "cbxMinimizeOnClockOut");
            this.cbxMinimizeOnClockOut.Checked = global::ClockIn.Properties.Settings.Default.MinimizeOnClockOut;
            this.cbxMinimizeOnClockOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMinimizeOnClockOut.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "MinimizeOnClockOut", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxMinimizeOnClockOut, resources.GetString("cbxMinimizeOnClockOut.Error"));
            this.erpValidation.SetIconAlignment(this.cbxMinimizeOnClockOut, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxMinimizeOnClockOut.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxMinimizeOnClockOut, ((int)(resources.GetObject("cbxMinimizeOnClockOut.IconPadding"))));
            this.cbxMinimizeOnClockOut.Name = "cbxMinimizeOnClockOut";
            this.cbxMinimizeOnClockOut.UseVisualStyleBackColor = true;
            // 
            // cbxClockInAtWakeup
            // 
            resources.ApplyResources(this.cbxClockInAtWakeup, "cbxClockInAtWakeup");
            this.cbxClockInAtWakeup.Checked = global::ClockIn.Properties.Settings.Default.ClockInAtWakeup;
            this.cbxClockInAtWakeup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxClockInAtWakeup.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "ClockInAtWakeup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxClockInAtWakeup, resources.GetString("cbxClockInAtWakeup.Error"));
            this.erpValidation.SetIconAlignment(this.cbxClockInAtWakeup, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxClockInAtWakeup.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxClockInAtWakeup, ((int)(resources.GetObject("cbxClockInAtWakeup.IconPadding"))));
            this.cbxClockInAtWakeup.Name = "cbxClockInAtWakeup";
            this.cbxClockInAtWakeup.UseVisualStyleBackColor = true;
            // 
            // cbxClockInAtStart
            // 
            resources.ApplyResources(this.cbxClockInAtStart, "cbxClockInAtStart");
            this.cbxClockInAtStart.Checked = global::ClockIn.Properties.Settings.Default.ClockInAtStart;
            this.cbxClockInAtStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxClockInAtStart.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "ClockInAtStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.erpValidation.SetError(this.cbxClockInAtStart, resources.GetString("cbxClockInAtStart.Error"));
            this.erpValidation.SetIconAlignment(this.cbxClockInAtStart, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxClockInAtStart.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.cbxClockInAtStart, ((int)(resources.GetObject("cbxClockInAtStart.IconPadding"))));
            this.cbxClockInAtStart.Name = "cbxClockInAtStart";
            this.cbxClockInAtStart.UseVisualStyleBackColor = true;
            // 
            // btnHotkeys
            // 
            resources.ApplyResources(this.btnHotkeys, "btnHotkeys");
            this.erpValidation.SetError(this.btnHotkeys, resources.GetString("btnHotkeys.Error"));
            this.erpValidation.SetIconAlignment(this.btnHotkeys, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnHotkeys.IconAlignment"))));
            this.erpValidation.SetIconPadding(this.btnHotkeys, ((int)(resources.GetObject("btnHotkeys.IconPadding"))));
            this.btnHotkeys.Name = "btnHotkeys";
            this.btnHotkeys.UseVisualStyleBackColor = true;
            this.btnHotkeys.Click += new System.EventHandler(this.BtnHotkeys_Click);
            // 
            // erpValidation
            // 
            this.erpValidation.ContainerControl = this;
            resources.ApplyResources(this.erpValidation, "erpValidation");
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnHotkeys);
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
            this.grpWorkingTime.ResumeLayout(false);
            this.grpWorkingTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyRegAdvance)).EndInit();
            this.tbpMisc.ResumeLayout(false);
            this.tbpMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcArrivalTimeOffset)).EndInit();
            this.grpAbsence.ResumeLayout(false);
            this.grpAbsence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpValidation)).EndInit();
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
        private System.Windows.Forms.CheckBox cbxMinimizeOnClockOut;
        private System.Windows.Forms.CheckBox cbxConfirmOnClockIn;
        private System.Windows.Forms.Button btnHotkeys;
        private System.Windows.Forms.CheckBox cbxNotifyOnClockInOut;
        private System.Windows.Forms.CheckBox cbxSystemNotifications;
        private System.Windows.Forms.GroupBox grpWorkingTime;
        private System.Windows.Forms.ErrorProvider erpValidation;
    }
}