using System;
using System.Collections.Generic;
using System.Text;
using Time;



namespace Time
{
    public class Program
    {
        public static void Main()
        {
            Time time = new Time(12, 25, 23);
            Console.WriteLine("Time: " + time);

            Time time1 = new Time(12);
            Console.WriteLine("Time 1 parametr: :" + time1);

            Time time2 = new Time("12:25:23");
            Console.WriteLine("Time string: " + time2);

            TimePeriod tp01 = new TimePeriod(86491);
            Console.WriteLine("TimePeriod: " + tp01);

            TimePeriod tp02 = new TimePeriod("129:58:12");
            Console.WriteLine("TimePeriod string: " + tp02);

            Console.WriteLine("Dodawanie Time Metodą Plus");
            time.Plus(tp02);
            Console.WriteLine(time);

            Console.WriteLine("Dodawanie TimePeriod metodą Plus");
            TimePeriod tp05 = TimePeriod.Plus(tp02, tp01);
            Console.WriteLine(tp05);


        }

    }
}



