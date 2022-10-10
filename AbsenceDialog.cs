/*
 * Copyright (c) 2012-2022 Jens-Uwe Rossbach
 *
 * This code is licensed under the MIT License.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */


using System;
using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   Dialog window for managing absence periods
    /// </summary>
    public partial class AbsenceDialog : Form
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public AbsenceDialog()
        {
            InitializeComponent();
        }


        /// <summary>
        ///   Enables/disables buttons depending on the selection in the
        ///   absence period table.
        /// </summary>
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

        /// <summary>
        ///   Handles a click on the add button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TimePeriod tp = new TimePeriod();
            DialogResult res = new AbsenceInputDialog(tp, Properties.Resources.NewAbsence).ShowDialog(this);

            if (res == DialogResult.OK)
            {
                Program.TimeMgr.Absence.Add(tp);
            }
        }

        /// <summary>
        ///   Handles a click on the remove button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAbsence.SelectedRows.Count > 0)
            {
                Program.TimeMgr.Absence.RemoveAt(dgvAbsence.SelectedRows[0].Index);
            }
        }

        /// <summary>
        ///   Handles a click on the edit button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAbsence.SelectedRows.Count > 0)
            {
                new AbsenceInputDialog(Program.TimeMgr.Absence[dgvAbsence.SelectedRows[0].Index], Properties.Resources.EditAbsence).ShowDialog(this);
            }
        }

        /// <summary>
        ///   Handles a click on the close button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///   Handles the event to format a cell in the absence period table.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        ///   Handles the event when selection changes in the absence period table.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void DgvBreaks_SelectionChanged(object sender, EventArgs e)
        {
            CheckSelection();
        }

        /// <summary>
        ///   Handles the event when the dialog window is loading.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BreaksDialog_Load(object sender, EventArgs e)
        {
            dgvAbsence.DataSource = Program.TimeMgr.Absence;
            CheckSelection();
        }
    }
}
