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
            : this("No Course", "No Description", DateTime.MaxValue, MyTaskStatus.NotStarted) { }

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
            throw new NotImplementedException();
        }

        public override string GetTableHeader()
        {
            throw new NotImplementedException();
        }

        public override string GetTableRow()
        {
            StringBuilder tableRow = new StringBuilder("| ");
            StringFormatter formatter = new StringFormatter();

            if (courseName.Length > 10)
            {
                 tableRow.AppendLine(formatter.FormatToLength(courseName, 10) + " | ");
            }
            else
            {
                tableRow.AppendLine(courseName + new String(' ', 10 - courseName.Length) + " | ");
            }

            if (description.Length > 20)
            {
                tableRow.AppendLine(formatter.FormatToLength(description, 20) + " | ");
            }
            else
            {
                tableRow.AppendLine(description + new String(' ', 10 - description.Length) + " | ");
            }

            tableRow.AppendLine(deadline.ToString("dd.MM.yyyy") + " |");

            return tableRow.ToString();
        }
    }
}
