using ProjectB_TaskManager.Enums;
using System;

namespace ProjectB_TaskManager.Classes.General
{
    public abstract class MyTask : ITablePrintable
    {
        private int id;
        private string description;
        private DateTime deadline;
        private MyTaskStatus status;

        public int Id => id;
        public string Description { get; set; }
        public abstract MyTaskStatus Status { get; set; }
        public abstract DateTime Deadline { get; set;  }

        public TimeSpan RemainingTime => Deadline - DateTime.UtcNow;

        public virtual bool IsOverdue()
        {
            return RemainingTime <= TimeSpan.Zero;
        }
        public void MarkAsCompleted()
        {
            Status = MyTaskStatus.Completed;
        }

        public override int GetHashCode()
        {
            int hash = 3;

            hash += Id.GetHashCode();

            return hash;
        }

        public abstract string GetTableHeader();
        public abstract string GetTableRow();
        public abstract string GetTableFooter();
    }
}