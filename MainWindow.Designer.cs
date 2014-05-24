﻿namespace ClockIn
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
            this.lblBreaks = new System.Windows.Forms.Label();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.lblBreaksMin = new System.Windows.Forms.Label();
            this.icnTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.itmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.nmcBreaks = new System.Windows.Forms.NumericUpDown();
            this.dtpArrival = new System.Windows.Forms.DateTimePicker();
            this.btnAbout = new System.Windows.Forms.Button();
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblWorkingTimeIcon = new System.Windows.Forms.Label();
            this.lblLeaveTimeIcon = new System.Windows.Forms.Label();
            this.lblLeaveTime = new System.Windows.Forms.Label();
            this.pnlTimeDisplay = new System.Windows.Forms.Panel();
            this.imgStates = new System.Windows.Forms.ImageList(this.components);
            this.lblIcon = new System.Windows.Forms.Label();
            this.cbxDisplayMaxTime = new System.Windows.Forms.CheckBox();
            this.ctxTrayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreaks)).BeginInit();
            this.pnlTimeDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBegin
            // 
            resources.ApplyResources(this.lblBegin, "lblBegin");
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.DoubleClick += new System.EventHandler(this.lblBegin_DoubleClick);
            // 
            // lblBreaks
            // 
            resources.ApplyResources(this.lblBreaks, "lblBreaks");
            this.lblBreaks.Name = "lblBreaks";
            // 
            // btnOptions
            // 
            resources.ApplyResources(this.btnOptions, "btnOptions");
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblWorkingTime
            // 
            resources.ApplyResources(this.lblWorkingTime, "lblWorkingTime");
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Click += new System.EventHandler(this.lblWorkingTime_Click);
            // 
            // lblBreaksMin
            // 
            resources.ApplyResources(this.lblBreaksMin, "lblBreaksMin");
            this.lblBreaksMin.Name = "lblBreaksMin";
            // 
            // icnTrayIcon
            // 
            this.icnTrayIcon.ContextMenuStrip = this.ctxTrayMenu;
            resources.ApplyResources(this.icnTrayIcon, "icnTrayIcon");
            this.icnTrayIcon.DoubleClick += new System.EventHandler(this.icnTray_DoubleClick);
            // 
            // ctxTrayMenu
            // 
            this.ctxTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmRestore,
            this.itmOptions,
            this.toolStripSeparator1,
            this.itmExit});
            this.ctxTrayMenu.Name = "ctxTrayMenu";
            resources.ApplyResources(this.ctxTrayMenu, "ctxTrayMenu");
            // 
            // itmRestore
            // 
            resources.ApplyResources(this.itmRestore, "itmRestore");
            this.itmRestore.Name = "itmRestore";
            this.itmRestore.Click += new System.EventHandler(this.itmRestore_Click);
            // 
            // itmOptions
            // 
            this.itmOptions.Name = "itmOptions";
            resources.ApplyResources(this.itmOptions, "itmOptions");
            this.itmOptions.Click += new System.EventHandler(this.itmOptions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // itmExit
            // 
            this.itmExit.Name = "itmExit";
            resources.ApplyResources(this.itmExit, "itmExit");
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // nmcBreaks
            // 
            this.nmcBreaks.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Session.Default, "Break", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcBreaks, "nmcBreaks");
            this.nmcBreaks.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nmcBreaks.Name = "nmcBreaks";
            this.nmcBreaks.Value = global::ClockIn.Session.Default.Break;
            this.nmcBreaks.Validated += new System.EventHandler(this.nmcBreaks_Validated);
            // 
            // dtpArrival
            // 
            resources.ApplyResources(this.dtpArrival, "dtpArrival");
            this.dtpArrival.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Session.Default, "Arrival", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpArrival.Name = "dtpArrival";
            this.dtpArrival.ShowUpDown = true;
            this.dtpArrival.Value = global::ClockIn.Session.Default.Arrival;
            this.dtpArrival.Validated += new System.EventHandler(this.dtpArrival_Validated);
            // 
            // btnAbout
            // 
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "Stopwatch.png");
            this.imgIcons.Images.SetKeyName(1, "Timer.png");
            this.imgIcons.Images.SetKeyName(2, "Power.png");
            // 
            // lblWorkingTimeIcon
            // 
            resources.ApplyResources(this.lblWorkingTimeIcon, "lblWorkingTimeIcon");
            this.lblWorkingTimeIcon.ImageList = this.imgIcons;
            this.lblWorkingTimeIcon.Name = "lblWorkingTimeIcon";
            this.lblWorkingTimeIcon.Click += new System.EventHandler(this.lblWorkingTimeIcon_Click);
            // 
            // lblLeaveTimeIcon
            // 
            resources.ApplyResources(this.lblLeaveTimeIcon, "lblLeaveTimeIcon");
            this.lblLeaveTimeIcon.ImageList = this.imgIcons;
            this.lblLeaveTimeIcon.Name = "lblLeaveTimeIcon";
            this.lblLeaveTimeIcon.Click += new System.EventHandler(this.lblLeaveTimeIcon_Click);
            // 
            // lblLeaveTime
            // 
            resources.ApplyResources(this.lblLeaveTime, "lblLeaveTime");
            this.lblLeaveTime.Name = "lblLeaveTime";
            this.lblLeaveTime.Click += new System.EventHandler(this.lblLeaveTime_Click);
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
            // imgStates
            // 
            this.imgStates.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgStates.ImageStream")));
            this.imgStates.TransparentColor = System.Drawing.Color.Transparent;
            this.imgStates.Images.SetKeyName(0, "Confused.png");
            this.imgStates.Images.SetKeyName(1, "BigSmile.png");
            this.imgStates.Images.SetKeyName(2, "Ooooh.png");
            this.imgStates.Images.SetKeyName(3, "Sad.png");
            // 
            // lblIcon
            // 
            resources.ApplyResources(this.lblIcon, "lblIcon");
            this.lblIcon.ImageList = this.imgStates;
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
            // MainWindow
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxDisplayMaxTime);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.pnlTimeDisplay);
            this.Controls.Add(this.dtpArrival);
            this.Controls.Add(this.nmcBreaks);
            this.Controls.Add(this.lblBreaksMin);
            this.Controls.Add(this.lblBreaks);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.VisibleChanged += new System.EventHandler(this.MainWindow_VisibleChanged);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.ctxTrayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmcBreaks)).EndInit();
            this.pnlTimeDisplay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Label lblBreaks;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblWorkingTime;
        private System.Windows.Forms.Label lblBreaksMin;
        private System.Windows.Forms.NotifyIcon icnTrayIcon;
        private System.Windows.Forms.ContextMenuStrip ctxTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem itmRestore;
        private System.Windows.Forms.ToolStripMenuItem itmOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itmExit;
        private System.Windows.Forms.NumericUpDown nmcBreaks;
        private System.Windows.Forms.DateTimePicker dtpArrival;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.Label lblWorkingTimeIcon;
        private System.Windows.Forms.Label lblLeaveTimeIcon;
        private System.Windows.Forms.Label lblLeaveTime;
        private System.Windows.Forms.Panel pnlTimeDisplay;
        private System.Windows.Forms.ImageList imgStates;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.CheckBox cbxDisplayMaxTime;

    }
}

