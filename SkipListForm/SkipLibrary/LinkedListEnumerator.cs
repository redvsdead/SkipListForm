using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_ClassLib.SkipLibrary
{
    class LinkedListEnumerator<T> : IEnumerator<T> where T : IComparable
    {

        public T Current => current.value;

        object IEnumerator.Current => current.value;

        Node<T> start, current;

        public LinkedListEnumerator(Node<T> begin)
        {
            start = begin;
            Reset();
        }

        public bool MoveNext()
        {
            current = current.next;
            return current != null;
        }

        public void Reset()
        {
            current = start;
        }

        public void Dispose()
        {
            start = null;
        }
    }
}
