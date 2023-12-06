﻿using ProjectB_TaskManager.Classes.General;
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
        private string path = "D:\\Работы ВУЗ\\Курс 2.1\\ООП\\Проект\\Часть Б\\Tasks\\Tasks.json";

        private MyTaskManager taskManager;

        public MyConsole() 
        {
            List<MyTask> tasks = new List<MyTask>();

            ListDataReader.ReadFromJsonFile(path, ref tasks);

            taskManager = new MyTaskManager(tasks);
        }

        public void Run()
        {
            Printer.PrintMainMenu();

            int option = int.MaxValue;

            while (option != 0)
            {
                option = MyConsoleReader.ReadInt32("Enter any main menu option --> ", 0, 7);

                MainMenuSwitch(option);
            }
        }

        private void MainMenuSwitch(int mainMenuOption)
        {
            int option;

            switch (mainMenuOption)
            {
                case 0:
                    SaveTasks();

                    Console.WriteLine("Have a nice day!");
                    break;
                case 1: // Add task
                    Printer.PrintAddMenu();

                    option = MyConsoleReader.ReadInt32("Enter any adding option --> ", 1, 4);

                    AddTaskSwitch(option);
                    break;
                case 2: // Print tasks
                    PrintUniversityTasks();
                    PrintGeneralTasks();
                    break;
                case 3: // Sort tasks by remaining date
                    taskManager.SortTasksByRemainingDate();
                    Console.WriteLine("Tasks has been successfully sorted.");
                    break;
                case 4: // Mark task as completed
                    MarkTaskAsCompleted();
                    break;
                case 5: // Delete task
                    RemoveTask();
                    break;
                case 6: // Clear task manager
                    taskManager.Clear();
                    Console.WriteLine("Task manager list has been successfully cleared.");
                    break;
                case 7: // Print main menu
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
                    AddUniversityTasksRandomly();
                    break;
                case 3: // Add general task
                    AddGeneralTask();
                    break;
                case 4: // Add general task randomly
                    AddGeneralTasksRandomly();
                    break;
            }
        }

        private void AddUniversityTask()
        {
            try
            {
                MyUniversityTask task = new MyUniversityTask();

                task.Id = MyConsoleReader.ReadInt32("Enter task id --> ", 1, 99);
                task.CourseName = MyConsoleReader.ReadString("Enter course name --> ");
                task.Description = MyConsoleReader.ReadString("Enter task description --> ");
                task.Deadline = MyConsoleReader.ReadDateTime("Enter task deadline --> ", "dd.MM.yyyy");
                task.Status = MyConsoleReader.ReadMyTaskStatus("Enter task status --> ");

                taskManager.Add(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AddUniversityTask();
            }
        }
        private void AddUniversityTasksRandomly()
        {
            int count = MyConsoleReader.ReadInt32("Enter how many tasks you want to add --> ");

            MyTaskRandomProperties randomProperties = new MyTaskRandomProperties();

            while (count --> 0)
            {
                MyUniversityTask task = new MyUniversityTask();

                task.Id = randomProperties.GetId();
                task.CourseName = randomProperties.GetCourseName();
                task.Description = randomProperties.GetDescription();
                task.Deadline = randomProperties.GetDeadline();
                task.Status = randomProperties.GetTaskStatus();

                taskManager.Add(task);
            }
        }

        private void AddGeneralTask()
        {
            try
            {
                MyGeneralTask task = new MyGeneralTask();

                task.Id = MyConsoleReader.ReadInt32("Enter task id --> ", 1, 99);
                task.Title = MyConsoleReader.ReadString("Enter title --> ");
                task.Description = MyConsoleReader.ReadString("Enter task description --> ");
                task.Deadline = MyConsoleReader.ReadDateTime("Enter task deadline --> ", "dd.MM.yyyy");
                task.Status = MyConsoleReader.ReadMyTaskStatus("Enter task status --> ");

                taskManager.Add(task);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AddGeneralTask();
            }
        }
        private void AddGeneralTasksRandomly()
        {
            int count = MyConsoleReader.ReadInt32("Enter how many tasks you want to add --> ");

            MyTaskRandomProperties randomProperties = new MyTaskRandomProperties();

            while (count-- > 0)
            {
                MyGeneralTask task = new MyGeneralTask();

                task.Id = randomProperties.GetId();
                task.Title = randomProperties.GetTitle();
                task.Description = randomProperties.GetDescription();
                task.Deadline = randomProperties.GetDeadline();
                task.Status = randomProperties.GetTaskStatus();

                taskManager.Add(task);
            }
        }

        private void PrintUniversityTasks()
        {
            List<ITablePrintable> list = ToTablePrintableList(taskManager.ToList(), typeof(MyUniversityTask));
            TablePrinter tablePrinter = new TablePrinter(list);
            tablePrinter.PrintTable();
        }
        private void PrintGeneralTasks()
        {
            List<ITablePrintable> list = ToTablePrintableList(taskManager.ToList(), typeof(MyGeneralTask));
            TablePrinter tablePrinter = new TablePrinter(list);
            tablePrinter.PrintTable();
        }

        private void RemoveTask()
        {
            string typeString = MyConsoleReader.ReadString("Enter task type [University/General] --> ");

            Type type = null;
            if (typeString.Equals("University"))
            {
                PrintUniversityTasks();
                type = typeof(MyUniversityTask);
            }
            else
            {
                PrintGeneralTasks();
                type = typeof(MyGeneralTask);
            }                

            int id = MyConsoleReader.ReadInt32("Enter task id you want to remove --> ", 1, 99);

            for (int i = 0; i < taskManager.Count; i++)
            {
                if (taskManager[i].GetType() == type && taskManager[i].Id == id)
                {
                    taskManager.RemoveAt(i);
                    Console.WriteLine("Task has been successfully removed.");
                    return;
                }
            }

            Console.WriteLine("No task whith this id was found.");
        }

        private void MarkTaskAsCompleted()
        {
            string typeString = MyConsoleReader.ReadString("Enter task type [University/General] --> ");

            Type type = null;
            if (typeString.Equals("University"))
            {
                PrintUniversityTasks();
                type = typeof(MyUniversityTask);
            }
            else
            {
                PrintGeneralTasks();
                type = typeof(MyGeneralTask);
            }

            int id = MyConsoleReader.ReadInt32("Enter task id you want to remove --> ", 1, 99);

            for (int i = 0; i < taskManager.Count; i++)
            {
                if (taskManager[i].GetType() == type && taskManager[i].Id == id)
                {
                    taskManager[i].MarkAsCompleted();
                    Console.WriteLine("Task has been successfully marked.");
                    return;
                }
            }

            Console.WriteLine("No task whith this id was found.");
        }

        private void SaveTasks()
        {
            ListDataWriter<MyTask> dataWriter = new ListDataWriter<MyTask>(taskManager.ToList());
            dataWriter.WriteToJsonFile(path);
        }

        private List<ITablePrintable> ToTablePrintableList(List<MyTask> tasks, Type type)
        {
            List<ITablePrintable> tablePrintables = new List<ITablePrintable>();

            foreach (MyTask task in tasks)
            {
                if (type.IsAssignableFrom(task.GetType()))
                {
                    tablePrintables.Add(task);
                }
            }

            return tablePrintables;
        }
    }
}
