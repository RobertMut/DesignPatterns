using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.UnitOfWork.Logic
{
    public class InternalSet<T> : IEnumerable<T>, ICollection<T> where T : class
    {
        private List<T> list;

        public InternalSet()
        {
            if (list is null)
            {
                list = new List<T>();
            }

        }

        public void Append(T element)
        {
            list.Append(element);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public int Count => list.Count;

        public bool IsReadOnly => throw new NotImplementedException();
    }
}