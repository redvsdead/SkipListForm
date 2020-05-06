using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_ClassLib.SkipLibrary
{
    //класс ячейки списка на основе массива, в down она хранит индекс элемента нижнего уровня
    class Cell<T> where T : IComparable
    {
        public T value;
        public int down;

        public Cell(T _value)
        {
            value = _value;
        }
    }
}
