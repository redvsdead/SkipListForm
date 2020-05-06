using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;
using N6_ClassLib.SkipLibrary;

namespace N6_ClassLib.SkipLibrary
{
    //нижним уровнем считается layerCount - 1, верхним -- 0
    class LinkedList<T> : SkipList<T> where T : IComparable
    {
        Node<T>[] layers;
        int layerCount, currCount;  //к-во слоев и текущее к-во элементов на слое
        double variety;
        public override int Count { get => currCount; }

        //в конструктор переается к-во слоев и шанс добавления
        public LinkedList(int _layerCount = 4, double _variety = 0.5)
        {
            if (_layerCount <= 0)
                throw new ArgumentException();
            variety = _variety;
            layerCount = _layerCount;
            layers = new Node<T>[layerCount];
            currCount = 0;
            //все заполняется пустыми головами, чтобы в других методах не создавать их
            layers[0] = new Node<T>(default(T), variety);
            for (int i = 1; i < layerCount; ++i)
            {
                layers[i] = new Node<T>(default(T), variety);   //создается голова
                layers[i - 1].down = layers[i]; //ссылка на предыдущую голову передается на текущую
            }
        }

        public override bool isEmpty() => currCount == 0;

        //заполняет контейнер элементами управления в соответствии со структурой списка
        public override void Display(ref Forms.Panel panel)
        {
            panel.Controls.Clear();
            int x = 40, y = 40;
            if (!isEmpty())
                layers[0].Display(ref panel, ref x, y, false);
        }
        

        public override bool IsReadOnly => false;

        //использует рекурсию из Node
        public override void Add(T item)
        {
            bool added;
            layers[0].AddNode(item, out added);
            if (added)
                ++currCount;
        }

        public override void Clear()
        {
            currCount = 0;
            for (int i = 0; i < layerCount; ++i)
                layers[i].next = null;
        }

        public override bool Contains(T item)
        {
            Node<T> node = layers[0];
            //поиск с верхнего уровня
            do
            {
                while ((node.next != null) && (item.CompareTo(node.next.value) > 0))
                {
                    node = node.next;
                }
                if ((node.next != null) && (node.next.value.CompareTo(item) == 0))
                    return true;
                //иначе идем ниже
                node = node.down;
            } while (node != null);

            return false;
        }
        
        public override void CopyTo(T[] array, int startInd)
        {
            for (int i = 0; (i < Count) && ((i + startInd) < array.Length); ++i)
            {
                array[i + startInd] = this[i];
            }
        }

        public override int IndexOf(T item)
        {
            int i = 0;
            for (Node<T> node = layers[layerCount - 1].next; node != null; node = node.next, ++i)
                if (node.value.CompareTo(item) == 0)
                {
                    return i;
                }
            return -1;
        }

        public override bool Remove(T item)
        {
            Node<T> node = layers[0];
            bool contains = false;  //есть ли такой элемент вообще
            //удаление сверху вниз
            while (node != null)
            {
                while ((node.next != null) && (item.CompareTo(node.next.value) > 0))
                {
                    node = node.next;
                }
                if ((node.next != null) && (node.next.value.CompareTo(item) == 0))
                {
                    //удаляем элемент на текущем уровне
                    node.next = node.next.next;
                    contains = true;
                }
                //спускаемся ниже, пока не дойдем до конца
                node = node.down;
            }

            return contains;
        }

        public override void RemoveAt(int index)
        {
            Remove(this[index]);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(layers[layerCount - 1]);
        }

        //индексатор
        public override T this[int index]
        {
            get
            {
                if (layers[layerCount - 1][index] == null) //исключение, если список пустой
                    throw new IndexOutOfRangeException();
                return layers[layerCount - 1][index].value;
            }
            set
            {
                //в отсортированной структуре в set нет смысла
            }
        }
    }
}

    
