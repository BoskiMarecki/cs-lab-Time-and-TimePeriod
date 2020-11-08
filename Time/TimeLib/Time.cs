using System;

namespace Time
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private byte hour, minutes, seconds;
        public readonly byte Hour => hour;
        public readonly byte Minutes => minutes;
        public readonly byte Seconds => seconds;
        /// <summary>
        /// Zwraca godzinę słożoną z 3 elementów typu byte w określonym zakresie 
        /// </summary>
        public Time(byte hour, byte minutes = 0, byte seconds = 0)
        {
            this.hour = verify(hour, 0, 23);
            this.minutes = verify(minutes, 0, 59);
            this.seconds = verify(seconds, 0, 59);

            byte verify(byte value, byte min, byte max) =>
                (value >= min && value <= max) ? value : throw new ArgumentException();

        }
        /// <summary>
        /// Zwraca godzinę odvzytaną z formatu string
        /// </summary>
        public Time(string time)
        {
            string[] newtime = time.Split(':');
            byte[] tabTime = new byte[3] { 0, 00, 00 };
            for (int i = 0; i < newtime.Length; i++)
            {
                tabTime[i] = Byte.Parse(newtime[i]);
            }
            this.hour = verify(tabTime[0], 0, 23);
            this.minutes = verify(tabTime[1], 0, 59);
            this.seconds = verify(tabTime[2], 0, 59);

            byte verify(byte value, byte min, byte max) =>
                (value >= min && value <= max) ? value : throw new ArgumentException();
        }

        /// <summary>
        /// Zwraca godzinę, typu string w formacie h:mm:ss
        /// </summary>
        public override string ToString() => $"{Hour}:{Minutes:D2}:{Seconds:D2}";

        public bool Equals(Time other)
        {
            return hour == other.hour && minutes == other.minutes && seconds == other.seconds;
        }

        public override bool Equals(object obj)
        {
            return obj is Time other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hour, minutes, seconds);
        }

        public static bool operator ==(Time t1, Time t2)
        {

            if (Time.ReferenceEquals(t1, null))
            {
                if (Time.ReferenceEquals(t2, null))
                {
                    return true;
                }
                return false;
            }

            return t1.Equals(t2);
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }

        public int CompareTo(Time other)
        {
            var hourComparison = hour.CompareTo(other.hour);
            if (hourComparison != 0) return hourComparison;
            var minutesComparison = minutes.CompareTo(other.minutes);
            if (minutesComparison != 0) return minutesComparison;
            return seconds.CompareTo(other.seconds);
        }

        public static bool operator <(Time t1, Time t2)
        {
           return t1.CompareTo(t2)<0;
        }

        public static bool operator >(Time t1, Time t2)
        {
            return t1.CompareTo(t2) > 0;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) <= 0;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) >= 0;
        }
        public static long ToSeconds(Time t1)
        {
            long timeSeconds = t1.hour * 3600 + t1.minutes * 60 + t1.seconds;

            return timeSeconds;
        }
        public static Time operator +(Time t1, TimePeriod tp1)
        {
            long sec = ToSeconds(t1) + tp1.Seconds;

            byte h;
            if (sec/3600>23)
            {
                 h = (byte)((sec/3600)%24);
            }
            else
            {
                 h = (byte)((sec / 3600));
            }
            
            byte mm = (byte)((sec / 60)%60 );
            byte ss = (byte)(sec % 60);



            return new Time(h, mm, ss);
        }

        public Time Plus(TimePeriod tp1)
        {
            long sec = hour*3600+minutes*60+seconds + tp1.Seconds;

            byte h;
            if (sec / 3600 > 23)
            {
                h = (byte)((sec / 3600) % 24);
            }
            else
            {
                h = (byte)((sec / 3600));
            }

            byte mm = (byte)((sec / 60) % 60);
            byte ss = (byte)(sec % 60);


            return new Time(h,mm,ss);
        }

        public static Time Plus(Time t1, TimePeriod tp1)
        {
            long sec = t1.Hour * 3600 + t1.Minutes * 60 + t1.Seconds + tp1.Seconds;

            byte h;
            if (sec / 3600 > 23)
            {
                h = (byte)((sec / 3600) % 24);
            }
            else
            {
                h = (byte)((sec / 3600));
            }

            byte mm = (byte)((sec / 60) % 60);
            byte ss = (byte)(sec % 60);


            return new Time(h, mm, ss);
        }


        public static Time operator -(Time t1, TimePeriod tp1)
        {
            long sec = ToSeconds(t1) - tp1.Seconds;
            if (sec<0)
                sec *= -1;

            byte h;
            if (sec / 3600 <0 )
            {
                h = (byte)((sec / 3600)+24);
            }
            else
            {
                h = (byte)((sec / 3600));
            }

            byte mm = (byte)((sec / 60)%60);
            byte ss = (byte)(sec % 60);



            return new Time(h, mm, ss);

        }
    }
}
