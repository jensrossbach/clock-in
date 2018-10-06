using System;
using System.Windows.Forms;


namespace ClockIn
{
    class Hotkey
    {
        public Keys Modifiers
        {
            get
            {
                return modifiers;
            }
        }

        public Keys Code
        {
            get
            {
                return code;
            }
        }

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

        public Hotkey(Keys modifiers, Keys code)
        {
            this.modifiers = modifiers;
            this.code = code;

            enabled = true;
        }

        public Hotkey(Keys hotKey)
        {
            modifiers = (Keys)((uint)hotKey & 0xFFFF0000U);
            code = (Keys)((uint)hotKey & 0x0000FFFFU);

            enabled = true;
        }

        public void TriggerEvent()
        {
            if (enabled)
            {
                NotifyHotkeyPressed(new EventArgs());
            }
        }

        public static void SplitHotkey(Keys hotKey, out Keys modifiers, out Keys code)
        {
            code = (Keys)((uint)hotKey & 0x0000FFFFU);
            modifiers = (Keys)((uint)hotKey & 0xFFFF0000U);
        }

        public static Keys ConstructHotkey(Keys modifiers, Keys code)
        {
            return (modifiers | code);
        }

        private void NotifyHotkeyPressed(EventArgs e)
        {
            if (HotkeyPressed != null)
            {
                HotkeyPressed(this, e);
            }
        }

        public event EventHandler HotkeyPressed;

        private Keys modifiers = Keys.None;
        private Keys code = Keys.None;
        private bool enabled = false;
    }
}
