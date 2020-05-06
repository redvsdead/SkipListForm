using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;

namespace N6_ClassLib.SkipLibrary
{
    //класс для генерации элементов управления, отображающих ячеки списка
    class UI
    {
        public static int width { get => 50; }
        public static int height { get => 50; }
        public static int top { get => 5; }
        public static int left { get => 50; }
        //textbox для отображения элемента
        public static Forms.TextBox fillTextBox(object item, int x, int y)
        {
            Forms.TextBox tb = new Forms.TextBox();
            tb.Multiline = true;
            tb.MaxLength = width;
            tb.Height = height;
            tb.MaxLength = 4;
            tb.Top = y;
            tb.Left = x;
            tb.ReadOnly = true;
            tb.BackColor = System.Drawing.Color.White;
            tb.Text = item.ToString();
            return tb;
        }
    }
}
