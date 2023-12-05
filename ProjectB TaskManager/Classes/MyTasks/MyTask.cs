using ProjectB_TaskManager.Enums;
using System;

namespace ProjectB_TaskManager.Classes.MyTasks
{
    public abstract class MyTask : ITablePrintable
    {
        protected string description;
        protected DateTime deadline;
        protected MyTaskStatus status;

        protected MyTask(string description, DateTime deadline, MyTaskStatus status) 
        {
            this.description = description;
            this.deadline = deadline;
            this.status = status;
        }

        public abstract string Description { get; set; }      
        
        public virtual DateTime Deadline 
        {
            get
            {
                return deadline;
            }
            set
            {
                if (value < DateTime.UtcNow)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Deadline cannot be less than the current date.");
                }

                deadline = value;
            }
        }
        public virtual MyTaskStatus Status 
        {
            get
            {
                return status;
            }
            set
            {
                if (!Enum.IsDefined(typeof(MyTaskStatus), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value does not match enum MyTaskStatus.");
                }

                status = value;
            }
        }

        public TimeSpan RemainingTime => Deadline - DateTime.UtcNow;

        public void MarkAsCompleted()
        {
            Status = MyTaskStatus.Completed;
        }

        public virtual bool IsOverdue()
        {
            return RemainingTime <= TimeSpan.Zero;
        }

        public abstract override int GetHashCode();

        public abstract string GetTableHeader();
        public abstract string GetTableRow();
        public abstract string GetTableFooter();
    }
}