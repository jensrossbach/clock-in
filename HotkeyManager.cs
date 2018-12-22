// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ClockIn
{
    /// <summary>
    ///   Listens for key presses and manages registered hotkeys.
    /// </summary>
    static class HotkeyManager
    {
        /// <summary>
        ///   Enables or disables hotkey handling.
        /// </summary>
        public static bool HotkeysEnabled { get; set; } = true;

        /// <summary>
        ///   Initializes the hotkey manager.
        /// </summary>
        public static void Init()
        {
            if (handlerID == IntPtr.Zero)
            {
                hotKeys = new ArrayList();
                HotkeysEnabled = true;

                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    handlerID = SetWindowsHookEx(WH_KEYBOARD_LL, keyHandler, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        /// <summary>
        ///   Deinitializes the hotkey manager.
        /// </summary>
        public static void Deinit()
        {
            if (handlerID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(handlerID);
            }
        }

        /// <summary>
        ///   Registers a new hotkey.
        /// </summary>
        /// <param name="hotKey">Hotkey to register</param>
        public static void RegisterHotkey(Hotkey hotKey)
        {
            hotKeys.Add(hotKey);
        }

        /// <summary>
        ///   Unregisters a new hotkey.
        /// </summary>
        /// <param name="hotKey">Hotkey to unregister</param>
        public static void UnregisterHotkey(Hotkey hotKey)
        {
            hotKeys.Remove(hotKey);
        }

        /// <summary>
        ///   Handles system key events.
        /// </summary>
        /// <see>LowLevelKeyboardProc for more information</see>
        private static IntPtr KeyHandler(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (HotkeysEnabled && (nCode >= 0) && ((wParam == (IntPtr)WM_KEYDOWN) || (wParam == (IntPtr)WM_SYSKEYDOWN)))
            {
                int keyCode = Marshal.ReadInt32(lParam);

                if ((keyCode != MOD_LWIN) &&
                    (keyCode != MOD_LSHIFT) && (keyCode != MOD_RSHIFT) &&
                    (keyCode != MOD_LCTRL) && (keyCode != MOD_RCTRL) &&
                    (keyCode != MOD_LALT) && (keyCode != MOD_RALT))
                {
                    foreach (Hotkey hk in hotKeys)
                    {
                        if ((Control.ModifierKeys == hk.Modifiers) && ((Keys)keyCode == hk.Code))
                        {
                            hk.TriggerEvent();
                        }
                    }
                }
            }

            return CallNextHookEx(handlerID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        private const int MOD_LWIN   = 0x5B;
        private const int MOD_LSHIFT = 0xA0;
        private const int MOD_RSHIFT = 0xA1;
        private const int MOD_LCTRL  = 0xA2;
        private const int MOD_RCTRL  = 0xA3;
        private const int MOD_LALT   = 0xA4;
        private const int MOD_RALT   = 0xA5;

        private static readonly LowLevelKeyboardProc keyHandler = KeyHandler;
        private static IntPtr handlerID = IntPtr.Zero;

        private static ArrayList hotKeys = null;
    }
}
