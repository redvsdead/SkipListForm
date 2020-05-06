using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;

namespace N6_ClassLib.SkipLibrary
{
    abstract class SkipList<T> : IList<T> where T : IComparable
    {
        public abstract bool isEmpty();
        public abstract void Display(ref Forms.Panel panel);


        public abstract T this[int index] { get; set; }

        public abstract int Count { get; }
        public abstract bool IsReadOnly { get; }

        public abstract void Add(T item);
        public abstract void Clear();
        public abstract bool Contains(T item);
        public abstract void CopyTo(T[] array, int arrayIndex);
        public abstract IEnumerator<T> GetEnumerator();
        public abstract int IndexOf(T item);
        public abstract bool Remove(T item);
        public abstract void RemoveAt(int index);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
    }
}
