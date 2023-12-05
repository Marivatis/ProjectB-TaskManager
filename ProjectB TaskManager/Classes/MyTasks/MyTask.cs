using ProjectB_TaskManager.Enums;
using System;

namespace ProjectB_TaskManager.Classes.General
{
    public abstract class MyTask : ITablePrintable
    {
        private string description;
        private DateTime deadline;
        private MyTaskStatus status;

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

        public abstract override int GetHashCode();

        public abstract string GetTableHeader();
        public abstract string GetTableRow();
        public abstract string GetTableFooter();
    }
}