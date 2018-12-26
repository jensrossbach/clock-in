// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ClockIn
{
    /// <summary>
    /// A simple control that allows the user to select pretty much any valid hotkey combination.
    /// </summary>
    public class HotkeyControl : TextBox
    {
        /// <summary>
        ///   Creates a new HotkeyControl.
        /// </summary>
        public HotkeyControl()
        {
            ContextMenu = emptyContextMenu; // Disable right-clicking
            Text = Properties.Resources.KeyNone;

            // Handle events that occurs when keys are pressed
            KeyPress += new KeyPressEventHandler(HotkeyControl_KeyPress);
            KeyUp += new KeyEventHandler(HotkeyControl_KeyUp);
            KeyDown += new KeyEventHandler(HotkeyControl_KeyDown);

            // Fill the ArrayLists that contain all invalid hotkey combinations
            PopulateModifierLists();
        }

        /// <summary>
        ///   Used to make sure that there is no right-click menu available.
        /// </summary>
        public override ContextMenu ContextMenu
        {
            get
            {
                return emptyContextMenu;
            }
            set
            {
                base.ContextMenu = emptyContextMenu;
            }
        }

        /// <summary>
        ///   Forces the control to be non-multiline.
        /// </summary>
        public override bool Multiline
        {
            get
            {
                return base.Multiline;
            }
            set
            {
                // Ignore what the user wants; force Multiline to false
                base.Multiline = false;
            }
        }

        /// <summary>
        ///   Used to get/set the hotkey.
        /// </summary>
        public Keys Hotkey
        {
            get
            {
                return ClockIn.Hotkey.Merge(keyModifiers, keyCode);
            }
            set
            {
                ClockIn.Hotkey.Split(value, out keyModifiers, out keyCode);
                Render(true);
            }
        }

        /// <summary>
        ///   Used to get/set the hotkey key code (e.g. Keys.A).
        /// </summary>
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Keys KeyCode
        {
            get
            {
                return keyCode;
            }
            set
            {
                keyCode = value;
                Render(true);
            }
        }

        /// <summary>
        ///   Used to get/set the hotkey modifiers (e.g. Keys.Alt | Keys.Control).
        /// </summary>
		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Keys KeyModifiers
        {
            get
            {
                return keyModifiers;
            }
            set
            {
                keyModifiers = value;
                Render(true);
            }
        }

        /// <summary>
        ///   Clears the current hotkey and resets the TextBox.
        /// </summary>
        public new void Clear()
        {
            ResetHotkey();
        }

        /// <summary>
        ///   Clears the current hotkey and resets the TextBox.
        /// </summary>
        public void ResetHotkey()
        {
            Console.WriteLine("HotkeyControl: ResetHotkey");
            keyCode = Keys.None;
            keyModifiers = Keys.None;
            Render();
        }

        /// <summary>
        ///   Handles some misc keys, such as Ctrl+Delete and Shift+Insert.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Delete) || (keyData == (Keys.Control | Keys.Delete)))
            {
                ResetHotkey();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Insert)) // Paste
            {
                return true; // Don't allow
            }

            // Allow the rest
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        ///   Populates the ArrayLists specifying disallowed hotkeys
        ///   such as Shift+A, Ctrl+Alt+4 (would produce a dollar sign), etc.
        /// </summary>
        private void PopulateModifierLists()
        {
            // Shift + 0 - 9, A - Z
            for (Keys k = Keys.D0; k <= Keys.Z; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Numpad keys
            for (Keys k = Keys.NumPad0; k <= Keys.NumPad9; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Misc (,;<./ etc)
            for (Keys k = Keys.Oem1; k <= Keys.OemBackslash; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Shift + Space, PgUp, PgDn, End, Home
            for (Keys k = Keys.Space; k <= Keys.Home; k++)
            {
                needNonShiftModifier.Add((int)k);
            }

            // Misc keys that we can't loop through
            needNonShiftModifier.Add((int)Keys.Insert);
            needNonShiftModifier.Add((int)Keys.Help);
            needNonShiftModifier.Add((int)Keys.Multiply);
            needNonShiftModifier.Add((int)Keys.Add);
            needNonShiftModifier.Add((int)Keys.Subtract);
            needNonShiftModifier.Add((int)Keys.Divide);
            needNonShiftModifier.Add((int)Keys.Decimal);
            needNonShiftModifier.Add((int)Keys.Return);
            needNonShiftModifier.Add((int)Keys.Escape);
            needNonShiftModifier.Add((int)Keys.NumLock);
            needNonShiftModifier.Add((int)Keys.Scroll);
            needNonShiftModifier.Add((int)Keys.Pause);

            // Ctrl+Alt + 0 - 9
            for (Keys k = Keys.D0; k <= Keys.D9; k++)
            {
                needNonAltGrModifier.Add((int)k);
            }
        }

        /// <summary>
        ///   Helper function
        /// </summary>
        private void Render()
        {
            Render(false);
        }

        /// <summary>
        ///   Redraws the TextBox when necessary.
        /// </summary>
        /// <param name="calledProgramatically">
        ///   Specifies whether this function was called by the Hotkey/HotkeyModifiers properties or by the user.
        /// </param>
        private void Render(bool calledProgramatically)
        {
            // No hotkey set
            if (keyCode == Keys.None)
            {
                Text = Properties.Resources.KeyNone;
                return;
            }

            // LWin/RWin doesn't work as hotkeys (neither do they work as modifier keys in .NET 2.0)
            if ((keyCode == Keys.LWin) || (keyCode == Keys.RWin))
            {
                keyCode = Keys.None;
                Text = Properties.Resources.KeyNone;

                return;
            }

            // Only validate input if it comes from the user
            if (!calledProgramatically)
            {
                // No modifier or shift only, AND a hotkey that needs another modifier
                if (((keyModifiers == Keys.Shift) || (keyModifiers == Keys.None)) &&
                    needNonShiftModifier.Contains((int)keyCode))
                {
                    if (keyModifiers == Keys.None)
                    {
                        // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                        if (!needNonAltGrModifier.Contains((int)keyCode))
                        {
                            keyModifiers = Keys.Control | Keys.Alt;
                        }
                        else // ... in that case, use Shift+Alt instead.
                        {
                            keyModifiers = Keys.Shift | Keys.Alt;
                        }
                    }
                    else
                    {
                        // User pressed Shift and an invalid key (e.g. a letter or a number),
                        // that needs another set of modifier keys
                        keyCode = Keys.None;
                        Text = Properties.Resources.KeyInvalid;

                        return;
                    }
                }

                // Check all Ctrl+Alt keys
                if ((keyModifiers == (Keys.Control | Keys.Alt)) &&
                    needNonAltGrModifier.Contains((int)keyCode))
                {
                    // Ctrl+Alt+4 etc. won't work; reset hotkey and tell the user
                    keyCode = Keys.None;
                    Text = Properties.Resources.KeyInvalid;

                    return;
                }
            }

            if (keyModifiers == Keys.None)
            {
                if (keyCode == Keys.None)
                {
                    Text = Properties.Resources.KeyNone;
                    return;
                }
                else
                {
                    // We get here if we've got a hotkey that is valid without a modifier,
                    // like F1-F12, Media-keys etc.
                    Text = HotkeyToString(keyCode);
                    return;
                }
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if ((keyCode == Keys.Menu) /* Alt */ || (keyCode == Keys.ShiftKey) || (keyCode == Keys.ControlKey))
            {
                keyCode = Keys.None;
            }

            if (keyCode == Keys.None)
            {
                Text = ModifiersToString(keyModifiers);
            }
            else
            {
                Text = ModifiersToString(keyModifiers) + " + " + HotkeyToString(keyCode);
            }
        }

        /// <summary>
        ///   Converts modifiers into a string representation.
        /// </summary>
        /// <param name="modifiers">Modifiers to be converted</param>
        /// <returns>String representation of the modifiers</returns>
        private string ModifiersToString(Keys modifiers)
        {
            string str = string.Empty;

            if ((modifiers & Keys.Control) != Keys.None)
            {
                str = Properties.Resources.KeyControl;
            }

            if ((modifiers & Keys.Shift) != Keys.None)
            {
                if (str.Length > 0)
                {
                    str += " + ";
                }

                str += Properties.Resources.KeyShift;
            }

            if ((modifiers & Keys.Alt) != Keys.None)
            {
                if (str.Length > 0)
                {
                    str += " + ";
                }

                str += Properties.Resources.KeyAlt;
            }

            return str;
        }

        /// <summary>
        ///   Converts a raw key into a string representation.
        /// </summary>
        /// <param name="hotKey">Raw key to be converted</param>
        /// <returns>String representation of the raw key</returns>
        private string HotkeyToString(Keys hotKey)
        {
            string str = null;

            switch (hotKey)
            {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                    {
                        str = string.Empty + KeyCodeToChar(hotKey);
                        break;
                    }
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.Divide:
                case Keys.Multiply:
                case Keys.Add:
                case Keys.Subtract:
                case Keys.Decimal:
                    {
                        str = KeyCodeToChar(hotKey) + " (" + Properties.Resources.KeyNumpad + ")";
                        break;
                    }
                case Keys.Oem1:
                case Keys.Oem2:
                case Keys.Oem3:
                case Keys.Oem4:
                case Keys.Oem5:
                case Keys.Oem6:
                case Keys.Oem7:
                case Keys.Oem8:
                case Keys.OemBackslash:
                case Keys.OemClear:
                case Keys.Oemcomma:
                case Keys.OemMinus:
                case Keys.OemPeriod:
                case Keys.Oemplus:
                    {
                        str = (string.Empty + KeyCodeToChar(hotKey)).ToUpper();
                        break;
                    }
                case Keys.Insert:
                    {
                        str = Properties.Resources.KeyInsert;
                        break;
                    }
                case Keys.Delete:
                    {
                        str = Properties.Resources.KeyDelete;
                        break;
                    }
                case Keys.Home:
                    {
                        str = Properties.Resources.KeyHome;
                        break;
                    }
                case Keys.End:
                    {
                        str = Properties.Resources.KeyEnd;
                        break;
                    }
                case Keys.PageUp:
                    {
                        str = Properties.Resources.KeyPageUp;
                        break;
                    }
                case Keys.PageDown:
                    {
                        str = Properties.Resources.KeyPageDown;
                        break;
                    }
                case Keys.Enter:
                    {
                        str = Properties.Resources.KeyEnter;
                        break;
                    }
                case Keys.Left:
                    {
                        str = Properties.Resources.KeyLeft;
                        break;
                    }
                case Keys.Right:
                    {
                        str = Properties.Resources.KeyRight;
                        break;
                    }
                case Keys.Up:
                    {
                        str = Properties.Resources.KeyUp;
                        break;
                    }
                case Keys.Down:
                    {
                        str = Properties.Resources.KeyDown;
                        break;
                    }
                case Keys.Escape:
                    {
                        str = Properties.Resources.KeyEscape;
                        break;
                    }
                case Keys.PrintScreen:
                    {
                        str = Properties.Resources.KeyPrint;
                        break;
                    }
                case Keys.Pause:
                    {
                        str = Properties.Resources.KeyPause;
                        break;
                    }
                case Keys.Tab:
                    {
                        str = Properties.Resources.KeyTabulator;
                        break;
                    }
                case Keys.NumLock:
                    {
                        str = Properties.Resources.KeyNumLock;
                        break;
                    }
                case Keys.CapsLock:
                    {
                        str = Properties.Resources.KeyCapsLock;
                        break;
                    }
                case Keys.Scroll:
                    {
                        str = Properties.Resources.KeyScrollLock;
                        break;
                    }
                default:
                    {
                        str = hotKey.ToString();
                        break;
                    }
            }

            return str;
        }

        /// <summary>
        ///   Converts a key code into a character.
        /// </summary>
        /// <param name="keyCode">Key code to be converted</param>
        /// <returns>Key code as character</returns>
        private char KeyCodeToChar(Keys keyCode)
        {
            return (char)MapVirtualKey((uint)keyCode, VirtualKeyToVirtualChar);
        }

        /// <summary>
        ///   Fires when a key is pushed down. Here, we'll want to update the text in the box
        ///   to notify the user what combination is currently pressed.
        /// </summary>
        private void HotkeyControl_KeyDown(object sender, KeyEventArgs e)
        {
            // Clear the current hotkey
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                ResetHotkey();
                return;
            }
            else
            {
                keyModifiers = e.Modifiers;
                keyCode = e.KeyCode;

                Render();
            }
        }

        /// <summary>
        ///   Fires when all keys are released. If the current hotkey isn't valid, reset it.
        ///   Otherwise, do nothing and keep the text and hotkey as it was.
        /// </summary>
        private void HotkeyControl_KeyUp(object sender, KeyEventArgs e)
        {
            if ((keyCode == Keys.None) && (Control.ModifierKeys == Keys.None))
            {
                ResetHotkey();
                return;
            }
        }

        /// <summary>
        ///   Prevents the letter/whatever entered to show up in the TextBox
        ///   Without this, a "A" key press would appear as "aControl, Alt + A".
        /// </summary>
        private void HotkeyControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private const uint VirtualKeyToVirtualScanCode = 0x00;
        private const uint VirtualScanCodeToVirtualKey = 0x01;
        private const uint VirtualKeyToVirtualChar = 0x02;
        private const uint VirtualScanCodeToVirtualKeyEx = 0x03;
        private const uint VirtualKeyToVirtualScanCodeEx = 0x04;

        // These variables store the current hotkey and modifier(s)
        private Keys keyCode = Keys.None;
        private Keys keyModifiers = Keys.None;

        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private ArrayList needNonShiftModifier = new ArrayList();
        private ArrayList needNonAltGrModifier = new ArrayList();

        private ContextMenu emptyContextMenu = new ContextMenu();
    }
}
