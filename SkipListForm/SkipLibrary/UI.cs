using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forms = System.Windows.Forms;

namespace N6_ClassLib.SkipLibrary
{
    //класс для генерации элементов управления, отображающих ячеки списка
    class Controls
    {
        //textbox для отображения элемента
        public static Forms.TextBox fillTextBox(object obj, int x, int y)
        {
            Forms.TextBox tb = new Forms.TextBox();
            tb.ReadOnly = true;
            tb.Multiline = true;
            tb.BackColor = System.Drawing.Color.Wheat;
            tb.MaxLength = Wid;
            tb.Height = Hei;
            tb.MaxLength = 5;
            tb.Top = y;
            tb.Left = x;
            tb.Text = obj.ToString();
            return tb;
        }
        public static int Wid { get => 60; }
        public static int Hei { get => 45; }
        public static int Top { get => 7; }
        public static int Lef { get => 45; }
    }
}
