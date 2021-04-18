using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DoubleLinkedList;
using OA_Hashtable;
using RB_Tree;

namespace _2_Course_Work
{
    public partial class MainForm : Form
    {
        OA_Hashtable<string, string> OAHT = new OA_Hashtable<string, string>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void UpdateInfo(string text) => CurStateInfo.Text = text;
        private void NameGenreAdd(string name, string genre)
        {
            if (OAHT.Contains(name))
            {
                UpdateInfo("Запись не добавлена. Указанная книга уже есть в справочнике");
            }
            else
            {
                OAHT.Add(name, genre);
                NameGenreTable.Rows.Add(name, genre);
                UpdateInfo("Запись успешно добавлена");
            }
        }
        private void ChangeName(string name, string prevName, string genre, DataGridViewCell cell)
        {
            if (name == prevName)
            {
                UpdateInfo("Запись не изменена");
            }
            else
            {
                if (OAHT.Contains(name))
                {
                    UpdateInfo("Запись не изменена. Указанная книга уже есть в справочнике");
                    return;
                }
                OAHT.Delete(prevName);
                OAHT.Add(name, genre);
                cell.Value = name;
                UpdateInfo("Запись успешно изменена");
            }
            
        }
        private void ChangeGenre(string name, string genre, DataGridViewCell cell)
        {
            OAHT.GetPair(name).Value = genre;
            cell.Value = genre;
            UpdateInfo("Запись успешно изменена");
        }
        private void Add_button_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                var form = new NameGenre("Добавить");
                DialogResult result = form.ShowDialog();
                string name, genre;
                bool success = false;
                while (!success)
                {
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.OK && form.Name_textBox.Text == "")
                    {
                        MessageBox.Show("Пожалуйста, заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        result = form.ShowDialog();
                    }
                    else if (result == DialogResult.OK && form.Genre_textBox.Text == "")
                    {
                        MessageBox.Show("Пожалуйста, заполните жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        result = form.ShowDialog();
                    }
                    else
                    {
                        name = form.Name_textBox.Text;
                        genre = form.Genre_textBox.Text;
                        NameGenreAdd(name, genre);
                        success = true;
                    }
                }
            }
        }
        private void Change_button_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                if (NameGenreTable.CurrentCell == null)
                {
                    UpdateInfo("Пожалуйста, выберете ячейку");
                    return;
                }
                var cell = NameGenreTable.CurrentCell;
                string prevName = NameGenreTable.CurrentCell.OwningRow.Cells[0].Value.ToString();
                string name = prevName;
                string genre = NameGenreTable.CurrentCell.OwningRow.Cells[1].Value.ToString();                
                bool nameChange = NameGenreTable.CurrentCell.ColumnIndex == 0;
                var form = new NameGenre("Изменить");
                form.Name_textBox.Text = name;
                form.Genre_textBox.Text = genre;
                if (nameChange)
                {
                    form.Genre_textBox.ReadOnly = true;
                }
                else
                {
                    form.Name_textBox.ReadOnly = true;
                    form.Name_textBox.TabIndex = 2;
                    form.Genre_textBox.TabIndex = 1;
                }
                DialogResult result = form.ShowDialog();                
                bool success = false;
                if (nameChange)
                {
                    while (!success)
                    {
                        if (result == DialogResult.Cancel) return;
                        if (result == DialogResult.OK && form.Name_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else
                        {
                            name = form.Name_textBox.Text;
                            ChangeName(name, prevName, genre, cell);
                            success = true;
                        }
                    }
                }
                else
                {
                    while (!success)
                    {
                        if (result == DialogResult.Cancel) return;
                        if (result == DialogResult.OK && form.Genre_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else
                        {
                            genre = form.Genre_textBox.Text;
                            ChangeGenre(name, genre, cell);
                            success = true;
                        }
                    }
                }
            }
        }
    }
}
