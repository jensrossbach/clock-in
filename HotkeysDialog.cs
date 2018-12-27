// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   Dialog window for hotkey settings
    /// </summary>
    public partial class HotkeysDialog : Form
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public HotkeysDialog()
        {
            InitializeComponent();
        }


        /// <summary>
        ///   Handles the event when a hotkey control gained the focus.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void HotkeyControl_Enter(object sender, EventArgs e)
        {
            Program.HotkeyMgr.HotkeysEnabled = false;
        }

        /// <summary>
        ///   Handles the event when a hotkey control lost the focus.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void HotkeyControl_Leave(object sender, EventArgs e)
        {
            Program.HotkeyMgr.HotkeysEnabled = true;
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
    }
}
