// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


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
        /// <summary>
        ///   Time manager instance
        /// </summary>
        public static TimeManager TimeMgr
        {
            get
            {
                return timeMgr;
            }
        }

        /// <summary>
        ///   Main entry point of the application
        /// </summary>
        [STAThread]
        public static void Main()
        {
            instanceMutex = new Mutex(false, "{ef6fec17-3816-459a-a72e-21fd34ebdc6b}", out bool firstInstance);

            if (firstInstance)
            {
                if (!Properties.Settings.Default.Upgraded)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.Upgraded = true;
                    Properties.Settings.Default.Save();

                    Debug.WriteLine("[Program] Settings upgraded from previous version.");
                } 
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                timeMgr = new TimeManager();

                HotkeyManager.Init();
                Application.Run(new MainWindow());
                HotkeyManager.Deinit();
            }
        }

        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
            {
                return dateTime;
            }

            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }

        private static Mutex instanceMutex = null;
        private static TimeManager timeMgr = null;
    }
}
