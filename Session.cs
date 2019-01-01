// ClockIn
// Copyright (C) 2012-2019 Jens Rossbach, All Rights Reserved.


using System.ComponentModel;

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
        ///   Event notifies when property has been validated.
        /// </summary>
        public event PropertyChangedEventHandler PropertyValidated;

        /// <summary>
        ///   Notifies about a validated property.
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        public void NotifyPropertyValidated(string propertyName) => PropertyValidated?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
