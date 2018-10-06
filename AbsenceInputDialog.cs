using System.Windows.Forms;


namespace ClockIn
{
    public partial class AbsenceInputDialog : Form
    {
        TimePeriod timePeriod;
        TimePeriod tempTimePeriod;

        public AbsenceInputDialog(TimePeriod tp, string title)
        {
            timePeriod = tp;
            tempTimePeriod = new TimePeriod(tp);

            InitializeComponent();
            Text = title;

            dtpBeginTime.DataBindings.Add("Value", tempTimePeriod, "StartTime");
            dtpEndTime.DataBindings.Add("Value", tempTimePeriod, "EndTime");
        }

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

        private bool ValidInput
        {
            get
            {
                if (!ValidTimePeriod)
                {
                    MessageBox.Show(Properties.Resources.InvalidAbsencePeriod,
                                    Properties.Resources.MessageBoxCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return false;
                }
                else if (Overlapping)
                {
                    MessageBox.Show(Properties.Resources.OverlappingAbsence,
                                    Properties.Resources.MessageBoxCaption,
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

        private void ApplyInput()
        {
            timePeriod.StartTime = tempTimePeriod.StartTime;
            timePeriod.EndTime = tempTimePeriod.EndTime;
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            if (ValidInput)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
