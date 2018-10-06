using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ClockIn
{
    public class TimePeriod : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DateTime startTime;
        DateTime endTime;

        public TimePeriod()
        {
            DateTime now = DateTime.Now;
            SetupTime(now, now);
        }

        public TimePeriod(DateTime start, DateTime end)
        {
            if (startTime > endTime)
            {
                throw new ArgumentException("Start time must be before end time");
            }

            SetupTime(start, end);
        }

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

        public TimePeriod(TimePeriod other)
        {
            startTime = other.StartTime;
            endTime = other.EndTime;
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                if (startTime != value)
                {
                    startTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                if (endTime != value)
                {
                    endTime = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TimeSpan Duration => endTime.TimeOfDay - startTime.TimeOfDay;

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

        public bool Intersecting(TimePeriod other)
        {
            return Math.Min(endTime.Ticks, other.EndTime.Ticks) > Math.Max(startTime.Ticks, other.StartTime.Ticks);
        }

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

        public override string ToString() => startTime.ToString("s") + "|" + endTime.ToString("s");

        private void SetupTime(DateTime start, DateTime end)
        {
            startTime = start.AddTicks(-(start.Ticks % TimeSpan.FromMinutes(1).Ticks));
            endTime = end.AddTicks(-(end.Ticks % TimeSpan.FromMinutes(1).Ticks));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
