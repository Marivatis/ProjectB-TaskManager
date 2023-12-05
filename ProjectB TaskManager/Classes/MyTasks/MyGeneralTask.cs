using ProjectB_TaskManager.Classes.General;
using ProjectB_TaskManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB_TaskManager.Classes.MyTasks
{
    public class MyGeneralTask : MyTask
    {
        private string title;

        public MyGeneralTask()
            : this("No Title", "No Description", DateTime.MinValue, MyTaskStatus.NotStarted) { }

        public MyGeneralTask(string title, string description, DateTime deadline, MyTaskStatus status)
            : base(description, deadline, status)
        {
            this.title = title;
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentException(nameof(value), "The title length must be from 1 to 20 characters!");
                }

                if (string.IsNullOrEmpty(value))
                {
                    title = "No Course";
                }
                else
                {
                    title = value;
                }
            }
        }

        public override string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentException(nameof(value), "The description length must be from 1 to 200 characters!");
                }

                if (string.IsNullOrEmpty(value))
                {
                    description = "No Description";
                }
                else
                {
                    description = value;
                }
            }
        }

        public override int GetHashCode()
        {
            int hash = 4;

            hash += title.GetHashCode();
            hash += description.GetHashCode();

            return hash;
        }

        public override string GetTableFooter()
        {
            // Title Length --> 20
            // Task Description Length --> 21
            // Task Status Length --> 11
            // Deadline Length --> 10
            // All Borders Length --> 13

            return new String('-', 75);
        }
        public override string GetTableHeader()
        {
            StringBuilder tableHeader = new StringBuilder("| ");
            StringFormatter formatter = new StringFormatter();

            tableHeader.Append(formatter.FormatToLength("Title", 20) + " | ");
            tableHeader.Append(formatter.FormatToLength("Task Description", 21) + " | ");
            tableHeader.Append(formatter.FormatToLength("Task Status", 11) + " | ");
            tableHeader.Append(formatter.FormatToLength("Deadline", 10) + " |");

            return tableHeader.ToString();
        }
        public override string GetTableRow()
        {
            StringBuilder tableRow = new StringBuilder("| ");
            StringFormatter formatter = new StringFormatter();

            tableRow.Append(formatter.FormatToLength(title, 20) + " | ");

            string[] description = formatter.FormatToLength(this.description, 21).Split('\n');
            tableRow.Append(description[0] + " | ");

            tableRow.Append(formatter.FormatToLength(status.ToString(), 11) + " | ");
            tableRow.Append(deadline.ToString("dd.MM.yyyy") + " |");

            for (int i = 1; i < description.Length; i++)
            {
                tableRow.Append("\n| ");
                tableRow.Append(formatter.FormatToLength(string.Empty, 20) + " | ");

                if (i == description.Length - 1)
                    tableRow.Append(formatter.FormatToLength(description[i], 21) + " | ");
                else
                    tableRow.Append(description[i] + " | ");

                tableRow.Append(formatter.FormatToLength(string.Empty, 11) + " | ");
                tableRow.Append(formatter.FormatToLength(string.Empty, 10) + " | ");
            }

            return tableRow.ToString();
        }
    }
}
