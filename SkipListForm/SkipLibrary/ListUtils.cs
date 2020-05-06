using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_ClassLib.SkipLibrary
{
    //вспомогательные операции над списком с пропусками
    static class ListUtils
    {
        public delegate bool CheckDelegate<T>(T item);
        public delegate IList<T> ListConstructorDelegate<T>();
        public delegate TO ConvertDelegate<TI, TO>(TI item);
        public delegate void ActionDelegate<T>(T item);
        
        //проверяет существование элемента списка, удовлетворяещего условиям предиката
        public static bool Exists<T>(IList<T> list, CheckDelegate<T> check)
        {
            foreach (T item in list)
                if (check(item))
                    return true;
            return false;
        }

        //возвращает элемент, удовлетворяющий условиям предиката
        public static T Find<T>(IList<T> list, CheckDelegate<T> check)
        {
            foreach (T item in list)
                if (check(item))
                    return item;
            throw new Exception("Can not find the element");
        }

        //возвращает последний элемент списка, удовлетворяющий условиям предиката
        public static T FindLast<T>(IList<T> list, CheckDelegate<T> check)
        {
            bool found = false;
            T last = default(T);

            foreach (T item in list)
                if (check(item))
                {
                    last = item;
                    found = true;
                }

            if (found)
                return last;
            throw new Exception("Can not find the element");
        }

        //возвращает индекс первого элемента списка, удовлетворяющего условиям предиката
        public static int FindIndex<T>(IList<T> list, CheckDelegate<T> check)
        {
            for (int i = 0; i < list.Count; ++i)
                if (check(list[i]))
                    return i;
            return -1;
        }

        //возвращает индекс последнего элемента списка, удовлетворяющего условиям предиката
        public static int FindLastIndex<T>(IList<T> list, CheckDelegate<T> check)
        {
            int last = -1;
            for (int i = 0; i < list.Count; ++i)
                if (check(list[i]))
                    last = i;
            return last;
        }

        //возвращает все элементы списка, удовлетворяещие условиям предиката
        public static IList<T> FindAll<T>(IList<T> list, CheckDelegate<T> check, ListConstructorDelegate<T> construct)
        {
            IList<T> found = construct();

            foreach (T item in list)
                if (check(item))
                    found.Add(item);

            return found;
        }

        //конвертирует список типа TI в список типа TO
        public static IList<TO> ConvertAll<TI, TO>(IList<TI> list, ConvertDelegate<TI, TO> convert, ListConstructorDelegate<TO> construct)
        {
            IList<TO> converted = construct();
            foreach (TI item in list)
                converted.Add(convert(item));
            return converted;
        }

        //применяет делегат к каждому элементу списка
        public static void ForEach<T>(IList<T> list, ActionDelegate<T> process)
        {
            foreach (T item in list)
                process(item);
        }

        //проверяет все элементы на соответствие предикату
        public static bool CheckForAll<T>(IList<T> list, CheckDelegate<T> check)
        {
            foreach (T item in list)
                if (!check(item))
                    return false;
            return true;
        }

    }
}
