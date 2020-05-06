using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;

namespace N6_ClassLib.SkipLibrary
{
    class Node<T> where T : IComparable
    {
        private static Random randomizer = new Random();
        //здесь так же как в массиве, но вместо индекса элемента ниже тут хранятся ссылки на соседний и нижний элементы
        public T value;
        public Node<T> next, down;
        double variety;

        public Node(T _value, double _variety)   //сюда передадим ключ и вероятность 
        {
            value = _value;
            next = null;
            down = null;
            variety = _variety;
        }

        public Node<T> this[int id]
        {
            get
            {
                if (id == 0)
                    return this;

                if (next == null)
                    return null;

                return next[id - 1];
            }
        }

        //вставка узла после текущего this, это вспомогательный метод
        private void addNext(T item)
        {
            Node<T> newnode = new Node<T>(item, variety);
            newnode.next = this.next;
            this.next = newnode;
        }

        //добавление узла с поддержанием вертикальной связи
        public Node<T> AddNode(T item, out bool success)
        {
            Node<T> node = this;
            while ((node.next != null) && (item.CompareTo(node.next.value) > 0))
            {
                node = node.next;
            }
            if ((node.next != null) && (node.next.value.CompareTo(item) == 0))
            {
                success = false;
                return null;    //если такой элемент есть, то null
            }
            //если мы на нижнем уровне, то просто добавляем item после последнего элемента, меньшего его (если дошли до него в while)
            if (node.down == null)
            {
                node.addNext(item); //теперь node.next станет item
                success = true;                
                if (randomizer.NextDouble() < variety)
                    return node.next; //возвращает item, если он есть на уровне выше
            }
            else
            //если ниже еще есть уровни, то смотрим вероятности
            {
                //добавляем ссылку на уровень ниже узел
                Node<T> downnode = node.down.AddNode(item, out success);
                if (downnode != null)
                {
                    node.addNext(item);
                    node.next.down = downnode;
                    if (randomizer.NextDouble() < variety)
                        return node.next;   //проверяем, нужно ли создавать узел на уровне выше
                }
            }
            return null;
        }

        //поуровневое отображение
        public void Display(ref Forms.Panel panel, ref int x, int y, bool visible)
        {
            //отображение текущего узла
            if (visible)
                panel.Controls.Add(UI.fillTextBox(value, x, y));
            //на нижнем уровне:
            if (down == null)
            {
                if (next != null)
                {
                    //отображение оставшейся части списка
                    if (visible)
                        x += UI.width + UI.left;
                    next.Display(ref panel, ref x, y, true);
                }
            }
            else
            {
                //рисуем нижний узел, если есть узел справа, рисуем и его
                if (next != null)
                {
                    down.Display(ref panel, ref x, y + UI.height + UI.top, visible, next.value);    //перегрузка с 5-ю арг.
                    next.Display(ref panel, ref x, y, true);
                }
                else
                {
                    down.Display(ref panel, ref x, y + UI.height + UI.top, visible);
                }
            }
        }
        
        //отображение подсписка с учетом выхода за передаваемую юзером границу (нужно для отображения текущего и правого элемента в display выше)
        void Display(ref Forms.Panel panel, ref int x, int y, bool visible, T rightBorder)
        {
            if (visible)
                panel.Controls.Add(UI.fillTextBox(value, x, y));

            if (down == null)
            {
                if (visible)
                    x += UI.width + UI.left;
                //если не выходит за границу
                if ((next != null) && (next.value.CompareTo(rightBorder) < 0))
                {
                    next.Display(ref panel, ref x, y, true, rightBorder);
                }
            }
            else
            {
                //узел справа отображается, если не выходит за указанную границу
                if ((next != null) && (next.value.CompareTo(rightBorder) < 0))
                {
                    down.Display(ref panel, ref x, y + UI.height + UI.top, visible, next.value);
                    next.Display(ref panel, ref x, y, true, rightBorder);
                }
                else
                {
                    down.Display(ref panel, ref x, y + UI.height + UI.top, visible, rightBorder);
                }
            }
        }
    }
}
