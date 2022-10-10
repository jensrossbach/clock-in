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
        public abstract event HandledEventHandler Press;


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
    public class HotkeyManager
    {
        private const uint WM_HOTKEY = 0x0312;


        private ArrayList globalHotkeys = new ArrayList();


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
        /// <exception cref="HotkeyRegisterException">Thrown when hotkey registration failed.</exception>
        public Hotkey RegisterHotkey(Keys key, Control window)
        {
            GlobalHotkey ghk = new GlobalHotkey(key);

            ghk.Register(window);
            globalHotkeys.Add(ghk);

            return ghk;
        }

        /// <summary>
        ///   Re-registers a hotkey.
        /// </summary>
        /// <param name="hotkey">Hotkey to re-register</param>
        /// <param name="key">New key combination</param>
        /// <param name="window">Control to register hotkey with</param>
        /// <exception cref="ArgumentException">Thrown when argument hotkey is null.</exception>
        /// <exception cref="HotkeyRegisterException">Thrown when hotkey registration failed.</exception>
        public void ReregisterHotkey(Hotkey hotkey, Keys key, Control window)
        {
            if (hotkey == null)
            {
                throw new ArgumentException("Argument must not be null", "hotkey");
            }

            GlobalHotkey ghk = (GlobalHotkey)hotkey;

            Keys oldKey = ghk.Key;
            if (key != oldKey)
            {
                ghk.Unregister();
                ghk.Key = key;

                try
                {
                    ghk.Register(window);
                }
                catch (HotkeyRegisterException)
                {
                    ghk.Key = oldKey;
                    throw;
                }
            }
        }

        /// <summary>
        ///   Unregisters a new hotkey.
        /// </summary>
        /// <param name="hotkey">Hotkey to unregister</param>
        public void UnregisterHotkey(Hotkey hotkey)
        {
            if (hotkey != null)
            {
                GlobalHotkey ghk = (GlobalHotkey)hotkey;

                ghk.Unregister();
                globalHotkeys.Remove(ghk);
            }
        }

        /// <summary>
        ///  Processes hotkey messages.
        /// </summary>
        /// <param name="msg">Message to process</param>
        public bool ProcessMessage(ref Message msg)
        {
            bool ret = false;

            if ((msg.Msg == WM_HOTKEY) && HotkeysEnabled)
            {
                foreach (GlobalHotkey ghk in globalHotkeys)
                {
                    if (msg.WParam.ToInt32() == ghk.Identifier)
                    {
                        ret = ghk.TriggerEvent();
                        break;
                    }
                }
            }

            return ret;
        }


        /// <summary>
        ///   Global hotkey implementation
        /// </summary>
        private class GlobalHotkey : Hotkey, IDisposable
        {
            /// <summary>
            ///   Event notifies when hotkey has been pressed.
            /// </summary>
            public override event HandledEventHandler Press;


            private const uint MOD_ALT     = 0x0001;
            private const uint MOD_CONTROL = 0x0002;
            private const uint MOD_SHIFT   = 0x0004;

            private const uint ERROR_HOTKEY_ALREADY_REGISTERED = 1409;


            private Keys modifiers = Keys.None;
            private Keys code = Keys.None;

            private KeysConverter keyConv = new KeysConverter();

            private IntPtr hWnd = IntPtr.Zero;


            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


            /// <summary>
            ///   Constructs the hotkey from modifiers and key code.
            /// </summary>
            /// <param name="modifiers">Modifiers of the hotkey</param>
            /// <param name="code">Key code of the hotkey</param>
            public GlobalHotkey(Keys modifiers, Keys code)
            {
                this.modifiers = modifiers;
                this.code = code;
            }

            /// <summary>
            ///   Constructs the hotkey from a raw key.
            /// </summary>
            /// <param name="hotKey">Raw key</param>
            public GlobalHotkey(Keys hotKey)
            {
                Split(hotKey, out modifiers, out code);
            }

            /// <summary>
            ///   Destructs the hotkey.
            /// </summary>
            ~GlobalHotkey()
            {
                Unregister();
            }


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
                set => Split(value, out modifiers, out code);
            }

            /// <summary>
            ///   Identifier of the hotkey
            /// </summary>
            public int Identifier { get; private set; } = 0;


            /// <summary>
            ///   Registers the hotkey at the system.
            /// </summary>
            /// <param name="window">Control to assign hotkey to</param>
            /// <exception cref="ArgumentException">Thrown when argument window is null.</exception>
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
            /// <exception cref="HotkeyRegisterException">Thrown when hotkey registration failed.</exception>
            private void Register(IntPtr winHandle)
            {
                if ((hWnd == IntPtr.Zero) && (modifiers != Keys.None) && (code != Keys.None))
                {
                    uint mod = (((modifiers & Keys.Control) != Keys.None) ? MOD_CONTROL : 0) |
                               (((modifiers & Keys.Alt) != Keys.None) ? MOD_ALT : 0) |
                               (((modifiers & Keys.Shift) != Keys.None) ? MOD_SHIFT : 0);

                    Identifier = (int)mod ^ (int)code ^ winHandle.ToInt32();

                    if (RegisterHotKey(winHandle, Identifier, mod, (uint)code))
                    {
                        Debug.WriteLine("[GlobalHotkey] Hotkey " + ToString() + " successfully registered.");

                        hWnd = winHandle;
                    }
                    else
                    {
                        Debug.WriteLine("[GlobalHotkey] Failed to register hotkey " + ToString() + "!");

                        Identifier = 0;

                        if (Marshal.GetLastWin32Error() == ERROR_HOTKEY_ALREADY_REGISTERED)
                        {
                            throw new HotkeyRegisterException(string.Format(Properties.Resources.HotkeyAlreadyRegistered, ToString()));
                        }
                        else
                        {
                            throw new HotkeyRegisterException(string.Format(Properties.Resources.HotkeyFailedToRegister, ToString()));
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
                        Debug.WriteLine("[GlobalHotkey] Hotkey " + ToString() + " successfully unregistered.");

                        hWnd = IntPtr.Zero;
                        Identifier = 0;
                    }
                    else
                    {
                        Debug.WriteLine("[GlobalHotkey] Failed to unregister hotkey " + ToString() + "!");
                    }
                }
            }

            /// <summary>
            ///   Triggers the hotkey pressed notification.
            /// </summary>
            public bool TriggerEvent()
            {
                HandledEventArgs e = new HandledEventArgs();
                Press?.Invoke(this, e);

                return e.Handled;
            }

            /// <summary>
            ///   Releases unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Unregister();
                GC.SuppressFinalize(this);
            }

            public override string ToString() => keyConv.ConvertToString(Merge(modifiers, code));
        }
    }
}
