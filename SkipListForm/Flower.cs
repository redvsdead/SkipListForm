using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkipListForm
{
    //класс цветка для каталога товаров цветочного магазина
    class Flower : IComparable
    {
        public string type { get; private set; }    //название цветка
        public string colour { get; private set; }  //цвет

        public Flower(string _type, string _colour)
        {
            //если строки в textbox'ах не пустые/из пробелов или разделителей, делаем цветок
            if (!(string.IsNullOrWhiteSpace(_type)) && !(string.IsNullOrWhiteSpace(_colour)))
            {
                type = _type;
                colour = _colour;
            }
        }

        //конвертация в строку для вывода
        public override string ToString()
        {
            return type + " / " + colour;
        }

        //для сравнения объектов
        public int CompareTo(object obj)
        {
            if (!(obj is Flower))
                throw new ArgumentException("Warning: uncomparable objects");
            //если сравниваем с цветком, то возвращаем совпадение названия и цвета
            int comp = type.CompareTo((obj as Flower).type);
            if (comp != 0)
                return comp;
            return colour.CompareTo((obj as Flower).colour);
        }
    }
}
