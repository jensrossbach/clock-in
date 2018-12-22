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
        private bool ValidTimePeriod
        {
            get
            {
                if (tempTimePeriod.StartTime < tempTimePeriod.EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

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
                    if ((tp != timePeriod) && (tp.Intersecting(tempTimePeriod)))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        ///   Status if entered input is valid
        /// </summary>
        /// <returns>true if input is valid, false otherwise</returns>
        private bool ValidInput
        {
            get
            {
                if (!ValidTimePeriod)
                {
                    MessageBox.Show(Properties.Resources.InvalidAbsencePeriod,
                                    Properties.Resources.WindowCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return false;
                }
                else if (Overlapping)
                {
                    MessageBox.Show(Properties.Resources.OverlappingAbsence,
                                    Properties.Resources.WindowCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return false;
                }
                else
                {
                    ApplyInput();
                    return true;
                }
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
            if (ValidInput)
            {
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

        private TimePeriod timePeriod;
        private TimePeriod tempTimePeriod;
    }
}
