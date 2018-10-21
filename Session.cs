// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


namespace ClockIn
{
    /// <summary>
    ///   Holds session information.
    /// </summary>
    internal sealed partial class Session
    {
        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public Session()
        {
        }

        /// <summary>
        ///   Handles the event when session settings have changed.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
        }

        /// <summary>
        ///   Handles the event when session settings have been saved.
        /// </summary>
        /// <param name="sender">Event origin</param>
        /// <param name="e">Event arguments</param>
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
