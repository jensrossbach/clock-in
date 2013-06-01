using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


namespace ClockIn
{
    public partial class NotificationDialog : Form
    {
        public NotificationDialog()
        {
            InitializeComponent();
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Size.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Size.Height) / 2);
        }

        public void initialize(int iconIndex, string text, bool approaching)
        {
            lblIcon.ImageIndex = iconIndex;
            lblText.Text = text;

            if (approaching)
            {
                cbxNotifyAgain.Visible = true;
                nmcNotifyAgain.Visible = true;
                lblMin.Visible = true;

                cbxNotifyAgain.Checked = true;
                nmcNotifyAgain.Value = Properties.Settings.Default.NotifyAdvance;
            }
            else
            {
                cbxNotifyAgain.Visible = false;
                nmcNotifyAgain.Visible = false;
                lblMin.Visible = false;

                cbxNotifyAgain.Checked = false;
            }
        }

        private void NotificationDialog_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.PlaySound && (Properties.Settings.Default.SoundFile != ""))
            {
                SoundPlayer player = new SoundPlayer(Properties.Settings.Default.SoundFile);
                player.Play();
            }

            BringToFront();
        }

        private void NotificationDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cbxNotifyAgain.Checked)
            {
                Program.TimeMgr.restartMaxTimeTimer((int)nmcNotifyAgain.Value);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
