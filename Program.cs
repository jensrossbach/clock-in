using System;
using System.Windows.Forms;
using System.Threading;


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
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                timeMgr = new TimeManager();
                Application.Run(new MainWindow());
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
