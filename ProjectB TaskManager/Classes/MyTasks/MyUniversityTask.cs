using ProjectB_TaskManager.Classes.General;
using ProjectB_TaskManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB_TaskManager.Classes.MyTasks
{
    public class MyUniversityTask : MyTask
    {
        private string courseName;

        public MyUniversityTask()
            : this("No Course", "No Description", DateTime.MinValue, MyTaskStatus.NotStarted) { }

        public MyUniversityTask(string courseName, string description, DateTime deadline, MyTaskStatus status)
            : base(description, deadline, status)
        {
            this.courseName = courseName;
        }

        public string CourseName
        {
            get
            {
                return courseName;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentException(nameof(value), "The course name length must be from 1 to 20 characters!");
                }

                if (string.IsNullOrEmpty(value)) 
                {
                    courseName = "No Course";
                }
                else
                {
                    courseName = value;
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
                if (value.Length > 100)
                {
                    throw new ArgumentException(nameof(value), "The description length must be from 1 to 100 characters!");
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

            hash += courseName.GetHashCode();
            hash += description.GetHashCode();

            return hash;
        }

        public override string GetTableFooter()
        {
            // Course Name Length --> 11
            // Task Description Length --> 21
            // Task Status Length --> 11
            // Deadline Length --> 10
            // All Borders Length --> 13

            return new String('-', 66);
        }
        public override string GetTableHeader()
        {
            StringBuilder tableHeader = new StringBuilder("| ");
            StringFormatter formatter = new StringFormatter();

            tableHeader.Append(formatter.FormatToLength("Course Name", 11) + " | ");
            tableHeader.Append(formatter.FormatToLength("Task Description", 21) + " | ");
            tableHeader.Append(formatter.FormatToLength("Task Status", 11) + " | ");
            tableHeader.Append(formatter.FormatToLength("Deadline", 10) + " |");

            return tableHeader.ToString();
        }
        public override string GetTableRow()
        {
            StringBuilder tableRow = new StringBuilder("| ");
            StringFormatter formatter = new StringFormatter();

            tableRow.Append(formatter.FormatToLength(courseName, 11) + " | ");
            tableRow.Append(formatter.FormatToLength(description, 21) + " | ");
            tableRow.Append(formatter.FormatToLength(status.ToString(), 11) + " | ");

            tableRow.Append(deadline.ToString("dd.MM.yyyy") + " |");

            return tableRow.ToString();
        }
    }
}
