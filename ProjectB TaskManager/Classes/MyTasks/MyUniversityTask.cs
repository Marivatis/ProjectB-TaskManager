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
        public override string Description 
        {
            get 
            {
                return description; 
            }
            set 
            {
                if (value.Length > 100)
                    throw new ArgumentException(nameof(value), "The string lenght must be from 1 to 100 characters!");

                description = value;
            }
        }
        public override MyTaskStatus Status 
        {
            get
            {
                return status;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override DateTime Deadline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
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
