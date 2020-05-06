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
        public T Current => array[index].value;

        object IEnumerator.Current => throw new NotImplementedException();

        private Cell<T>[] array;
        private int index, maxid;

        public ArrayListEnumerator(Cell<T>[] layer, int maxlen)
        {
            array = layer;
            index = -1;
            maxid = maxlen;
        }

        public void Dispose()
        {
            array = null;
        }

        public bool MoveNext()
        {
            return ++index != maxid;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}