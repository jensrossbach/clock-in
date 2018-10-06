namespace ClockIn
{
    partial class AbsenceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbsenceDialog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvAbsence = new System.Windows.Forms.DataGridView();
            this.colBegin = new ClockIn.DataGridViewTimeColumn();
            this.colEnd = new ClockIn.DataGridViewTimeColumn();
            this.colDuration = new ClockIn.DataGridViewTimeColumn();
            this.timePeriodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePeriodBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // dgvAbsence
            // 
            this.dgvAbsence.AllowUserToAddRows = false;
            this.dgvAbsence.AllowUserToDeleteRows = false;
            this.dgvAbsence.AllowUserToResizeColumns = false;
            this.dgvAbsence.AllowUserToResizeRows = false;
            this.dgvAbsence.AutoGenerateColumns = false;
            this.dgvAbsence.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAbsence.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAbsence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBegin,
            this.colEnd,
            this.colDuration});
            this.dgvAbsence.DataSource = this.timePeriodBindingSource;
            this.dgvAbsence.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            resources.ApplyResources(this.dgvAbsence, "dgvAbsence");
            this.dgvAbsence.MultiSelect = false;
            this.dgvAbsence.Name = "dgvAbsence";
            this.dgvAbsence.ReadOnly = true;
            this.dgvAbsence.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAbsence.RowHeadersVisible = false;
            this.dgvAbsence.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAbsence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsence.ShowCellErrors = false;
            this.dgvAbsence.ShowCellToolTips = false;
            this.dgvAbsence.ShowRowErrors = false;
            this.dgvAbsence.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvBreaks_CellFormatting);
            this.dgvAbsence.SelectionChanged += new System.EventHandler(this.DgvBreaks_SelectionChanged);
            // 
            // colBegin
            // 
            this.colBegin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colBegin.DataPropertyName = "StartTime";
            dataGridViewCellStyle1.Format = "t";
            this.colBegin.DefaultCellStyle = dataGridViewCellStyle1;
            this.colBegin.Frozen = true;
            resources.ApplyResources(this.colBegin, "colBegin");
            this.colBegin.Name = "colBegin";
            this.colBegin.ReadOnly = true;
            this.colBegin.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEnd
            // 
            this.colEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEnd.DataPropertyName = "EndTime";
            dataGridViewCellStyle2.Format = "t";
            this.colEnd.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEnd.Frozen = true;
            resources.ApplyResources(this.colEnd, "colEnd");
            this.colEnd.Name = "colEnd";
            this.colEnd.ReadOnly = true;
            this.colEnd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDuration
            // 
            this.colDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDuration.DataPropertyName = "Duration";
            dataGridViewCellStyle3.Format = "t";
            this.colDuration.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDuration.Frozen = true;
            resources.ApplyResources(this.colDuration, "colDuration");
            this.colDuration.Name = "colDuration";
            this.colDuration.ReadOnly = true;
            this.colDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // timePeriodBindingSource
            // 
            this.timePeriodBindingSource.DataSource = typeof(ClockIn.TimePeriod);
            // 
            // AbsenceDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvAbsence);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ClockIn.Properties.Settings.Default, "AbsenceDialogLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = global::ClockIn.Properties.Settings.Default.AbsenceDialogLocation;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbsenceDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.BreaksDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePeriodBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAbsence;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource timePeriodBindingSource;
        private DataGridViewTimeColumn colBegin;
        private DataGridViewTimeColumn colEnd;
        private DataGridViewTimeColumn colDuration;
    }
}