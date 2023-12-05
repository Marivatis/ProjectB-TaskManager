using ProjectB_TaskManager.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectB_TaskManager.Classes.General
{
    public class MyTaskManager : ICollection, IEnumerable<MyTask>, IDuplicateCheckable<MyTask>
    {
        private List<MyTask> tasks;

        public MyTaskManager()
        {
            throw new NotImplementedException();
        }

        public int Count => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();
        public bool IsSynchronized => throw new NotImplementedException();

        public MyTask this[int index]
        {
            get { return tasks[index]; }
            set { tasks[index] = value; }
        }

        public void Add(MyTask item)
        {
            throw new NotImplementedException();
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

        bool IDuplicateCheckable<MyTask>.IsDuplicate(MyTask item)
        {
            throw new NotImplementedException();
        }
    }
}