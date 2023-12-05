using System;
using System.Globalization;

namespace ProjectB_TaskManager.Classes.Consoles
{
    public class Reader
    {
        public static int ReadInt32()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int ReadInt32(int minRange, int maxRange)
        {
            int number = ReadInt32();

            if (minRange > number || number > maxRange)
                throw new OverflowException("Please, input number from the specified range!");

            return number;
        }

        public static DateTime ReadDateTime(string format)
        {
            DateTime date;

            string input = Console.ReadLine();
            date = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);

            return date;
        }
    }
}
