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
