using System;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ClockIn
{
    static class HotkeyManager
    {
        public static bool HotkeysEnabled
        {
            get
            {
                return hotkeysEnabled;
            }
            set
            {
                hotkeysEnabled = value;
            }
        }

        public static void Init()
        {
            if (handlerID == IntPtr.Zero)
            {
                hotKeys = new ArrayList();
                hotkeysEnabled = true;

                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    handlerID = SetWindowsHookEx(WH_KEYBOARD_LL, keyHandler, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        public static void Deinit()
        {
            if (handlerID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(handlerID);
            }
        }

        public static void RegisterHotkey(Hotkey hotKey)
        {
            hotKeys.Add(hotKey);
        }

        public static void UnregisterHotkey(Hotkey hotKey)
        {
            hotKeys.Remove(hotKey);
        }

        private static IntPtr KeyHandler(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (hotkeysEnabled && (nCode >= 0) && ((wParam == (IntPtr)WM_KEYDOWN) || (wParam == (IntPtr)WM_SYSKEYDOWN)))
            {
                int keyCode = Marshal.ReadInt32(lParam);

                //Console.WriteLine("Modifiers: " + Control.ModifierKeys);
                //Console.WriteLine("Key Name:  " + (Keys)keyCode);
                //Console.WriteLine("Key Code:  " + keyCode);

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

        private static LowLevelKeyboardProc keyHandler = KeyHandler;
        private static IntPtr handlerID = IntPtr.Zero;

        private static ArrayList hotKeys = null;
        private static bool hotkeysEnabled = true;
    }
}
