using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;


namespace ClockIn
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool firstInstance = true;
            instanceMutex = new Mutex(false, "{ef6fec17-3816-459a-a72e-21fd34ebdc6b}", out firstInstance);

            if (firstInstance)
            {
                if (!Properties.Settings.Default.Upgraded)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.Upgraded = true;
                    Properties.Settings.Default.Save();

                    Trace.WriteLine("INFO: Settings upgraded from previous version");
                } 
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                timeMgr = new TimeManager();

                HotkeyManager.Init();
                Application.Run(new MainWindow());
                HotkeyManager.Deinit();
            }
        }

        public static TimeManager TimeMgr
        {
            get
            {
                return timeMgr;
            }
        }

        private static Mutex instanceMutex = null;
        private static TimeManager timeMgr = null;
    }
}
