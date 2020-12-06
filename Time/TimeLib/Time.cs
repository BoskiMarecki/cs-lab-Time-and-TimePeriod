using System;

namespace Time
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        
        private readonly byte hour;
        private readonly byte minutes;
        private readonly byte seconds;

        public byte Hour => hour;
        public byte Minutes => minutes;
        public byte Seconds => seconds;
        // Godzina , minuta , sekunda 
        public Time(byte hour, byte minutes = 0, byte seconds = 0)
        {
            this.hour = hour > 23 ? throw new ArgumentException("Wrong argument!") : hour;
            this.minutes = minutes > 59 ? throw new ArgumentException("Wrong argument!") : minutes;
            this.seconds = seconds > 59 ? throw new ArgumentException("Wrong argument!") : seconds;
        }
        // String Godzina , minuta , sekunda 
        public Time(string time)
        {
            var newtime = time.Split(':');
            var tabT = new byte[3] { 0, 00, 00 };
            for (int i = 0; i < newtime.Length; i++)
                tabT[i] = Byte.Parse(newtime[i]);

            byte check(byte value, byte min, byte max) =>
                (value >= min && value <= max) ? value : throw new ArgumentException("Wrong argument!");


            this.hour = check(tabT[0], 0, 23);
            this.minutes = check(tabT[1], 0, 59);
            this.seconds = check(tabT[2], 0, 59);

            
        }
        // String Godzina , minuta , sekunda hh:mm:ss
        public override string ToString() => $"{hour:00}:{minutes:00}:{seconds:00}";

        public bool Equals(Time other) => hour == other.hour && minutes == other.minutes && seconds == other.seconds;
        public override bool Equals(object obj)
        {
            return obj is Time other && Equals(other);
        }

        public override int GetHashCode() => HashCode.Combine(hour, minutes, seconds);
        public static bool operator ==(Time t1, Time t2) => t1.Equals(t2);
        public static bool operator !=(Time t1, Time t2) => !(t1 == t2);
        public static bool operator <(Time t1, Time t2) => t1.CompareTo(t2)<0;
        public static bool operator >(Time t1, Time t2) => t1.CompareTo(t2) > 0;
        public static bool operator <=(Time t1, Time t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >=(Time t1, Time t2) => t1.CompareTo(t2) >= 0;
       
        public int CompareTo(Time other)
        {
            var hourComparison = hour.CompareTo(other.hour);
            if (hourComparison != 0) return hourComparison;
            var minutesComparison = minutes.CompareTo(other.minutes);
            if (minutesComparison != 0) return minutesComparison;
            return seconds.CompareTo(other.seconds);
        }
         public static long ToSec(Time t1)
         {
            long timeSeconds = t1.hour * 3600 + t1.minutes * 60 + t1.seconds;
            return timeSeconds;
         }
        public static Time operator +(Time t1, TimePeriod p1)
        {
            byte h;
            long sec = ToSec(t1) + p1.Seconds;
            if (sec/3600>23) h = (byte)((sec/3600)%24);
            else h = (byte)((sec / 3600));
            var m = (byte)((sec / 60)%60 );
            var s = (byte)(sec % 60);
            return new Time(h, m, s);
        }

        public Time Plus(TimePeriod p1)
        {
            long sec = hour*3600+minutes*60+seconds + p1.Seconds;
            byte h;
            if (sec / 3600 > 23) h = (byte)((sec / 3600) % 24);
            else h = (byte)((sec / 3600));
            var m = (byte)((sec / 60) % 60);
            var s = (byte)(sec % 60);
            return new Time(h,m,s);
        }

        public static Time Plus(Time t1, TimePeriod tp1)
        {
            long sec = t1.Hour * 3600 + t1.Minutes * 60 + t1.Seconds + tp1.Seconds;
            byte h;
            if (sec / 3600 > 23) h = (byte)((sec / 3600) % 24);
            else h = (byte)((sec / 3600));
            var m = (byte)((sec / 60) % 60);
            var s = (byte)(sec % 60);
            return new Time(h, m, s);
        }
        public static Time operator -(Time t1, TimePeriod tp1)
        {
            long sec = ToSec(t1) - tp1.Seconds;
            if (sec<0) sec *= -1;
            byte h;
            if (sec / 3600 < 0) h = (byte)((sec / 3600) + 24);
            else h = (byte)((sec / 3600));
            var m = (byte)((sec / 60)%60);
            var s = (byte)(sec % 60);
            return new Time(h, m, s);

        }
    }
}
