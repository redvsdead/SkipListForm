﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//задача 6: реализовать библиотеку классов для списка с пропусками
//серия примеров: на форме организуется три списка -- чисел, строк и каталог цветочного магазина (класс Flower,
//включающий вид и цвет цветка)

namespace SkipListForm
{

    public partial class Form1 : Form
    {
        N6_ClassLib.SkipLibrary.SkipList<int> IntList = new N6_ClassLib.SkipLibrary.LinkedList<int>();
        N6_ClassLib.SkipLibrary.SkipList<string> StrList = new N6_ClassLib.SkipLibrary.LinkedList<string>();
        N6_ClassLib.SkipLibrary.SkipList<Flower> FlowerList = new N6_ClassLib.SkipLibrary.LinkedList<Flower>();


        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
            linkedRadio.Checked = true;
            actionIntButton.Enabled = true;
            actionStrButton.Enabled = false;
            actionFlwrButton.Enabled = false;
        }

        private void listViewBxox_Enter(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void actionIntButton_Click(object sender, EventArgs e)
        {
            if (N6_ClassLib.SkipLibrary.ListUtils.CheckForAll<int>(IntList,
                delegate (int num)
                {
                    return num < 0;
                }))
            {
                MessageBox.Show("All numbers are negative");
            }
            else
            {
                MessageBox.Show("Not all numbers are negative");
            }
        }

        private void actionStrButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            N6_ClassLib.SkipLibrary.ListUtils.ForEach<string>(StrList,
                delegate (string s)
                {
                    if (s.Length == 3)
                        ++count;
                });
            MessageBox.Show("There are " + count.ToString() + " 3-letter words");
        }

        private void actionFlwrButton_Click(object sender, EventArgs e)
        {
            IList<Flower> flowers = N6_ClassLib.SkipLibrary.ListUtils.FindAll<Flower>(FlowerList, delegate (Flower flw)
            {
                return flw.colour != "white";
            },
                delegate
                {
                    if (arrayRadio.Checked)
                        return new N6_ClassLib.SkipLibrary.ArrayList<Flower>();
                    return new N6_ClassLib.SkipLibrary.LinkedList<Flower>();
                });
            //заменяем текущий список цветов на удовлетворяющий предикату
            FlowerList = (N6_ClassLib.SkipLibrary.SkipList<Flower>)flowers;
            if (immutableRadio.Checked)
            {
                FlowerList = new N6_ClassLib.SkipLibrary.ImmutableList<Flower>(FlowerList);
            }
            FlowerList.Display(ref listView);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (typeTab.SelectedTab.Text)
                {
                    case "int":
                        int n;
                        if (!int.TryParse(intBox.Text, out n))
                            MessageBox.Show("Warning: wrong number", "ERROR");
                        else
                        {
                            IntList.Add(n);
                            IntList.Display(ref listView);
                        }
                        break;
                    case "string":
                        StrList.Add(stringBox.Text);
                        StrList.Display(ref listView);
                        break;
                    case "flower":
                        try
                        {
                            FlowerList.Add(new Flower(typeBox.Text, colourBox.Text));
                            FlowerList.Display(ref listView);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "ERROR");
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (typeTab.SelectedTab.Text)
                {
                    case "int":
                        int n;
                        if (!int.TryParse(intBox.Text, out n))
                            MessageBox.Show("Warning: wrong number", "ERROR");
                        else
                        {
                            IntList.Remove(n);
                            IntList.Display(ref listView);
                        }
                        break;
                    case "string":
                        StrList.Remove(stringBox.Text);
                        StrList.Display(ref listView);
                        break;
                    case "Flower":
                        string type, colour;
                        type = typeBox.Text;
                        colour = colourBox.Text;
                        FlowerList.Remove(new Flower(type, colour));
                        FlowerList.Display(ref listView);

                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (typeTab.SelectedTab.Text)
                {
                    case "int":
                        int n;
                        if (!int.TryParse(intBox.Text, out n))
                            MessageBox.Show("Warning: wrong number", "ERROR");
                        else
                        {
                            if (IntList.Contains(n))
                                MessageBox.Show("The list contains such number");
                            else
                                MessageBox.Show("There is no such number");
                        }
                        break;
                    case "string":
                        if (StrList.Contains(stringBox.Text))
                            MessageBox.Show("The List contains such string");
                        else
                            MessageBox.Show("There is no such string");
                        break;
                    case "Flower":
                        string type, colour;
                        type = typeBox.Text;
                        colour = colourBox.Text;
                        if (FlowerList.Contains(new Flower(type, colour)))
                            MessageBox.Show("The list contains such flower");
                        else
                            MessageBox.Show("There is no such flower");
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка");
            }
        }

        private void immutableRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (immutableRadio.Checked)
            {
                IntList = new N6_ClassLib.SkipLibrary.ImmutableList<int>(IntList);
                StrList = new N6_ClassLib.SkipLibrary.ImmutableList<string>(StrList);
                FlowerList = new N6_ClassLib.SkipLibrary.ImmutableList<Flower>(FlowerList);
            }
        }

        private void arrayRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (arrayRadio.Checked)
            {
                IntList = new N6_ClassLib.SkipLibrary.ArrayList<int>();
                StrList = new N6_ClassLib.SkipLibrary.ArrayList<string>();
                FlowerList = new N6_ClassLib.SkipLibrary.ArrayList<Flower>();
                listView.Controls.Clear();
            }
        }

        private void linkedRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (linkedRadio.Checked)
            {
                IntList = new N6_ClassLib.SkipLibrary.LinkedList<int>();
                StrList = new N6_ClassLib.SkipLibrary.LinkedList<string>();
                FlowerList = new N6_ClassLib.SkipLibrary.LinkedList<Flower>();
                listView.Controls.Clear();
            }
        }

        private void typeTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            //immutable по умолчанию оборачивает linkedlist, потому что он занимает меньше памяти
            if (immutableRadio.Checked)
            {
                linkedRadio.Checked = true;
                IntList = new N6_ClassLib.SkipLibrary.LinkedList<int>();
                StrList = new N6_ClassLib.SkipLibrary.LinkedList<string>();
                FlowerList = new N6_ClassLib.SkipLibrary.LinkedList<Flower>();
            }
            //иначе очищаем списки, чтобы не приходилось каждый элемент вручную clear'ом удалять
            else
            {
                IntList.Clear();
                StrList.Clear();
                FlowerList.Clear();
            }
            switch (typeTab.SelectedTab.Text)
            {
                case "int":
                    actionIntButton.Enabled = true;
                    actionStrButton.Enabled = false;
                    actionFlwrButton.Enabled = false;
                    break;
                case "string":
                    actionStrButton.Enabled = true;
                    actionIntButton.Enabled = false;
                    actionFlwrButton.Enabled = false;
                    break;
                case "flower":
                    actionFlwrButton.Enabled = true;
                    actionIntButton.Enabled = false;
                    actionStrButton.Enabled = false;
                    break;
            }
        }
    }
}
