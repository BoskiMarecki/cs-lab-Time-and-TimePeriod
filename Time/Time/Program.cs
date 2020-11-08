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
            Console.WriteLine("Time Wypisany z 3 properties");
            Time t01 = new Time(12, 22, 09);
            Console.WriteLine(t01);

            Console.WriteLine("Time wypisany z formatu string");
            Time t02 = new Time("12:32:11");
            Console.WriteLine(t02);

            Console.WriteLine("TimePeriod wypisany z properties sekundy");
            TimePeriod tp01 = new TimePeriod(6352);
            Console.WriteLine(tp01);

            Console.WriteLine("TimePeriod wypisany formatu string");
            TimePeriod tp02 = new TimePeriod("6:42:19");
            Console.WriteLine(tp02);

            Console.WriteLine("Dodawanie Time Metodą Plus");
            t01.Plus(tp02);
            Console.WriteLine(t01);

            Console.WriteLine("Dodawanie TimePeriod metodą Plus");
            TimePeriod tp05 = TimePeriod.Plus(tp02, tp01);
            Console.WriteLine(tp05);


        }

    }
}



