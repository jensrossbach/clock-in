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


using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   Dialog window for entering a new or editing an existing absence period
    /// </summary>
    public partial class AbsenceInputDialog : Form
    {
        private TimePeriod timePeriod;
        private TimePeriod tempTimePeriod;


        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        /// <param name="tp">Absence period to modify</param>
        /// <param name="title">Title of the dialog window</param>
        public AbsenceInputDialog(TimePeriod tp, string title)
        {
            timePeriod = tp;
            tempTimePeriod = new TimePeriod(tp);

            InitializeComponent();
            Text = title;

            dtpBeginTime.DataBindings.Add("Value", tempTimePeriod, "StartTime");
            dtpEndTime.DataBindings.Add("Value", tempTimePeriod, "EndTime");
        }


        /// <summary>
        ///   Status if entered time period is valid
        /// </summary>
        /// <returns>true if time period is valid, false otherwise</returns>
        private bool ValidTimePeriod => tempTimePeriod.StartTime < tempTimePeriod.EndTime;


        /// <summary>
        ///   Applies the entered input to the passed time period.
        /// </summary>
        private void ApplyInput()
        {
            timePeriod.CopyFrom(tempTimePeriod);
        }

        /// <summary>
        ///   Handles a click on the okay button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            erpValidation.SetError(btnOK, "");

            if (!ValidTimePeriod)
            {
                erpValidation.SetError(btnOK, Properties.Resources.InvalidAbsencePeriod);
            }
            else if (Program.TimeMgr.IsOverlapping(tempTimePeriod, timePeriod))
            {
                erpValidation.SetError(btnOK, Properties.Resources.OverlappingAbsence);
            }
            else
            {
                ApplyInput();
                DialogResult = DialogResult.OK;

                Close();
            }
        }

        /// <summary>
        ///   Handles a click on the cancel button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
