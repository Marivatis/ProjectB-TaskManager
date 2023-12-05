using ProjectB_TaskManager.Classes.MyTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB_TaskManager.Classes.Consoles
{
    public class MyConsole
    {
        public void Run()
        {
            Printer.PrintMainMenu();

            int option = int.MaxValue;

            while (option != 0)
            {
                option = MyConsoleReader.ReadInt32("Enter any main menu option --> ", 0, 5);

                MainMenuSwitch(option);
            }

            Console.WriteLine("Have a nice day!");
        }

        private void MainMenuSwitch(int option)
        {
            switch (option)
            {
                case 1: // Add task

                    break;
                case 2: // Print tasks
                    break;
                case 3: // Find tasks
                    break;
                case 4: // Delete task
                    break;
                case 5: // Clear task manager
                    break;
                case 6: // Save tasks to file
                    break;
                case 7: // Load tasks from file
                    break;
                case 8: // Print main menu
                    Printer.PrintMainMenu();
                    break;
            }
        }

        private void AddTaskSwitch(int option)
        {
            switch (option)
            {
                case 1: // Add university task
                    AddUniversityTask();
                    break;
                case 2: // Add university task randomly
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        private void AddUniversityTask()
        {
            try
            {
                MyUniversityTask task = new MyUniversityTask();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AddUniversityTask();
            }
        }
    }
}
