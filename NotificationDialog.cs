// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   Dialog window for time notifications
    /// </summary>
    public partial class NotificationDialog : Form
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        /// <param name="img">Icon to be shown</param>
        /// <param name="text">Text to be shown</param>
        /// <param name="enableNotifyAgain">true if controls for repeating notification should be shown</param>
        public NotificationDialog(Image img, string text, bool enableNotifyAgain)
        {
            InitializeComponent();

            TopMost = Properties.Settings.Default.NotificationAlwaysOnTop;

            lblIcon.Image = img;
            lblText.Text = text;

            if (enableNotifyAgain)
            {
                cbxNotifyAgain.Visible = true;
                nmcNotifyAgain.Visible = true;
                lblMin.Visible = true;

                cbxNotifyAgain.Checked = true;
            }
            else
            {
                cbxNotifyAgain.Visible = false;
                nmcNotifyAgain.Visible = false;
                lblMin.Visible = false;

                cbxNotifyAgain.Checked = false;
            }
        }


        /// <summary>
        ///   Handles the event when the dialog window is loading.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NotificationDialog_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.PlaySound && (Properties.Settings.Default.SoundFile != ""))
            {
                SoundPlayer player = new SoundPlayer(Properties.Settings.Default.SoundFile);
                player.Play();
            }
        }

        /// <summary>
        ///   Handles the event when the dialog window is shown.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NotificationDialog_Shown(object sender, EventArgs e)
        {
            BringToFront();
        }

        /// <summary>
        ///   Handles the event when the dialog window has been closed.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void NotificationDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cbxNotifyAgain.Checked)
            {
                Program.TimeMgr.RepeatNotificationTimer((int)nmcNotifyAgain.Value);
            }
        }

        /// <summary>
        ///   Handles a click on the okay button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
