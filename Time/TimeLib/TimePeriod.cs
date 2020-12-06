using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Time
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        // Realizacja czasu trwania w sekundach
        private long seconds;
        public readonly long Seconds => seconds;
        // Godzina , minuta , sekunda 
        public TimePeriod(ulong hour, byte minutes, byte seconds = 0)
        {
            if (minutes < 60 && seconds < 60) 
                this.seconds = (long)(hour * 3600 + (ulong)(minutes * 60) + seconds);
            else 
                throw new ArgumentException();
        }
        public TimePeriod(long seconds)
        {
            this.seconds = seconds;
        }

        /// string
        public TimePeriod(string timePeriod)
        {
            var newtime = timePeriod.Split(':');
            var tabT = new byte[3] { 0, 00, 00 };
            for (int i = 0; i < newtime.Length; i++)
                tabT[i] = Byte.Parse(newtime[i]);
            this.seconds = tabT[0] * 3600 + verify(tabT[1], 0, 59) * 60 + verify(tabT[2], 0, 59);

            byte verify(byte value, byte min, byte max) =>
                (value >= min && value <= max) ? value : throw new ArgumentException("Wrong argument!");
        }
        /// String Godzina , minuta , sekunda hh:mm:ss
        public override string ToString() => $"{Seconds / 3600}:{(Seconds / 60) % 60:00}:{Seconds % 60:00}";


        public bool Equals(TimePeriod other) => seconds == other.seconds;
        public override bool Equals(object obj) => obj is TimePeriod other && Equals(other);

        public override int GetHashCode()
        {
            return Seconds.GetHashCode();
        }

        public static bool operator ==(TimePeriod t1, TimePeriod t2) => t1.Equals(t2);
        public static bool operator !=(TimePeriod t1, TimePeriod t2) => !(t1 == t2);
        public static bool operator <(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) < 0;
        public static bool operator <=(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) > 0;
        public static bool operator >=(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) >= 0;

        public int CompareTo(TimePeriod other) => Seconds.CompareTo(other.Seconds);
       
        public static TimePeriod operator +(TimePeriod p1, TimePeriod p2)
        {
            long s = p1.Seconds + p2.Seconds;
            return new TimePeriod(s);
        }
        public TimePeriod Plus(TimePeriod p1)
        {
            long s = Seconds + p1.Seconds;
            return new TimePeriod(s);
        }
        public static TimePeriod Plus(TimePeriod p1, TimePeriod p2)
        {
            long s = p1.Seconds + p2.Seconds;
            return new TimePeriod(s);
        }

        public static TimePeriod operator -(TimePeriod p1, TimePeriod p2)
        {
            long s = p1.seconds - p2.seconds;
            if (s >= 0)
                return new TimePeriod(s);
            else
                throw new ArgumentOutOfRangeException("TimePeriod should not be a negative one");
        }


    }
}
