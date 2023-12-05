using ProjectB_TaskManager.Enums;
using System;

namespace ProjectB_TaskManager.Classes.General
{
    public class MyTask : ITablePrintable
    {
        private int id;
        private string description;
        private DateTime deadline;
        private MyTaskStatus status;

        public MyTask() : this(0, string.Empty, DateTime.MinValue, MyTaskStatus.NotStarted) { }

        public MyTask(int id, string description, DateTime deadline, MyTaskStatus status)
        {
            throw new NotImplementedException();
        }
        
        public int Id
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public string Description
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public MyTaskStatus Status
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public DateTime Deadline
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TimeSpan ReamingTime
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsOverdue()
        {   
            throw new NotImplementedException();
        }
        public void MarkAsCompleted()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        
        public string GetTableHeader()
        {
            throw new NotImplementedException();
        }
        public string GetTableRow()
        {
            throw new NotImplementedException();
        }
        public string GetTableFooter()
        {
            throw new NotImplementedException();
        }
    }
}