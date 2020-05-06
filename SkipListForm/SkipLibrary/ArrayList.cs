using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N6_ClassLib.SkipLibrary;

namespace N6_ClassLib.SkipLibrary
{
    //нижним уровнем считается layerCount - 1, верхним -- 0
    class ArrayList<T> : SkipList<T> where T : IComparable
    {
        Random randomizer = new Random();
        Cell<T>[][] layers; //массив массивов ячеек Cell
        double variety;  //шанс добавления элемента на следующий уровень, генерируется рандомно
        int layerCount, currCount, maxCount;
        //в конструктор передают макс. длину, текущее к-во слоев, вероятность добавления (50%)
        public ArrayList(int _maxCount = 100, int _layerCount = 4, double _variety = 0.5)
        {
            if ((_layerCount <= 0) || (_maxCount <= 0) || (variety < 0))
                throw new ArgumentException();  //проверка корректности параметров

            variety = _variety;
            layerCount = _layerCount;
            maxCount = _maxCount;
            layers = new Cell<T>[layerCount][];
            for (int i = 0; i < layerCount; ++i)
                layers[i] = new Cell<T>[_maxCount];    //в каждый слой из текущего к-ва помещаем массив элементов
            currCount = 0;
            //опустошаем массивы
            for (int i = 0; i < layerCount; ++i)
                for (int j = 0; j < maxCount; ++j)
                    layers[i][j] = null;
        }

        public override int Count => currCount;
        //свойство Count

        //проверка на пустоту
        public override bool isEmpty()
        {
            return Count == 0;
        }

        //заполнение элементами управления для отображения на форме
        public override void Display(ref Panel panel)
        {
            panel.Controls.Clear();
            //indexCurr[N] содержит индекс текущего элемента для уровня N, он нужен, чтобы выводить элемент в столбец от нижнего слоя к верхнему
            int[] indexCurr = new int[layerCount];
            for (int i = 0; i < layerCount; ++i)
                indexCurr[i] = 0;
            //для каждого элемента нижнего уровня (layerCount - 1) запоминаем его индекс и добавляем элемент управления с информацией о нем
            for (int j = 0; j < Count; ++j)
            {
                indexCurr[layerCount - 1] = j + 1;  //+1 нужен для корректной отрисовки на панели
                panel.Controls.Add(UI.fillTextBox(this[j], 40 + j * (UI.width + UI.left), 40 + (layerCount - 1) * (UI.height + UI.top)));
                int i = layerCount - 2; //идем на слой выше, сейчас это второй
                //пока не дошли до вершины списка && текущий элемент ссылается на свою копию ниже 
                //и пока можно идти вверх, мы выводим тот же j-й элемент
                while ((i >= 0) && (layers[i][indexCurr[i]] != null) && (layers[i][indexCurr[i]].down == (indexCurr[i + 1]) - 1))
                {
                    //отображаем и увеличиваем счетчик соотв. уровня
                    panel.Controls.Add(UI.fillTextBox(this[j],
                    40 + j * (UI.width + UI.left),
                    40 + i * (UI.height + UI.top)));                    
                    indexCurr[i]++;   //увеличиваем счетчик и идем на уровень ниже
                    i--;
                }
            }
        }


