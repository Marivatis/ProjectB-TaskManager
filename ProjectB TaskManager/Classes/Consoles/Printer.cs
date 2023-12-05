using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB_TaskManager.Classes.Consoles
{
    public static class Printer
    {
        public static void PrintMainMenu()
        {
            Console.WriteLine("[1] - Add task");
            Console.WriteLine("[2] - Print tasks");
            Console.WriteLine("[3] - Find tasks");
            Console.WriteLine("[4] - Delete task");
            Console.WriteLine("[5] - Clear task");
            Console.WriteLine("[6] - Save tasks to file");
            Console.WriteLine("[7] - Load tasks from file");
            Console.WriteLine("[8] - Show main menu");
            Console.WriteLine("[0] - Exit");
        }
    }
}
