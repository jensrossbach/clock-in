using System;
using System.Windows.Forms;


namespace ClockIn
{
    public partial class AbsenceDialog : Form
    {
        public AbsenceDialog()
        {
            InitializeComponent();
        }

        private void CheckSelection()
        {
            if (dgvAbsence.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TimePeriod tp = new TimePeriod();
            DialogResult res = new AbsenceInputDialog(tp, Properties.Resources.NewAbsence).ShowDialog(this);

            if (res == DialogResult.OK)
            {
                Program.TimeMgr.Absence.Add(tp);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAbsence.SelectedRows.Count > 0)
            {
                Program.TimeMgr.Absence.RemoveAt(dgvAbsence.SelectedRows[0].Index);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAbsence.SelectedRows.Count > 0)
            {
                new AbsenceInputDialog(Program.TimeMgr.Absence[dgvAbsence.SelectedRows[0].Index], Properties.Resources.EditAbsence).ShowDialog(this);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvBreaks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if ((e.Value != null) && (e.Value != DBNull.Value))
                {
                    e.Value = ((TimeSpan)e.Value).Hours.ToString("0") + "h " + ((TimeSpan)e.Value).Minutes.ToString("0") + "m";
                }
            }
        }

        private void DgvBreaks_SelectionChanged(object sender, EventArgs e)
        {
            CheckSelection();
        }

        private void BreaksDialog_Load(object sender, EventArgs e)
        {
            dgvAbsence.DataSource = Program.TimeMgr.Absence;
            CheckSelection();
        }
    }
}
