// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;


namespace ClockIn
{
    /// <summary>
    ///   Arguments for message events
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        ///   Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        /// <param name="msg">Message</param>
        public MessageEventArgs(string msg = "")
        {
            Message = msg;
        }
    }

    /// <summary>
    ///   Event handler for message events
    /// </summary>
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);
}
