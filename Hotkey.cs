// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   Class representing a hotkey (pressed key combination)
    /// </summary>
    class Hotkey
    {
        /// <summary>
        ///   Constructs the hotkey from modifiers and key code
        /// </summary>
        /// <param name="modifiers">Modifiers of the hotkey</param>
        /// <param name="code">Key code of the hotkey</param>
        public Hotkey(Keys modifiers, Keys code)
        {
            this.modifiers = modifiers;
            this.code = code;

            enabled = true;
        }

        /// <summary>
        ///   Constructs the hotkey from a raw key
        /// </summary>
        /// <param name="hotKey">Raw key</param>
        public Hotkey(Keys hotKey)
        {
            modifiers = (Keys)((uint)hotKey & 0xFFFF0000U);
            code = (Keys)((uint)hotKey & 0x0000FFFFU);

            enabled = true;
        }

        /// <summary>
        ///   Event notifies when hotkey has been pressed.
        /// </summary>
        public event EventHandler HotkeyPressed;

        /// <summary>
        ///   Modifiers (ctrl, alt, shift) of the pressed key combination
        /// </summary>
        public Keys Modifiers
        {
            get
            {
                return modifiers;
            }
        }

        /// <summary>
        ///   Key code of the pressed key combination
        /// </summary>
        public Keys Code
        {
            get
            {
                return code;
            }
        }

        /// <summary>
        ///   Raw key
        /// </summary>
        public Keys Key
        {
            get
            {
                return ConstructHotkey(modifiers, code);
            }
            set
            {
                SplitHotkey(value, out modifiers, out code);
            }
        }

        /// <summary>
        ///   Enables or disables the hotkey
        /// </summary>
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        /// <summary>
        ///   Triggers the hotkey pressed notification
        /// </summary>
        public void TriggerEvent()
        {
            if (enabled)
            {
                NotifyHotkeyPressed(new EventArgs());
            }
        }

        /// <summary>
        ///   Splits a raw key into modifiers and key code
        /// </summary>
        /// <param name="hotKey">Raw key</param>
        /// <param name="modifiers">Modifiers of the hotkey</param>
        /// <param name="code">Key code of the hotkey</param>
        public static void SplitHotkey(Keys hotKey, out Keys modifiers, out Keys code)
        {
            code = (Keys)((uint)hotKey & 0x0000FFFFU);
            modifiers = (Keys)((uint)hotKey & 0xFFFF0000U);
        }

        /// <summary>
        ///   Constructs a raw key from modifiers and key code
        /// </summary>
        /// <param name="modifiers">Modifiers of the hotkey</param>
        /// <param name="code">Key code of the hotkey</param>
        /// <returns>Constructed raw key</returns>
        public static Keys ConstructHotkey(Keys modifiers, Keys code) => (modifiers | code);

        private void NotifyHotkeyPressed(EventArgs e)
        {
            HotkeyPressed?.Invoke(this, e);
        }

        private Keys modifiers = Keys.None;
        private Keys code = Keys.None;
        private bool enabled = false;
    }
}
