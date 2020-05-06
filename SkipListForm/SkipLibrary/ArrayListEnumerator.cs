using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_ClassLib.SkipLibrary
{
    class ArrayListEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        public T Current => Arr[index].value;

        object IEnumerator.Current => throw new NotImplementedException();

        private Cell<T>[] Arr;
        private int index, maxLen;

        public ArrayListEnumerator(Cell<T>[] _array, int _maxid)
        {
            Arr = _array;
            index = -1;
            maxLen = _maxid;
        }

        public bool MoveNext()
        {
            return ++index != maxLen;
        }

        public void Reset()
        {
            index = 0;
        }

        public void Dispose()
        {
            Arr = null;
        }

    }
}