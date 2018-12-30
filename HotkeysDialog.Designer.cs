namespace ClockIn
{
    partial class HotkeysDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeysDialog));
            this.lblRestoreMainWin = new System.Windows.Forms.Label();
            this.lblClockInOut = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.erpHotkeys = new System.Windows.Forms.ErrorProvider(this.components);
            this.hkcClockInOut = new ClockIn.HotkeyControl();
            this.hkcRestoreMainWin = new ClockIn.HotkeyControl();
            ((System.ComponentModel.ISupportInitialize)(this.erpHotkeys)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRestoreMainWin
            // 
            resources.ApplyResources(this.lblRestoreMainWin, "lblRestoreMainWin");
            this.lblRestoreMainWin.Name = "lblRestoreMainWin";
            // 
            // lblClockInOut
            // 
            resources.ApplyResources(this.lblClockInOut, "lblClockInOut");
            this.lblClockInOut.Name = "lblClockInOut";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // erpHotkeys
            // 
            this.erpHotkeys.ContainerControl = this;
            // 
            // hkcClockInOut
            // 
            this.hkcClockInOut.DataBindings.Add(new System.Windows.Forms.Binding("Hotkey", global::ClockIn.Properties.Settings.Default, "ClockInOutHotkey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hkcClockInOut.Hotkey = global::ClockIn.Properties.Settings.Default.ClockInOutHotkey;
            resources.ApplyResources(this.hkcClockInOut, "hkcClockInOut");
            this.hkcClockInOut.Name = "hkcClockInOut";
            this.hkcClockInOut.Tag = "ClockInOutHotkey";
            this.hkcClockInOut.Enter += new System.EventHandler(this.HotkeyControl_Enter);
            this.hkcClockInOut.Leave += new System.EventHandler(this.HotkeyControl_Leave);
            this.hkcClockInOut.Validating += new System.ComponentModel.CancelEventHandler(this.HotkeyControl_Validating);
            // 
            // hkcRestoreMainWin
            // 
            this.hkcRestoreMainWin.DataBindings.Add(new System.Windows.Forms.Binding("Hotkey", global::ClockIn.Properties.Settings.Default, "MainWindowHotkey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hkcRestoreMainWin.Hotkey = global::ClockIn.Properties.Settings.Default.MainWindowHotkey;
            resources.ApplyResources(this.hkcRestoreMainWin, "hkcRestoreMainWin");
            this.hkcRestoreMainWin.Name = "hkcRestoreMainWin";
            this.hkcRestoreMainWin.Tag = "MainWindowHotkey";
            this.hkcRestoreMainWin.Enter += new System.EventHandler(this.HotkeyControl_Enter);
            this.hkcRestoreMainWin.Leave += new System.EventHandler(this.HotkeyControl_Leave);
            this.hkcRestoreMainWin.Validating += new System.ComponentModel.CancelEventHandler(this.HotkeyControl_Validating);
            // 
            // HotkeysDialog
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.hkcClockInOut);
            this.Controls.Add(this.lblClockInOut);
            this.Controls.Add(this.hkcRestoreMainWin);
            this.Controls.Add(this.lblRestoreMainWin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotkeysDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.erpHotkeys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRestoreMainWin;
        private HotkeyControl hkcRestoreMainWin;
        private System.Windows.Forms.Label lblClockInOut;
        private HotkeyControl hkcClockInOut;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider erpHotkeys;
    }
}