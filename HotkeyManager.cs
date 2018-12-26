// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace ClockIn
{
    /// <summary>
    ///   Class representing a hotkey (pressed key combination)
    /// </summary>
    public abstract class Hotkey
    {
        /// <summary>
        ///   Event notifies when hotkey has been pressed.
        /// </summary>
        public abstract event HandledEventHandler Pressed;

        /// <summary>
        ///   Key modifiers (ctrl, alt, shift) of the hotkey's key combination
        /// </summary>
        public abstract Keys Modifiers { get; }

        /// <summary>
        ///   Key code of the hotkey's key combination
        /// </summary>
        public abstract Keys Code { get; }

        /// <summary>
        ///   Splits a key combination into key modifiers and key code
        /// </summary>
        /// <param name="combo">Key combination</param>
        /// <param name="modifiers">Key modifiers of the hotkey</param>
        /// <param name="code">Key code of the hotkey</param>
        public static void Split(Keys combo, out Keys modifiers, out Keys code)
        {
            code = (Keys)((uint)combo & 0x0000FFFFU);
            modifiers = (Keys)((uint)combo & 0xFFFF0000U);
        }

        /// <summary>
        ///   Merges key modifiers and key code to a key combination
        /// </summary>
        /// <param name="modifiers">Key modifiers of the hotkey</param>
        /// <param name="code">Key code of the hotkey</param>
        /// <returns>Constructed raw key</returns>
        public static Keys Merge(Keys modifiers, Keys code) => (modifiers | code);
    }

    /// <summary>
    ///   Exception during hotkey registration
    /// </summary>
    public class HotkeyRegisterException : Exception
    {
        public HotkeyRegisterException(string message) : base(message) { }
        public HotkeyRegisterException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    ///   Listens for key presses and manages registered hotkeys.
    /// </summary>
    public class HotkeyManager : IMessageFilter
    {
        private const uint WM_HOTKEY = 0x0312;

        /// <summary>
        ///   Enables or disables hotkey handling.
        /// </summary>
        public bool HotkeysEnabled { get; set; } = true;

        /// <summary>
        ///   Registers a new hotkey.
        /// </summary>
        /// <param name="key">Key combination to register</param>
        /// <param name="window">Control to assign hotkey to</param>
        /// <returns>Registered hotkey</returns>
        public Hotkey RegisterHotkey(Keys key, Control window)
        {
            GlobalHotkey ghk = null;

            try
            {
                ghk = new GlobalHotkey(key);
                ghk.Register(window);

                if (globalHotkeys.Count == 0)
                {
                    Application.AddMessageFilter(this);
                }

                globalHotkeys.Add(ghk);
            }
            catch (HotkeyRegisterException e)
            {
                MessageBox.Show(e.Message,
                                Properties.Resources.WindowCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            return ghk;
        }

        /// <summary>
        ///   Re-registers a hotkey.
        /// </summary>
        /// <param name="hotkey">Hotkey to re-register</param>
        /// <param name="key">New key combination</param>
        /// <param name="window">Control to register hotkey with</param>
        public void ReregisterHotkey(Hotkey hotkey, Keys key, Control window)
        {
            GlobalHotkey ghk = (GlobalHotkey)hotkey;

            Keys oldKey = ghk.Key;
            ghk.Key = key;

            try
            {
                ghk.Register(window);
            }
            catch (HotkeyRegisterException e)
            {
                ghk.Key = oldKey;
                MessageBox.Show(e.Message,
                                Properties.Resources.WindowCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///   Unregisters a new hotkey.
        /// </summary>
        /// <param name="hotkey">Hotkey to unregister</param>
        public void UnregisterHotkey(Hotkey hotkey)
        {
            GlobalHotkey ghk = (GlobalHotkey)hotkey;

            ghk.Unregister();
            globalHotkeys.Remove(ghk);

            if (globalHotkeys.Count == 0)
            {
                Application.RemoveMessageFilter(this);
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            bool ret = false;

            if ((m.Msg == WM_HOTKEY) && HotkeysEnabled)
            {
                foreach (GlobalHotkey ghk in globalHotkeys)
                {
                    if (m.WParam.ToInt32() == ghk.Identifier)
                    {
                        ret = ghk.TriggerEvent();
                        break;
                    }
                }
            }

            return ret;
        }

        private ArrayList globalHotkeys = new ArrayList();

        /// <summary>
        ///   Global hotkey implementation
        /// </summary>
        private class GlobalHotkey : Hotkey, IDisposable
        {
            private const uint MOD_ALT = 0x0001;
            private const uint MOD_CONTROL = 0x0002;
            private const uint MOD_SHIFT = 0x0004;

            private const uint ERROR_HOTKEY_ALREADY_REGISTERED = 1409;

            /// <summary>
            ///   Constructs the hotkey from modifiers and key code.
            /// </summary>
            /// <param name="modifiers">Modifiers of the hotkey</param>
            /// <param name="code">Key code of the hotkey</param>
            public GlobalHotkey(Keys modifiers, Keys code)
            {
                this.modifiers = modifiers;
                this.code = code;

                Enabled = true;
            }

            /// <summary>
            ///   Constructs the hotkey from a raw key.
            /// </summary>
            /// <param name="hotKey">Raw key</param>
            public GlobalHotkey(Keys hotKey)
            {
                Split(hotKey, out modifiers, out code);

                Enabled = true;
            }

            /// <summary>
            ///   Destructs the hotkey.
            /// </summary>
            ~GlobalHotkey()
            {
                Unregister();
            }

            /// <summary>
            ///   Event notifies when hotkey has been pressed.
            /// </summary>
            public override event HandledEventHandler Pressed;

            /// <summary>
            ///   Modifiers (ctrl, alt, shift) of the hotkey's key combination
            /// </summary>
            public override Keys Modifiers => modifiers;

            /// <summary>
            ///   Key code of the hotkey's key combination
            /// </summary>
            public override Keys Code => code;

            /// <summary>
            ///   Key combination of the hotkey
            /// </summary>
            public Keys Key
            {
                get => Merge(modifiers, code);
                set
                {
                    Split(value, out modifiers, out code);
                }
            }

            /// <summary>
            ///   Identifier of the hotkey
            /// </summary>
            public int Identifier { get; private set; } = 0;

            /// <summary>
            ///   Enables or disables the hotkey
            /// </summary>
            public bool Enabled { get; set; } = false;

            /// <summary>
            ///   Registers the hotkey at the system.
            /// </summary>
            /// <param name="window">Control to assign hotkey to</param>
            public void Register(Control window)
            {
                if (window == null)
                {
                    throw new ArgumentException("Argument must not be null", "window");
                }

                Register(window.Handle);
            }

            /// <summary>
            ///   Registers the hotkey at the system.
            /// </summary>
            /// <param name="winHandle">Handle to the main window</param>
            private void Register(IntPtr winHandle)
            {
                // first unregister if already registered
                Unregister();

                if ((hWnd == IntPtr.Zero) && (modifiers != Keys.None) && (code != Keys.None))
                {
                    uint mod = (((modifiers & Keys.Control) != Keys.None) ? MOD_CONTROL : 0) |
                               (((modifiers & Keys.Alt) != Keys.None) ? MOD_ALT : 0) |
                               (((modifiers & Keys.Shift) != Keys.None) ? MOD_SHIFT : 0);

                    Identifier = (int)mod ^ (int)code ^ winHandle.ToInt32();

                    if (RegisterHotKey(winHandle, Identifier, mod, (uint)code))
                    {
                        Debug.WriteLine("[Hotkey] Hotkey successfully registered.");

                        hWnd = winHandle;
                    }
                    else
                    {
                        Debug.WriteLine("[Hotkey] Failed to register hotkey!");

                        Identifier = 0;

                        if (Marshal.GetLastWin32Error() == ERROR_HOTKEY_ALREADY_REGISTERED)
                        {
                            throw new HotkeyRegisterException(Properties.Resources.HotkeyAlreadyRegistered);
                        }
                        else
                        {
                            throw new HotkeyRegisterException(Properties.Resources.HotkeyFailedToRegister);
                        }
                    }
                }
            }

            /// <summary>
            ///   Unregisters the hotkey from the system.
            /// </summary>
            public void Unregister()
            {
                if (hWnd != IntPtr.Zero)
                {
                    if (UnregisterHotKey(hWnd, Identifier))
                    {
                        Debug.WriteLine("[Hotkey] Hotkey successfully unregistered.");

                        hWnd = IntPtr.Zero;
                        Identifier = 0;
                    }
                    else
                    {
                        Debug.WriteLine("[Hotkey] Failed to unregister hotkey!");
                    }
                }
            }

            /// <summary>
            ///   Triggers the hotkey pressed notification.
            /// </summary>
            public bool TriggerEvent()
            {
                bool ret = false;

                if (Enabled)
                {
                    HandledEventArgs e = new HandledEventArgs();
                    Pressed?.Invoke(this, e);

                    ret = e.Handled;
                }

                return ret;
            }

            /// <summary>
            ///   Releases unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Unregister();
                GC.SuppressFinalize(this);
            }

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            private Keys modifiers = Keys.None;
            private Keys code = Keys.None;

            private IntPtr hWnd = IntPtr.Zero;
        }
    }
}
