using ProjectB_TaskManager.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

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

        public void Add(MyTask item)
        {
            
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(MyTask item)
        {
            throw new NotImplementedException();
        }
        public bool Remove(MyTask item)
        {
            throw new NotImplementedException();
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