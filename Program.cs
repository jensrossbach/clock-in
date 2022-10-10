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
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;


namespace ClockIn
{
    /// <summary>
    ///   Main class of the application
    /// </summary>
    static class Program
    {
        private static Mutex instanceMutex = null;
        private static MainWindow mainWindow = null;


        /// <summary>
        ///   Time manager instance
        /// </summary>
        public static TimeManager TimeMgr { get; private set; } = null;

        /// <summary>
        ///   Hotkey manager instance
        /// </summary>
        public static HotkeyManager HotkeyMgr { get; private set; } = null;


        /// <summary>
        ///   Main entry point of the application
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Debug.WriteLine("[Program] Hello from ClockIn :)");

            instanceMutex = new Mutex(false, "{ef6fec17-3816-459a-a72e-21fd34ebdc6b}", out bool firstInstance);

            if (firstInstance)
            {
                Properties.Settings settings = Properties.Settings.Default;

                if (!settings.Upgraded)
                {
                    settings.Upgrade();
                    settings.Upgraded = true;
                    settings.Save();

                    Debug.WriteLine("[Program] Settings upgraded from previous version.");
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                TimeMgr = new TimeManager();
                HotkeyMgr = new HotkeyManager();

                mainWindow = new MainWindow();

                TimeMgr.HandleStart();

                if (!settings.StartMinimized)
                {
                    mainWindow.Restore();
                }

                Debug.WriteLine("[Program] Entering main application loop...");
                Application.Run();
            }
            else
            {
                Debug.WriteLine("[Program] ClockIn already running, exiting...");
            }

            Debug.WriteLine("[Program] Bye bye!");
        }

        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
            {
                return dateTime;
            }

            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }
    }
}
