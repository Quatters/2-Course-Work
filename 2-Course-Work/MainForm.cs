using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using DoubleLinkedList;
using OA_Hashtable;
using RB_Tree;

namespace _2_Course_Work
{
    public partial class MainForm : Form
    {
        const string CORRECT_USER_INPUT = "^[a-zA-Zа-яА-Я0-9.,-:;'\"()!? ]*$";
        const int FILE_OUTPUT_SPACE = 32;
        bool nameGenreTableSaved = false;
        OA_Hashtable<string, string> OAHT = new OA_Hashtable<string, string>();
        public MainForm()
        {
            InitializeComponent();
        }
        private void LoadFile(DataGridView grid)
        {            
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Справочник (*.txt)|*.txt";
            openDialog.InitialDirectory = "C:\\Users\\mi\\source\\repos\\2-Course-Work\\saves";
            DialogResult result = openDialog.ShowDialog();
            string line;
            string[] cells;
            if (result == DialogResult.OK)
            {
                grid.Rows.Clear();
                if (grid == NameGenreTable) OAHT.Clear();
                StreamReader reader = new StreamReader(openDialog.FileName);
                while (!reader.EndOfStream)
                {
                    line = CleanString(reader.ReadLine());
                    cells = line.Replace(' ', '#').Replace('_', ' ').Split('#');
                    if (grid == NameGenreTable)
                    {
                        OAHT.Add(cells[0], cells[1]);
                    }
                    grid.Rows.Add(cells);
                }
                reader.Close();
                UpdateInfo("Справочник успешно загружен");
            }
        }
        private void SaveFile(DataGridView grid)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Справочник (*.txt)|*.txt";
            saveDialog.InitialDirectory = "C:\\Users\\mi\\source\\repos\\2-Course-Work\\saves";
            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveDialog.FileName);
                for (int i = 0; i < grid.RowCount; i++)
                {
                    for (int j = 0; j < grid.ColumnCount; j++)
                    {
                        writer.Write($"{grid.Rows[i].Cells[j].Value.ToString().Replace(' ', '_'), -FILE_OUTPUT_SPACE} ");
                    }
                    writer.WriteLine();
                }
                writer.Close();
                UpdateInfo("Справочник успешно сохранен");
            }
        }
        private string CleanString(string dirtyString) => string.Join(" ", dirtyString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        private bool HasIncorrectSymbols(string text) => !System.Text.RegularExpressions.Regex.IsMatch(text, CORRECT_USER_INPUT);
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
                nameGenreTableSaved = false;
                UpdateInfo("Запись успешно изменена");
            }
            
        }
        private void ChangeGenre(string name, string genre, string prevGenre, DataGridViewCell cell)
        {
            if (genre == prevGenre)
            {
                UpdateInfo("Запись не изменена");
            }
            else
            {
                OAHT.GetPair(name).Value = genre;
                cell.Value = genre;
                nameGenreTableSaved = false;
                UpdateInfo("Запись успешно изменена");
            }
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
                    else if (result == DialogResult.OK && (HasIncorrectSymbols(form.Name_textBox.Text) 
                        || HasIncorrectSymbols(form.Genre_textBox.Text)))
                    {
                        MessageBox.Show("Обнаружен недопустимый символ.\nВ полях можно использовать буквы, цифры и знаки препинания.", 
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string prevGenre = NameGenreTable.CurrentCell.OwningRow.Cells[1].Value.ToString();
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
                        else if (result == DialogResult.OK && HasIncorrectSymbols(form.Name_textBox.Text))
                        {
                            MessageBox.Show("Обнаружен недопустимый символ.\nВ полях можно использовать буквы, цифры и знаки препинания.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        else if (result == DialogResult.OK && HasIncorrectSymbols(form.Genre_textBox.Text))
                        {
                            MessageBox.Show("Обнаружен недопустимый символ.\nВ полях можно использовать буквы, цифры и знаки препинания.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = form.ShowDialog();
                        }
                        else
                        {
                            genre = form.Genre_textBox.Text;
                            ChangeGenre(name, genre, prevGenre, cell);
                            success = true;
                        }
                    }
                }
            }
        }
        private void Save_button_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: // структура
                    break;
                case 1: // справочник Влада
                    SaveFile(NameGenreTable);
                    nameGenreTableSaved = true;
                    break;
                case 2: // справочник Полины
                    break;
            }
        }
        private void Load_button_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: // структура
                    break;
                case 1: // справочник Влада
                    if (!nameGenreTableSaved && NameGenreTable.RowCount != 0)
                    {
                        var result = MessageBox.Show("Текущий справочник не сохранен. Продолжить?", "Предупреждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No) return;
                    }
                    LoadFile(NameGenreTable);
                    nameGenreTableSaved = true;
                    break;
                case 2: // справочник Полины
                    break;
            }
        }
    }
}