        //индексатор ячейки
        public override T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= currCount))   //проверка на пустоту и выход за границы
                    throw new IndexOutOfRangeException();
                return layers[layerCount - 1][index].value;
            }
            set
            {
                //set не нужен, тк это упорядоченная структура
            }
        }

        public override bool IsReadOnly => false;

        //сдвигает уровень вправо на один элемент, начиная с какого-то индекса
        private void moveRight(int level, int startIndex)
        {
            for (int j = maxCount - 1; j > startIndex; --j)
                layers[level][j] = layers[level][j - 1];
            //теперь меняем указатели на высшие уровни для сдвинутых ячеек (если они есть)
            if (level > 0)
                for (int j = 0; (j < maxCount) && (layers[level - 1][j] != null); ++j)
                    if (layers[level - 1][j].down >= startIndex)
                        layers[level - 1][j].down++;
        }

        //абсолютно аналогичный сдвиг влево
        private void moveLeft(int level, int startIndex)
        {
            for (int j = startIndex; j < maxCount - 1; ++j)
                layers[level][j] = layers[level][j + 1];
            layers[level][maxCount - 1] = null;
            if (level > 0)
                for (int j = 0; (j < maxCount) && (layers[level - 1][j] != null); ++j)
                    if (layers[level - 1][j].down > startIndex)
                        layers[level - 1][j].down--;
        }

        //добавление в список (рекурсивное), начиная с какого-то слоя на установленную позицию
        //возвращает -1/-2 -- индикаторы остановки рекурсии, либо индекс, по которому вставили item, если нужен элемент сверху
        private int addToLayer(T item, int layer, int start)
        {
            //пока есть элементы бОльшие item, пропускаем их
            while ((layers[layer][start] != null) && (layers[layer][start].value.CompareTo(item) < 0))
                ++start;
            //если item уже есть в списке, возвращаем -1
            if ((layers[layer][start] != null) && (layers[layer][start].value.CompareTo(item) == 0))
                return -1;
            //в [layer, start] лежит null либо первый бОльший item элемент на текущем слое
            //если есть уровни ниже, вызывается рекурсия
            if ((layer + 1) < layerCount)
            {
                int lower = addToLayer(item, layer + 1, Math.Max(0, start - 1));
                if (lower >= 0) //если элемент ниже был добавлен, то идем дальше
                //если нужно еще добавить элемент на уровень выше, возвращаем номер позиции, если нет, то -2
                {
                    moveRight(layer, start);
                    layers[layer][start] = new Cell<T>(item);
                    layers[layer][start].down = lower;
                    //если нужно добавить элемент наверх, то возвращаем нужный индекс, иначе -2
                    if (randomizer.NextDouble() < variety)
                        return start;
                    return -2;
                }
                return lower;
            }
            //иначе на последнем (нижнем) уровне сдвигают кусок вправо с позиции start и на нее просто вставляется элемент
            else
            {
                moveRight(layer, start);
                layers[layer][start] = new Cell<T>(item);   //на нижнем уровне вставка осуществляется всегда
                if (randomizer.NextDouble() < variety)   //если проходит по вероятности, возвращаем позицию на след. уровне
                    return start;
                return -2;  //иначе -2
            }
        }

        //если можно добавить, вызываем addToLayer с самого нижнего уровня
        public override void Add(T item)
        {
            if (Count == maxCount)
                throw new SkipListOverflowException("Warning: List overflow");
            if (addToLayer(item, 0, 0) != -1)
                ++currCount;
        }

        public override void Clear()
        {
            for (int i = 0; i < layerCount; ++i)
                for (int j = 0; (j < maxCount) && (layers[i][j] != null); ++j)
                    layers[i][j] = null;
            currCount = 0;
        }

        public override bool Contains(T item)
        {
            int layer = 0;  //ищем элемент, начиная с высшего уровня, опускаясь ниже
            int i = 0;
            while (layer < layerCount)
            {
                while ((i < maxCount) && (layers[layer][i] != null) && (layers[layer][i].value.CompareTo(item) < 0))
                    ++i;    //пропускаем меньшие элементы
                if ((layers[layer][i] != null) && (layers[layer][i].value.CompareTo(item) == 0))
                    return true;
                //если не нашли на текущем уровне, идем ниже (если не на 0-м уровне)
                i = (i > 0) ? layers[layer][i - 1].down : 0;
                ++layer;
            }
            return false;
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; ++i)
                array[arrayIndex + i] = this[i];
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new ArrayListEnumerator<T>(layers[layerCount - 1], Count);
        }

        //возвращает индекс элемента в списке (или -1)
        public override int IndexOf(T item)
        {
            for (int i = 0; (i < maxCount) && (layers[layerCount - 1][i] != null); ++i)
                if (layers[layerCount - 1][i].value.CompareTo(item) == 0)  //если элемент на каком-то уровне найден, return номер
                    return i;
            return -1;
        }

        public override bool Remove(T item)
        {
            bool exists = false;  //существует ли такой элемент в списке
            int layer = 0, start = 0;
            //идем от верхнего уровня к нижнему
            while (layer < layerCount)
            {
                while ((layers[layer][start] != null) && (layers[layer][start].value.CompareTo(item) < 0))
                    ++start;
                //найденный нужный элемент удаляем, отмечаем, что он существует
                if ((layers[layer][start] != null) && (layers[layer][start].value.CompareTo(item) == 0))
                {
                    moveLeft(layer, start);
                    exists = true;
                }
                //если есть слои ниже, то идем удалять по ним
                if (start > 0)
                    start = layers[layer][start - 1].down;
                ++layer;
            }
            //если такой элемент был, уменьшаем к-во элементов в списке
            if (exists)
                --currCount;
            return exists;
        }

        //удаление по индексу
        public override void RemoveAt(int index)
        {
            Remove(this[index]);
        }
    }
}
