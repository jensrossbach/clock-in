namespace ClockIn
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lblBegin = new System.Windows.Forms.Label();
            this.lblAbsence = new System.Windows.Forms.Label();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.icnTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.itmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itmClockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.itmClockOut = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpArrival = new System.Windows.Forms.DateTimePicker();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblWorkingTimeIcon = new System.Windows.Forms.Label();
            this.lblLeaveTimeIcon = new System.Windows.Forms.Label();
            this.lblLeaveTime = new System.Windows.Forms.Label();
            this.pnlTimeDisplay = new System.Windows.Forms.Panel();
            this.lblIcon = new System.Windows.Forms.Label();
            this.cbxDisplayMaxTime = new System.Windows.Forms.CheckBox();
            this.btnResetTime = new System.Windows.Forms.Button();
            this.txtAbsence = new System.Windows.Forms.TextBox();
            this.btnAbsence = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnClockInOut = new System.Windows.Forms.Button();
            this.ctxTrayMenu.SuspendLayout();
            this.pnlTimeDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBegin
            // 
            resources.ApplyResources(this.lblBegin, "lblBegin");
            this.lblBegin.Name = "lblBegin";
            // 
            // lblAbsence
            // 
            resources.ApplyResources(this.lblAbsence, "lblAbsence");
            this.lblAbsence.Name = "lblAbsence";
            // 
            // btnOptions
            // 
            resources.ApplyResources(this.btnOptions, "btnOptions");
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblWorkingTime
            // 
            resources.ApplyResources(this.lblWorkingTime, "lblWorkingTime");
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Click += new System.EventHandler(this.LblWorkingTime_Click);
            // 
            // icnTrayIcon
            // 
            this.icnTrayIcon.ContextMenuStrip = this.ctxTrayMenu;
            resources.ApplyResources(this.icnTrayIcon, "icnTrayIcon");
            this.icnTrayIcon.DoubleClick += new System.EventHandler(this.IcnTray_DoubleClick);
            // 
            // ctxTrayMenu
            // 
            this.ctxTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmRestore,
            this.itmOptions,
            this.itmSeparator1,
            this.itmClockIn,
            this.itmClockOut,
            this.itmSeparator2,
            this.itmExit});
            this.ctxTrayMenu.Name = "ctxTrayMenu";
            resources.ApplyResources(this.ctxTrayMenu, "ctxTrayMenu");
            // 
            // itmRestore
            // 
            resources.ApplyResources(this.itmRestore, "itmRestore");
            this.itmRestore.Name = "itmRestore";
            this.itmRestore.Click += new System.EventHandler(this.ItmRestore_Click);
            // 
            // itmOptions
            // 
            this.itmOptions.Name = "itmOptions";
            resources.ApplyResources(this.itmOptions, "itmOptions");
            this.itmOptions.Click += new System.EventHandler(this.ItmOptions_Click);
            // 
            // itmSeparator1
            // 
            this.itmSeparator1.Name = "itmSeparator1";
            resources.ApplyResources(this.itmSeparator1, "itmSeparator1");
            // 
            // itmClockIn
            // 
            resources.ApplyResources(this.itmClockIn, "itmClockIn");
            this.itmClockIn.Name = "itmClockIn";
            this.itmClockIn.Click += new System.EventHandler(this.ItmClockIn_Click);
            // 
            // itmClockOut
            // 
            this.itmClockOut.Name = "itmClockOut";
            resources.ApplyResources(this.itmClockOut, "itmClockOut");
            this.itmClockOut.Click += new System.EventHandler(this.ItmClockOut_Click);
            // 
            // itmSeparator2
            // 
            this.itmSeparator2.Name = "itmSeparator2";
            resources.ApplyResources(this.itmSeparator2, "itmSeparator2");
            // 
            // itmExit
            // 
            this.itmExit.Name = "itmExit";
            resources.ApplyResources(this.itmExit, "itmExit");
            this.itmExit.Click += new System.EventHandler(this.ItmExit_Click);
            // 
            // dtpArrival
            // 
            resources.ApplyResources(this.dtpArrival, "dtpArrival");
            this.dtpArrival.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Session.Default, "Arrival", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrival.Name = "dtpArrival";
            this.dtpArrival.ShowUpDown = true;
            this.dtpArrival.Value = global::ClockIn.Session.Default.Arrival;
            this.dtpArrival.Validated += new System.EventHandler(this.DtpArrival_Validated);
            // 
            // btnAbout
            // 
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // lblWorkingTimeIcon
            // 
            resources.ApplyResources(this.lblWorkingTimeIcon, "lblWorkingTimeIcon");
            this.lblWorkingTimeIcon.Name = "lblWorkingTimeIcon";
            this.lblWorkingTimeIcon.Click += new System.EventHandler(this.LblWorkingTimeIcon_Click);
            // 
            // lblLeaveTimeIcon
            // 
            resources.ApplyResources(this.lblLeaveTimeIcon, "lblLeaveTimeIcon");
            this.lblLeaveTimeIcon.Name = "lblLeaveTimeIcon";
            this.lblLeaveTimeIcon.Click += new System.EventHandler(this.LblLeaveTimeIcon_Click);
            // 
            // lblLeaveTime
            // 
            resources.ApplyResources(this.lblLeaveTime, "lblLeaveTime");
            this.lblLeaveTime.Name = "lblLeaveTime";
            this.lblLeaveTime.Click += new System.EventHandler(this.LblLeaveTime_Click);
            // 
            // pnlTimeDisplay
            // 
            this.pnlTimeDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTimeDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimeDisplay.Controls.Add(this.lblWorkingTimeIcon);
            this.pnlTimeDisplay.Controls.Add(this.lblWorkingTime);
            this.pnlTimeDisplay.Controls.Add(this.lblLeaveTime);
            this.pnlTimeDisplay.Controls.Add(this.lblLeaveTimeIcon);
            resources.ApplyResources(this.pnlTimeDisplay, "pnlTimeDisplay");
            this.pnlTimeDisplay.Name = "pnlTimeDisplay";
            // 
            // lblIcon
            // 
            resources.ApplyResources(this.lblIcon, "lblIcon");
            this.lblIcon.Name = "lblIcon";
            // 
            // cbxDisplayMaxTime
            // 
            resources.ApplyResources(this.cbxDisplayMaxTime, "cbxDisplayMaxTime");
            this.cbxDisplayMaxTime.Checked = global::ClockIn.Properties.Settings.Default.DisplayMaximumTime;
            this.cbxDisplayMaxTime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "DisplayMaximumTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxDisplayMaxTime.Name = "cbxDisplayMaxTime";
            this.cbxDisplayMaxTime.UseVisualStyleBackColor = true;
            // 
            // btnResetTime
            // 
            this.btnResetTime.Image = global::ClockIn.Properties.Resources.Reset;
            resources.ApplyResources(this.btnResetTime, "btnResetTime");
            this.btnResetTime.Name = "btnResetTime";
            this.ttMain.SetToolTip(this.btnResetTime, resources.GetString("btnResetTime.ToolTip"));
            this.btnResetTime.UseVisualStyleBackColor = true;
            this.btnResetTime.Click += new System.EventHandler(this.BtnResetTime_Click);
            // 
            // txtAbsence
            // 
            resources.ApplyResources(this.txtAbsence, "txtAbsence");
            this.txtAbsence.Name = "txtAbsence";
            this.txtAbsence.ReadOnly = true;
            // 
            // btnAbsence
            // 
            resources.ApplyResources(this.btnAbsence, "btnAbsence");
            this.btnAbsence.Name = "btnAbsence";
            this.ttMain.SetToolTip(this.btnAbsence, resources.GetString("btnAbsence.ToolTip"));
            this.btnAbsence.UseVisualStyleBackColor = true;
            this.btnAbsence.Click += new System.EventHandler(this.BtnAbsence_Click);
            // 
            // btnClockInOut
            // 
            resources.ApplyResources(this.btnClockInOut, "btnClockInOut");
            this.btnClockInOut.Name = "btnClockInOut";
            this.btnClockInOut.UseVisualStyleBackColor = true;
            this.btnClockInOut.Click += new System.EventHandler(this.BtnClockInOut_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClockInOut);
            this.Controls.Add(this.btnAbsence);
            this.Controls.Add(this.txtAbsence);
            this.Controls.Add(this.btnResetTime);
            this.Controls.Add(this.cbxDisplayMaxTime);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.pnlTimeDisplay);
            this.Controls.Add(this.dtpArrival);
            this.Controls.Add(this.lblAbsence);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblBegin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = global::ClockIn.Properties.Settings.Default.MainWindowLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.LocationChanged += new System.EventHandler(this.MainWindow_LocationChanged);
            this.VisibleChanged += new System.EventHandler(this.MainWindow_VisibleChanged);
            this.ctxTrayMenu.ResumeLayout(false);
            this.pnlTimeDisplay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Label lblAbsence;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblWorkingTime;
        private System.Windows.Forms.NotifyIcon icnTrayIcon;
        private System.Windows.Forms.ContextMenuStrip ctxTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem itmRestore;
        private System.Windows.Forms.ToolStripMenuItem itmOptions;
        private System.Windows.Forms.ToolStripSeparator itmSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itmExit;
        private System.Windows.Forms.DateTimePicker dtpArrival;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblWorkingTimeIcon;
        private System.Windows.Forms.Label lblLeaveTimeIcon;
        private System.Windows.Forms.Label lblLeaveTime;
        private System.Windows.Forms.Panel pnlTimeDisplay;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.CheckBox cbxDisplayMaxTime;
        private System.Windows.Forms.Button btnResetTime;
        private System.Windows.Forms.TextBox txtAbsence;
        private System.Windows.Forms.Button btnAbsence;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.ToolStripMenuItem itmClockIn;
        private System.Windows.Forms.ToolStripMenuItem itmClockOut;
        private System.Windows.Forms.ToolStripSeparator itmSeparator2;
        private System.Windows.Forms.Button btnClockInOut;
    }
}

