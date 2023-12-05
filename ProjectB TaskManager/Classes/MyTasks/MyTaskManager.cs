using ProjectB_TaskManager.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace ProjectB_TaskManager.Classes.MyTasks
{
    public class MyTaskManager : ICollection, IEnumerable<MyTask>, IDuplicateCheckable
    {
        private List<MyTask> tasks;

        public MyTaskManager()
        {
            tasks = new List<MyTask>();
        }

        public int Count => tasks.Count;

        public object SyncRoot => ((ICollection)tasks).SyncRoot;
        public bool IsSynchronized => ((ICollection)tasks).IsSynchronized;

        public MyTask this[int index]
        {
            get { return tasks[index]; }
            set { tasks[index] = value; }
        }

        /// <summary>
        /// Adds task to task manager list.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="DuplicateNameException"></exception>
        public void Add(MyTask item)
        {
            if (IsDuplicate(item))
            {
                throw new DuplicateNameException("Task whith this course name and description already exists!");
            }

            tasks.Add(item);
        }
        /// <summary>
        /// Removes all tasks in task manager list.
        /// </summary>
        public void Clear()
        {
            tasks.Clear();
        }
        /// <summary>
        /// Сhecks whether such a task exists in task manager list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>
        /// Returns <see langword="true"/> if this task exists, otherwise <see langword="false"/>.
        /// </returns>
        public bool Contains(MyTask item)
        {
            return tasks.Contains(item);
        }
        /// <summary>
        /// Removes the first occurrence of a transmitted task in task manager list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>
        /// Returns <see langword="true"/> if transmitted task has been removed, otherwise <see langword="false"/>.
        /// </returns>
        public bool Remove(MyTask item)
        {
            return tasks.Remove(item);
        }
        public List<MyTask> ToList()
        {
            throw new NotImplementedException();
        }
        public void SortTasksByReamingDate()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<MyTask> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicate(MyTask item)
        {
            throw new NotImplementedException();
        }
    }
}