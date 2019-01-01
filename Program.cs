// ClockIn
// Copyright (C) 2012-2019 Jens Rossbach, All Rights Reserved.


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
                    mainWindow.WindowState = FormWindowState.Normal;
                    mainWindow.Visible = true;
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
