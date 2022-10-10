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
