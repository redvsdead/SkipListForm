using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N6_ClassLib.SkipLibrary
{
    //обертка списка (выдает исключение на любую попытку его изменить)
    class ImmutableList<T> : SkipList<T> where T : IComparable
    {
        //оборачивает список
        private SkipList<T> InnerList;

        public ImmutableList(SkipList<T> list)
        {
            InnerList = list;
        }
        public override int Count => InnerList.Count;

        public override T this[int index]
        {
            get => InnerList[index];
            set => throw new SkipListImmutableException();
        }

        public override void Add(T item) => throw new SkipListImmutableException();

        public override void Clear() => throw new SkipListImmutableException();

        public override bool Remove(T item) => throw new SkipListImmutableException();

        public override void RemoveAt(int index) => throw new SkipListImmutableException();

        public override bool IsReadOnly => true;

        public override bool Contains(T item) => InnerList.Contains(item);

        public override void CopyTo(T[] array, int arrayIndex) => InnerList.CopyTo(array, arrayIndex);

        public override void Display(ref Panel panel) => InnerList.Display(ref panel);

        public override int IndexOf(T item) => InnerList.IndexOf(item);

        public override bool isEmpty() => InnerList.isEmpty();

        public override IEnumerator<T> GetEnumerator() => InnerList.GetEnumerator();
    }
}
