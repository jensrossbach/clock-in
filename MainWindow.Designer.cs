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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.ctxTrayMenu.SuspendLayout();
            this.pnlTimeDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBegin
            // 
            resources.ApplyResources(this.lblBegin, "lblBegin");
            this.lblBegin.Name = "lblBegin";
            this.ttMain.SetToolTip(this.lblBegin, resources.GetString("lblBegin.ToolTip"));
            // 
            // lblAbsence
            // 
            resources.ApplyResources(this.lblAbsence, "lblAbsence");
            this.lblAbsence.Name = "lblAbsence";
            this.ttMain.SetToolTip(this.lblAbsence, resources.GetString("lblAbsence.ToolTip"));
            // 
            // btnOptions
            // 
            resources.ApplyResources(this.btnOptions, "btnOptions");
            this.btnOptions.Name = "btnOptions";
            this.ttMain.SetToolTip(this.btnOptions, resources.GetString("btnOptions.ToolTip"));
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.ttMain.SetToolTip(this.btnClose, resources.GetString("btnClose.ToolTip"));
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblWorkingTime
            // 
            resources.ApplyResources(this.lblWorkingTime, "lblWorkingTime");
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.ttMain.SetToolTip(this.lblWorkingTime, resources.GetString("lblWorkingTime.ToolTip"));
            this.lblWorkingTime.Click += new System.EventHandler(this.LblWorkingTime_Click);
            // 
            // icnTrayIcon
            // 
            resources.ApplyResources(this.icnTrayIcon, "icnTrayIcon");
            this.icnTrayIcon.ContextMenuStrip = this.ctxTrayMenu;
            this.icnTrayIcon.DoubleClick += new System.EventHandler(this.IcnTray_DoubleClick);
            // 
            // ctxTrayMenu
            // 
            resources.ApplyResources(this.ctxTrayMenu, "ctxTrayMenu");
            this.ctxTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmRestore,
            this.itmOptions,
            this.toolStripSeparator1,
            this.itmExit});
            this.ctxTrayMenu.Name = "ctxTrayMenu";
            this.ttMain.SetToolTip(this.ctxTrayMenu, resources.GetString("ctxTrayMenu.ToolTip"));
            // 
            // itmRestore
            // 
            resources.ApplyResources(this.itmRestore, "itmRestore");
            this.itmRestore.Name = "itmRestore";
            this.itmRestore.Click += new System.EventHandler(this.ItmRestore_Click);
            // 
            // itmOptions
            // 
            resources.ApplyResources(this.itmOptions, "itmOptions");
            this.itmOptions.Name = "itmOptions";
            this.itmOptions.Click += new System.EventHandler(this.ItmOptions_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // itmExit
            // 
            resources.ApplyResources(this.itmExit, "itmExit");
            this.itmExit.Name = "itmExit";
            this.itmExit.Click += new System.EventHandler(this.ItmExit_Click);
            // 
            // dtpArrival
            // 
            resources.ApplyResources(this.dtpArrival, "dtpArrival");
            this.dtpArrival.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Session.Default, "Arrival", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrival.Name = "dtpArrival";
            this.dtpArrival.ShowUpDown = true;
            this.ttMain.SetToolTip(this.dtpArrival, resources.GetString("dtpArrival.ToolTip"));
            this.dtpArrival.Value = global::ClockIn.Session.Default.Arrival;
            this.dtpArrival.Validated += new System.EventHandler(this.DtpArrival_Validated);
            // 
            // btnAbout
            // 
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Name = "btnAbout";
            this.ttMain.SetToolTip(this.btnAbout, resources.GetString("btnAbout.ToolTip"));
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // lblWorkingTimeIcon
            // 
            resources.ApplyResources(this.lblWorkingTimeIcon, "lblWorkingTimeIcon");
            this.lblWorkingTimeIcon.Name = "lblWorkingTimeIcon";
            this.ttMain.SetToolTip(this.lblWorkingTimeIcon, resources.GetString("lblWorkingTimeIcon.ToolTip"));
            this.lblWorkingTimeIcon.Click += new System.EventHandler(this.LblWorkingTimeIcon_Click);
            // 
            // lblLeaveTimeIcon
            // 
            resources.ApplyResources(this.lblLeaveTimeIcon, "lblLeaveTimeIcon");
            this.lblLeaveTimeIcon.Name = "lblLeaveTimeIcon";
            this.ttMain.SetToolTip(this.lblLeaveTimeIcon, resources.GetString("lblLeaveTimeIcon.ToolTip"));
            this.lblLeaveTimeIcon.Click += new System.EventHandler(this.LblLeaveTimeIcon_Click);
            // 
            // lblLeaveTime
            // 
            resources.ApplyResources(this.lblLeaveTime, "lblLeaveTime");
            this.lblLeaveTime.Name = "lblLeaveTime";
            this.ttMain.SetToolTip(this.lblLeaveTime, resources.GetString("lblLeaveTime.ToolTip"));
            this.lblLeaveTime.Click += new System.EventHandler(this.LblLeaveTime_Click);
            // 
            // pnlTimeDisplay
            // 
            resources.ApplyResources(this.pnlTimeDisplay, "pnlTimeDisplay");
            this.pnlTimeDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTimeDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimeDisplay.Controls.Add(this.lblWorkingTimeIcon);
            this.pnlTimeDisplay.Controls.Add(this.lblWorkingTime);
            this.pnlTimeDisplay.Controls.Add(this.lblLeaveTime);
            this.pnlTimeDisplay.Controls.Add(this.lblLeaveTimeIcon);
            this.pnlTimeDisplay.Name = "pnlTimeDisplay";
            this.ttMain.SetToolTip(this.pnlTimeDisplay, resources.GetString("pnlTimeDisplay.ToolTip"));
            // 
            // lblIcon
            // 
            resources.ApplyResources(this.lblIcon, "lblIcon");
            this.lblIcon.Name = "lblIcon";
            this.ttMain.SetToolTip(this.lblIcon, resources.GetString("lblIcon.ToolTip"));
            // 
            // cbxDisplayMaxTime
            // 
            resources.ApplyResources(this.cbxDisplayMaxTime, "cbxDisplayMaxTime");
            this.cbxDisplayMaxTime.Checked = global::ClockIn.Properties.Settings.Default.DisplayMaximumTime;
            this.cbxDisplayMaxTime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClockIn.Properties.Settings.Default, "DisplayMaximumTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxDisplayMaxTime.Name = "cbxDisplayMaxTime";
            this.ttMain.SetToolTip(this.cbxDisplayMaxTime, resources.GetString("cbxDisplayMaxTime.ToolTip"));
            this.cbxDisplayMaxTime.UseVisualStyleBackColor = true;
            // 
            // btnResetTime
            // 
            resources.ApplyResources(this.btnResetTime, "btnResetTime");
            this.btnResetTime.Image = global::ClockIn.Properties.Resources.Reset;
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
            this.ttMain.SetToolTip(this.txtAbsence, resources.GetString("txtAbsence.ToolTip"));
            // 
            // btnAbsence
            // 
            resources.ApplyResources(this.btnAbsence, "btnAbsence");
            this.btnAbsence.Name = "btnAbsence";
            this.ttMain.SetToolTip(this.btnAbsence, resources.GetString("btnAbsence.ToolTip"));
            this.btnAbsence.UseVisualStyleBackColor = true;
            this.btnAbsence.Click += new System.EventHandler(this.BtnAbsence_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ClockIn.Properties.Settings.Default, "MainWindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = global::ClockIn.Properties.Settings.Default.MainWindowLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ttMain.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.VisibleChanged += new System.EventHandler(this.MainWindow_VisibleChanged);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
    }
}

