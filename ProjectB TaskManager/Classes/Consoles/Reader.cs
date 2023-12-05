using System;

namespace ProjectB_TaskManager.Classes.Consoles
{
    internal class Reader
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
    }
}
