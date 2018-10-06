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
            TopMost = Properties.Settings.Default.NotificationAlwaysOnTop;
        }

        public void Initialize(Image img, string text, bool approaching)
        {
            lblIcon.Image = img;
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
        }

        private void NotificationDialog_Shown(object sender, EventArgs e)
        {
            BringToFront();
        }

        private void NotificationDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cbxNotifyAgain.Checked)
            {
                Program.TimeMgr.RestartMaxTimeTimer((int)nmcNotifyAgain.Value);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
