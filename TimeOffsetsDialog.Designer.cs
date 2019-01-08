namespace ClockIn
{
    partial class TimeOffsetsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeOffsetsDialog));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblArrival = new System.Windows.Forms.Label();
            this.nmcArrival = new System.Windows.Forms.NumericUpDown();
            this.lblSessionReset = new System.Windows.Forms.Label();
            this.nmcSessionReset = new System.Windows.Forms.NumericUpDown();
            this.lblClockIn = new System.Windows.Forms.Label();
            this.nmcClockIn = new System.Windows.Forms.NumericUpDown();
            this.lblClockOut = new System.Windows.Forms.Label();
            this.nmcClockOut = new System.Windows.Forms.NumericUpDown();
            this.lblArrivalMin = new System.Windows.Forms.Label();
            this.lblSessionResetMin = new System.Windows.Forms.Label();
            this.lblClockInMin = new System.Windows.Forms.Label();
            this.lblClockOutMin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmcArrival)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcSessionReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcClockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcClockOut)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblArrival
            // 
            resources.ApplyResources(this.lblArrival, "lblArrival");
            this.lblArrival.Name = "lblArrival";
            // 
            // nmcArrival
            // 
            this.nmcArrival.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "ArrivalTimeOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcArrival, "nmcArrival");
            this.nmcArrival.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nmcArrival.Name = "nmcArrival";
            this.nmcArrival.Value = global::ClockIn.Properties.Settings.Default.ArrivalTimeOffset;
            // 
            // lblSessionReset
            // 
            resources.ApplyResources(this.lblSessionReset, "lblSessionReset");
            this.lblSessionReset.Name = "lblSessionReset";
            // 
            // nmcSessionReset
            // 
            this.nmcSessionReset.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "SessionResetTimeOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcSessionReset, "nmcSessionReset");
            this.nmcSessionReset.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nmcSessionReset.Name = "nmcSessionReset";
            this.nmcSessionReset.Value = global::ClockIn.Properties.Settings.Default.SessionResetTimeOffset;
            // 
            // lblClockIn
            // 
            resources.ApplyResources(this.lblClockIn, "lblClockIn");
            this.lblClockIn.Name = "lblClockIn";
            // 
            // nmcClockIn
            // 
            this.nmcClockIn.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "ClockInTimeOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcClockIn, "nmcClockIn");
            this.nmcClockIn.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nmcClockIn.Name = "nmcClockIn";
            this.nmcClockIn.Value = global::ClockIn.Properties.Settings.Default.ClockInTimeOffset;
            // 
            // lblClockOut
            // 
            resources.ApplyResources(this.lblClockOut, "lblClockOut");
            this.lblClockOut.Name = "lblClockOut";
            // 
            // nmcClockOut
            // 
            this.nmcClockOut.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ClockIn.Properties.Settings.Default, "ClockOutTimeOffset", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.nmcClockOut, "nmcClockOut");
            this.nmcClockOut.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nmcClockOut.Name = "nmcClockOut";
            this.nmcClockOut.Value = global::ClockIn.Properties.Settings.Default.ClockOutTimeOffset;
            // 
            // lblArrivalMin
            // 
            resources.ApplyResources(this.lblArrivalMin, "lblArrivalMin");
            this.lblArrivalMin.Name = "lblArrivalMin";
            // 
            // lblSessionResetMin
            // 
            resources.ApplyResources(this.lblSessionResetMin, "lblSessionResetMin");
            this.lblSessionResetMin.Name = "lblSessionResetMin";
            // 
            // lblClockInMin
            // 
            resources.ApplyResources(this.lblClockInMin, "lblClockInMin");
            this.lblClockInMin.Name = "lblClockInMin";
            // 
            // lblClockOutMin
            // 
            resources.ApplyResources(this.lblClockOutMin, "lblClockOutMin");
            this.lblClockOutMin.Name = "lblClockOutMin";
            // 
            // TimeOffsetsDialog
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClockOutMin);
            this.Controls.Add(this.lblClockInMin);
            this.Controls.Add(this.lblSessionResetMin);
            this.Controls.Add(this.lblArrivalMin);
            this.Controls.Add(this.nmcClockOut);
            this.Controls.Add(this.lblClockOut);
            this.Controls.Add(this.nmcClockIn);
            this.Controls.Add(this.lblClockIn);
            this.Controls.Add(this.nmcSessionReset);
            this.Controls.Add(this.lblSessionReset);
            this.Controls.Add(this.nmcArrival);
            this.Controls.Add(this.lblArrival);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeOffsetsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.nmcArrival)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcSessionReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcClockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmcClockOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblArrival;
        private System.Windows.Forms.NumericUpDown nmcArrival;
        private System.Windows.Forms.Label lblSessionReset;
        private System.Windows.Forms.NumericUpDown nmcSessionReset;
        private System.Windows.Forms.Label lblClockIn;
        private System.Windows.Forms.NumericUpDown nmcClockIn;
        private System.Windows.Forms.Label lblClockOut;
        private System.Windows.Forms.NumericUpDown nmcClockOut;
        private System.Windows.Forms.Label lblArrivalMin;
        private System.Windows.Forms.Label lblSessionResetMin;
        private System.Windows.Forms.Label lblClockInMin;
        private System.Windows.Forms.Label lblClockOutMin;
    }
}