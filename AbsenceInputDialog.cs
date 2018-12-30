// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


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

            erpValidation.SetIconAlignment(btnOK, ErrorIconAlignment.MiddleLeft);
            erpValidation.SetIconPadding(btnOK, 2);

            dtpBeginTime.DataBindings.Add("Value", tempTimePeriod, "StartTime");
            dtpEndTime.DataBindings.Add("Value", tempTimePeriod, "EndTime");
        }


        /// <summary>
        ///   Status if entered time period is valid
        /// </summary>
        /// <returns>true if time period is valid, false otherwise</returns>
        private bool ValidTimePeriod => tempTimePeriod.StartTime < tempTimePeriod.EndTime;

        /// <summary>
        ///   Status if entered time period is overlapping with other time periods
        /// </summary>
        /// <returns>true if time period is overlapping, false otherwise</returns>
        private bool Overlapping
        {
            get
            {
                foreach (TimePeriod tp in Program.TimeMgr.Absence)
                {
                    if ((tp != timePeriod) && tp.Intersecting(tempTimePeriod))
                    {
                        return true;
                    }
                }

                return false;
            }
        }


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
            else if (Overlapping)
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
