// ClockIn
// Copyright (C) 2012-2018 Jens Rossbach, All Rights Reserved.


using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ClockIn
{
    /// <summary>
    ///   Represents a certain period of time
    /// </summary>
    public class TimePeriod : INotifyPropertyChanged
    {
        private DateTime startTime;
        private DateTime endTime;


        /// <summary>
        ///   Event notifies when a property from this time period has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        ///   Default constructor of the class
        /// </summary>
        public TimePeriod()
        {
            DateTime now = DateTime.Now;
            SetupTime(now, now);
        }

        /// <summary>
        ///   Constructs the time period from a start and end time.
        /// </summary>
        /// <param name="start">Start time</param>
        /// <param name="end">End time</param>
        public TimePeriod(DateTime start, DateTime end)
        {
            if (endTime < startTime)
            {
                SetupTime(start, start);
            }
            else
            {
                SetupTime(start, end);
            }
        }

        /// <summary>
        ///   Constructs the time period from its string representation.
        /// </summary>
        /// <param name="periodString">String representation of the time period</param>
        public TimePeriod(string periodString)
        {
            string[] parts = periodString.Split('|');

            if (parts.Length != 2)
            {
                throw new ArgumentException("Period string must contain start and end time");
            }

            startTime = DateTime.Parse(parts[0]);
            endTime = DateTime.Parse(parts[1]);
        }

        /// <summary>
        ///   Constructs the time period by cloning another one.
        /// </summary>
        /// <param name="other">Time period to be cloned</param>
        public TimePeriod(TimePeriod other)
        {
            startTime = other.StartTime;
            endTime = other.EndTime;
        }


        /// <summary>
        ///   Start time of the time period
        /// </summary>
        public DateTime StartTime
        {
            get => startTime;
            set
            {
                DateTime val = value.Truncate(TimeSpan.FromMinutes(1));

                if (startTime != val)
                {
                    startTime = val;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        ///   End time of the time period
        /// </summary>
        public DateTime EndTime
        {
            get => endTime;
            set
            {
                DateTime val = value.Truncate(TimeSpan.FromMinutes(1));

                if (endTime != val)
                {
                    if (val < startTime)
                    {
                        endTime = startTime;
                    }
                    else
                    {
                        endTime = val;
                    }

                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        ///   Time span of the time period
        /// </summary>
        public TimeSpan Duration => endTime - startTime;


        /// <summary>
        ///   Copies another time period to this one.
        /// </summary>
        /// <param name="other">Time period to copy</param>
        public void CopyFrom(TimePeriod other)
        {
            bool notify = false;

            if (startTime != other.StartTime)
            {
                startTime = other.StartTime;
                notify = true;
            }

            if (endTime != other.EndTime)
            {
                endTime = other.EndTime;
                notify = true;
            }

            if (notify)
            {
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///   Checks if this time period intersects with another one.
        /// </summary>
        /// <param name="other">Time period to check for intersection</param>
        /// <returns>true if time period intersects with the other one, false otherwise</returns>
        public bool Intersecting(TimePeriod other) => Math.Min(endTime.Ticks, other.EndTime.Ticks) > Math.Max(startTime.Ticks, other.StartTime.Ticks);

        /// <summary>
        ///   Returns the intersection between this time period and another one.
        /// </summary>
        /// <param name="other">Time period to get intersection for</param>
        /// <returns>Intersection with other time period as time span</returns>
        public TimeSpan GetIntersection(TimePeriod other)
        {
            if (Intersecting(other))
            {
                return new TimeSpan(Math.Min(endTime.Ticks, other.EndTime.Ticks) - Math.Max(startTime.Ticks, other.StartTime.Ticks));
            }
            else
            {
                return TimeSpan.Zero;
            }
        }

        /// <summary>
        ///   Converts the time period into its string representation.
        /// </summary>
        /// <returns>String representation of the time period</returns>
        public override string ToString() => startTime.ToString("s") + "|" + endTime.ToString("s");

        /// <summary>
        ///   Initializes the time period from a start and end time.
        /// </summary>
        /// <param name="start">Start time</param>
        /// <param name="end">End time</param>
        private void SetupTime(DateTime start, DateTime end)
        {
            startTime = start.Truncate(TimeSpan.FromMinutes(1));
            endTime = end.Truncate(TimeSpan.FromMinutes(1));
        }

        /// <summary>
        ///   Notifies the change of a property from this time period.
        /// </summary>
        /// <param name="propertyName">Name of the property that has changed</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
