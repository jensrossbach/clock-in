namespace ClockIn
{
    partial class NotificationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationDialog));
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.nmcNotifyAgain = new System.Windows.Forms.NumericUpDown();
            this.lblMin = new System.Windows.Forms.Label();
            this.cbxNotifyAgain = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyAgain)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIcon
            // 
            resources.ApplyResources(this.lblIcon, "lblIcon");
            this.lblIcon.Name = "lblIcon";
            // 
            // lblText
            // 
            resources.ApplyResources(this.lblText, "lblText");
            this.lblText.Name = "lblText";
            // 
            // nmcNotifyAgain
            // 
            resources.ApplyResources(this.nmcNotifyAgain, "nmcNotifyAgain");
            this.nmcNotifyAgain.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmcNotifyAgain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmcNotifyAgain.Name = "nmcNotifyAgain";
            this.nmcNotifyAgain.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblMin
            // 
            resources.ApplyResources(this.lblMin, "lblMin");
            this.lblMin.Name = "lblMin";
            // 
            // cbxNotifyAgain
            // 
            resources.ApplyResources(this.cbxNotifyAgain, "cbxNotifyAgain");
            this.cbxNotifyAgain.Checked = true;
            this.cbxNotifyAgain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNotifyAgain.Name = "cbxNotifyAgain";
            this.cbxNotifyAgain.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // NotificationDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxNotifyAgain);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.nmcNotifyAgain);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotificationDialog_FormClosed);
            this.Load += new System.EventHandler(this.NotificationDialog_Load);
            this.Shown += new System.EventHandler(this.NotificationDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nmcNotifyAgain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.NumericUpDown nmcNotifyAgain;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.CheckBox cbxNotifyAgain;
        private System.Windows.Forms.Button btnOK;

    }
}