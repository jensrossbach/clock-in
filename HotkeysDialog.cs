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
        private MainWindow mainWindow = null;


        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public HotkeysDialog(MainWindow mainWin)
        {
            mainWindow = mainWin;

            InitializeComponent();

            erpHotkeys.SetIconAlignment(hkcRestoreMainWin, ErrorIconAlignment.MiddleLeft);
            erpHotkeys.SetIconPadding(hkcRestoreMainWin, 2);
            erpHotkeys.SetIconAlignment(hkcClockInOut, ErrorIconAlignment.MiddleLeft);
            erpHotkeys.SetIconPadding(hkcClockInOut, 2);
        }


        /// <summary>
        ///   Handles the event when a hotkey control gained the focus.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="args">Event arguments</param>
        private void HotkeyControl_Enter(object sender, EventArgs args)
        {
            Program.HotkeyMgr.HotkeysEnabled = false;
        }

        /// <summary>
        ///   Handles the event when a hotkey control lost the focus.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="args">Event arguments</param>
        private void HotkeyControl_Leave(object sender, EventArgs args)
        {
            Program.HotkeyMgr.HotkeysEnabled = true;
        }

        /// <summary>
        ///   Handles the event when a hotzkey control is about to validate the input.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="args">Event arguments</param>
        private void HotkeyControl_Validating(object sender, System.ComponentModel.CancelEventArgs args)
        {
            erpHotkeys.SetError((Control)sender, "");

            try
            {
                mainWindow.RegisterHotkey((string)((HotkeyControl)sender).Tag, ((HotkeyControl)sender).Hotkey, false);
            }
            catch (HotkeyRegisterException e)
            {
                erpHotkeys.SetError((Control)sender, e.Message);
                args.Cancel = true;
            }
        }

        /// <summary>
        ///   Handles a click on the close button.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="args">Event arguments</param>
        private void BtnClose_Click(object sender, EventArgs args)
        {
            Close();
        }
    }
}
