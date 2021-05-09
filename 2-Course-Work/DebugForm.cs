using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class DebugForm : Form
    {
        MainForm mainForm;
        public DebugForm()
        {
            InitializeComponent();            
        }
        public void Clear() => DebugTextBox.Clear();
        public void Write(string text) => DebugTextBox.Text += text + "\n\n";
        private void DebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.debugFormShown = false;
        }
        private void DebugForm_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)Owner;
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            Clear();
            if (OAHT_radio.Checked)
            {
                DebugTextBox.Text += "Справочник: название-жанр\nХеш-таблица: открытая адресация, двойное хеширование\n";
                DebugTextBox.Text += $"Заполненность: {mainForm.OAHT.Fullness} ({mainForm.OAHT.Stores}/{mainForm.OAHT.CurrentSize})\n";
                DebugTextBox.Text += $"Список элементов: \n";
                foreach (var item in mainForm.OAHT)
                {
                    DebugTextBox.Text += $"   \"{item.Key}\", \"{item.Value}\", хеш: {mainForm.OAHT.GetIndex(item.Key)}\n";
                }
            }
            else if (RBT_radio.Checked)
            {
                DebugTextBox.Text += "Поиск: в диапазоне годов\n";
                DebugTextBox.Text += "Дерево: красно-черное\n";
                DebugTextBox.Text += "Список элементов: \n";
                foreach (var item in mainForm.RBT)
                {
                    DebugTextBox.Text += $"   \"{item.Key}\" (индексы: ";

                    foreach (var node in item.Value)
                    {
                        DebugTextBox.Text += $"{node.Key.Index}";
                        if (node != item.Value.Last)
                        {
                            DebugTextBox.Text += ", ";
                        }
                        else
                        {
                            DebugTextBox.Text += ")\n";
                        }
                    }
                }
            }
            else if (StructureNames_radio.Checked)
            {
                DebugTextBox.Text += "Используется при удалении из справочников\n";
                DebugTextBox.Text += "Дерево: красно-черное\n";
                DebugTextBox.Text += "Список элементов: \n";
                foreach (var item in mainForm.StructureNames)
                {
                    DebugTextBox.Text += $"   \"{item.Key}\" (индексы: ";

                    foreach (var node in item.Value)
                    {
                        DebugTextBox.Text += $"{node.Key.Index}";
                        if (node != item.Value.Last)
                        {
                            DebugTextBox.Text += ", ";
                        }
                        else
                        {
                            DebugTextBox.Text += ")\n";
                        }
                    }
                }
            }
        }
    }
}
