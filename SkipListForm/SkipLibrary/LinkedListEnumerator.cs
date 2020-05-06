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

        public T Current => cursor.value;

        object IEnumerator.Current => cursor.value;

        Node<T> start, cursor;

        public LinkedListEnumerator(Node<T> begin)
        {
            start = begin;
            Reset();
        }

        public void Dispose()
        {
            start = null;
        }

        public bool MoveNext()
        {
            cursor = cursor.next;
            return cursor != null;
        }

        public void Reset()
        {
            cursor = start;
        }
    }
}
