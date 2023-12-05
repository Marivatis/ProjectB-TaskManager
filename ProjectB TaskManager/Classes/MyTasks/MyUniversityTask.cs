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
            throw new NotImplementedException();
        }
    }
}
