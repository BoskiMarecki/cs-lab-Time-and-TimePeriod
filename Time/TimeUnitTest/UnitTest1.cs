using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TimeUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        #region Constructor Time==========================

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_Default()
        {
            var time = new Time.Time();
            var defaultTime = new Time.Time(0, 00, 00);
            Assert.AreEqual(defaultTime, time);
        }

        [TestMethod, TestCategory("Constructor Time")]
        [DataRow ((byte)0, (byte) 0 , (byte) 0)]
        [DataRow ((byte)14, (byte) 53 , (byte) 11)]
        [DataRow ((byte)23, (byte) 17 , (byte) 1)]
        public void Constructor_Time_ToString(byte h, byte m, byte s)
        {
            var t1 = new Time.Time(h,m,s);
            

            Assert.AreEqual($"{h}:{m:D2}:{s:D2}", t1.ToString());
            
        }

        [TestMethod, TestCategory("Constructor Time")]
        [DataRow((byte)9)]
        [DataRow((byte)22)]
        [DataRow((byte)13)]
        public void Constructor_Time_Hour(byte h)
        {
            Time.Time t1 = new Time.Time(h);
            

            Assert.AreEqual($"{h}:00:00", t1.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]
        [DataRow((byte)9,(byte)52)]
        [DataRow((byte)22,(byte) 16)]
        [DataRow((byte)13, (byte) 54)]
        public void Constructor_Time_Hour_Minutes(byte h, byte m)
        {
            Time.Time t1 = new Time.Time(h,m);

            Assert.AreEqual($"{h}:{m:D2}:00", t1.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]
        [DataRow((byte)19, (byte)42,(byte)32)]
        [DataRow((byte)12, (byte)16, (byte) 21)]
        [DataRow((byte)3, (byte)4,(byte)56)]
        public void Constructor_Time_Hour_Minutes_Seconsd(byte h,byte m,byte s)
        {
            Time.Time t1 = new Time.Time(h,m,s);

            Assert.AreEqual($"{h}:{m:D2}:{s:D2}", t1.ToString());
        }

        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour()
        {
            Time.Time t1 = new Time.Time("12");
            Time.Time t2 = new Time.Time("23");

            Assert.AreEqual("12:00:00", t1.ToString());
            Assert.AreEqual("23:00:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour_Minutes()
        {
            Time.Time t1 = new Time.Time("12:53");
            Time.Time t2 = new Time.Time("23:21");

            Assert.AreEqual("12:53:00", t1.ToString());
            Assert.AreEqual("23:21:00", t2.ToString());
        }
        [TestMethod, TestCategory("Constructor Time")]
        public void Constructor_Time_String_Hour_Minutes_Seconds()
        {
            Time.Time t1 = new Time.Time("12:21:02");
            Time.Time t2 = new Time.Time("23:53:33");

            Assert.AreEqual("12:21:02", t1.ToString());
            Assert.AreEqual("23:53:33", t2.ToString());
        }

        #endregion

        #region Time Operators==================


        [TestMethod, TestCategory("Equals Time")]
        public void Time_Equals()
        {
            Time.Time t1 = new Time.Time(8, 15);
            Time.Time t2 = new Time.Time(8, 15);
            Time.Time t3 = new Time.Time(8, 25, 53);

            Assert.IsTrue(t1.Equals(t2));
            Assert.IsFalse(t1.Equals(t3));
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Equals()
        {
            Time.Time t1 = new Time.Time(8, 15);
            Time.Time t2 = new Time.Time(8, 15);
            Time.Time t3 = new Time.Time(15, 25, 53);

            Assert.IsTrue(t1 == t2);
            Assert.IsTrue(t1 != t3);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Smaller()
        {
            Time.Time t1 = new Time.Time(8, 15);
            Time.Time t2 = new Time.Time(8, 15, 44);
            Time.Time t3 = new Time.Time(12, 25, 53);

            Assert.IsTrue(t1 < t2);
            Assert.IsTrue(t1 < t3);
            Assert.IsFalse(t3 < t1);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Bigger()
        {
            Time.Time t1 = new Time.Time(8, 15);
            Time.Time t2 = new Time.Time(8, 15, 44);
            Time.Time t3 = new Time.Time(11, 25, 53);

            Assert.IsTrue(t2 > t1);
            Assert.IsTrue(t3 > t1);
            Assert.IsFalse(t1 > t3);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Smaller_Equals()
        {
            Time.Time t1 = new Time.Time(8, 15);
            Time.Time t2 = new Time.Time(8, 15);
            Time.Time t3 = new Time.Time(9, 25, 53);

            Assert.IsTrue(t1 <= t2);
            Assert.IsTrue(t1 <= t3);
            Assert.IsFalse(t3 <= t2);
        }
        [TestMethod, TestCategory("Equals Time")]
        public void Time_Operator_Bigger_Equals()
        {
            Time.Time t1 = new Time.Time(8, 15);
            Time.Time t2 = new Time.Time(8, 15);
            Time.Time t3 = new Time.Time(9, 25, 53);

            Assert.IsTrue(t2 >= t1);
            Assert.IsTrue(t3 >= t1);
            Assert.IsFalse(t2 >= t3);
        }

        [TestMethod, TestCategory("Operator Time")]
        public void Time_Operator_Plus()
        {
            Time.Time t1 = new Time.Time(3, 15, 32);
            TimePeriod tp1 = new TimePeriod("2:18:42");
            Time.Time t2 = new Time.Time(17, 31, 59);
            TimePeriod tp2 = new TimePeriod("26:10:46");

            Time.Time tt1 = t1 + tp1;
            Time.Time tt2 = t2 + tp2;

            Assert.AreEqual("5:34:14", tt1.ToString());
            Assert.AreEqual("19:42:45", tt2.ToString());

        }
        [TestMethod, TestCategory("Operator Time")]
        public void Time_Method_Plus()
        {
            Time.Time t1 = new Time.Time(3, 15, 32);
            TimePeriod tp1 = new TimePeriod("2:18:42");
            Time.Time t2 = new Time.Time(17, 31, 59);
            TimePeriod tp2 = new TimePeriod("26:10:46");

            Time.Time tt1 = t1 + tp1;
            Time.Time tt2 = t2 + tp2;

            


            Assert.AreEqual(tt1, t1.Plus(tp1));
            Assert.AreEqual(tt2, t2.Plus(tp2));

        }
        [TestMethod, TestCategory("Operator Time")]
        public void Time_Static_Method_Plus()
        {
            Time.Time t1 = new Time.Time(3, 15, 32);
            TimePeriod tp1 = new TimePeriod("2:18:42");
            Time.Time t2 = new Time.Time(17, 31, 59);
            TimePeriod tp2 = new TimePeriod("26:10:46");

            Time.Time tt1 = t1 + tp1;
            Time.Time tt2 = t2 + tp2;




            Assert.AreEqual(tt1, Time.Time.Plus(t1,tp1));
            Assert.AreEqual(tt2, Time.Time.Plus(t2,tp2));

        }
        [TestMethod, TestCategory("Operator Time")]
        public void Time_Operator_Minus()
        {
            Time.Time t1 = new Time.Time(3, 15, 32);
            TimePeriod tp1 = new TimePeriod("2:18:42");
            Time.Time t2 = new Time.Time(17, 31, 59);
            TimePeriod tp2 = new TimePeriod("26:10:46");

            Time.Time tt1 = t1 - tp1;
            Time.Time tt2 = t2 - tp2;

            Assert.AreEqual("0:56:50", tt1.ToString());
            Assert.AreEqual("8:38:47", tt2.ToString());

        }

        #endregion

        #region Constructor TimePeriod================

        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Hour_Minutes_Seconds()
        {
            TimePeriod tp1 = new TimePeriod(11, 11, 11);
            TimePeriod tp2 = new TimePeriod(143, 54, 2);

            Assert.AreEqual("11:11:11", tp1.ToString());
            Assert.AreEqual("143:54:02", tp2.ToString());
        }

        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Hour_Minutes()
        {
            TimePeriod tp1 = new TimePeriod(11, 11);
            TimePeriod tp2 = new TimePeriod(143, 54);

            Assert.AreEqual("11:11:00", tp1.ToString());
            Assert.AreEqual("143:54:00", tp2.ToString());
        }
        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_Seconds()
        {
            TimePeriod tp1 = new TimePeriod(6352);
            TimePeriod tp2 = new TimePeriod(4321);
            TimePeriod tp3 = new TimePeriod(236539);

            Assert.AreEqual("1:45:52", tp1.ToString());
            Assert.AreEqual("1:12:01", tp2.ToString());
            Assert.AreEqual("65:42:19", tp3.ToString());
        }
        [TestMethod, TestCategory("Constructor TimePeriod")]
        public void Constructor_TimePeriod_String()
        {
            TimePeriod tp1 = new TimePeriod("1:45:52");
            TimePeriod tp2 = new TimePeriod("1:12:01");
            TimePeriod tp3 = new TimePeriod("65:42:19");

            Assert.AreEqual("1:45:52", tp1.ToString());
            Assert.AreEqual("1:12:01", tp2.ToString());
            Assert.AreEqual(236539, tp3.Seconds);
        }

        #endregion

        #region TimePeriod Operators============

        [TestMethod, TestCategory("Equals TimePeriod")]
        public void TimePeriod_Equlas()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87322);

            Assert.IsTrue(tp1.Equals(tp2));
            Assert.IsFalse(tp1.Equals(tp3));
        }

        [TestMethod, TestCategory("Equals TimePeriod")]
        public void TimePeriod_Operator_Equals()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87322);

            Assert.IsTrue(tp1 == tp2);
            Assert.IsTrue(tp1 != tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Samller()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("65:41:28");
            TimePeriod tp3 = new TimePeriod(872);

            Assert.IsTrue(tp1 < tp2);
            Assert.IsFalse(tp1 < tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Bigger()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("25:41:28");
            TimePeriod tp3 = new TimePeriod(87673582);

            Assert.IsTrue(tp1 > tp2);
            Assert.IsFalse(tp1 > tp3);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Smaller_Equals()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87673582);

            Assert.IsTrue(tp1 <= tp2);
            Assert.IsTrue(tp1 <= tp3);
            Assert.IsFalse(tp3 <= tp1);
        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Bigger_Equals()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(87673582);

            Assert.IsTrue(tp2 >= tp1);
            Assert.IsTrue(tp3 >= tp1);
            Assert.IsFalse(tp1 >= tp3);
        }

        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Plus()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(73582);

            TimePeriod ttp = tp1 + tp2;
            TimePeriod ttp0 = tp1 + tp3;

            Assert.AreEqual("71:22:56", ttp.ToString());
            Assert.AreEqual("56:07:50", ttp0.ToString());

        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Method_Plus()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(73582);

            TimePeriod ttp = tp1 + tp2;
            TimePeriod ttp0 = tp1 + tp3;

            Assert.AreEqual(ttp, tp1.Plus(tp2));
            Assert.AreEqual(ttp0,tp1.Plus(tp3));

        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Static_Method_Plus()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("35:41:28");
            TimePeriod tp3 = new TimePeriod(73582);

            TimePeriod ttp = tp1 + tp2;
            TimePeriod ttp0 = tp1 + tp3;

            Assert.AreEqual(ttp, TimePeriod.Plus(tp2,tp1));
            Assert.AreEqual(ttp0, TimePeriod.Plus(tp3, tp1));

        }
        [TestMethod, TestCategory("Operator TimePeriod")]
        public void TimePeriod_Operator_Minus()
        {
            TimePeriod tp1 = new TimePeriod(35, 41, 28);
            TimePeriod tp2 = new TimePeriod("34:41:28");
            TimePeriod tp3 = new TimePeriod(73582);

            TimePeriod ttp = tp1 - tp2;
            TimePeriod ttp0 = tp1 - tp3;

            Assert.AreEqual("1:00:00", ttp.ToString());
            Assert.AreEqual("15:15:06", ttp0.ToString());

        }

        #endregion
    }
}
