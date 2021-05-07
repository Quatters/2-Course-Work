using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using OAHashtable;
using RBTree;
using ChainHashtable;

namespace _2_Course_Work
{
    public partial class MainForm : Form
    {
        private const string CORRECT_USER_INPUT = "^[a-zA-Zа-яА-Я0-9.,-:;'\"()!? ]*$";
        private const int FILE_OUTPUT_SPACE = 0;
        private bool saved = true;
        protected internal OAHashtable<string, string> OAHT = new OAHashtable<string, string>();
        protected internal RBTree<int, int> RBT = new RBTree<int, int>();
        protected internal ChainHashtable<string, string> CHT = new ChainHashtable<string, string>(50);
        private StructureForm structureForm = new StructureForm();
        public MainForm()
        {
            InitializeComponent();
            structureForm.Owner = this;
        }
        private void LoadFile()
        {            
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Справочник (*.txt)|*.txt";
            openDialog.InitialDirectory = "C:\\Users\\mi\\source\\repos\\2-Course-Work\\saves";
            DialogResult result = openDialog.ShowDialog();
            string line = "";
            string[] cells;
            if (result == DialogResult.OK)
            {
                StreamReader reader;
                try
                {
                    reader = new StreamReader(openDialog.FileName);
                }
                catch (Exception)
                {
                    UpdateInfo("Ошибка при открытии файла");
                    return;
                }
                StructureTable.Rows.Clear();
                NameGenreTable.Rows.Clear();
                NameAuthorTable.Rows.Clear();
                OAHT.Clear();
                CHT.Clear();
                RBT.Clear();
                // добавить очистку авл-дерева
                structureForm.Name_comboBox.Items.Clear();
                try
                {
                    while (!reader.ReadLine().StartsWith("#"));
                    int iter = 0;
                    while (!line.StartsWith("#")) // чтение структуры
                    {
                        line = CleanString(reader.ReadLine());
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');
                        RBT.Add(iter, int.Parse(cells[4]));
                        StructureTable.Rows.Add(cells);
                    } 

                    while (!reader.ReadLine().StartsWith("#"));
                    line = reader.ReadLine();
                    while (!line.StartsWith("#")) // чтение название - жанр
                    {
                        line = CleanString(reader.ReadLine());
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');
                        OAHT.Add(cells[0], cells[1]);
                        NameGenreTable.Rows.Add(cells);
                    } 

                    while (!reader.ReadLine().StartsWith("#"));
                    line = reader.ReadLine();
                    while (!line.StartsWith("#")) // чтение название - автор
                    {
                        line = CleanString(reader.ReadLine());
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');
                        CHT.AddElem(cells[0], cells[1]);
                        if (OAHT.Contains(cells[0])) structureForm.Name_comboBox.Items.Add(cells[0]);
                        NameAuthorTable.Rows.Add(cells);
                    } 

                    reader.Close();
                    UpdateInfo("Справочники успешно загружены");
                }                
                catch (Exception)
                {
                    UpdateInfo("Ошибка при чтении файла. Файл имеет неверный формат");
                    return;
                }
            }
        }
        private void SaveGrid(DataGridView grid, StreamWriter writer)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                for (int j = 0; j < grid.ColumnCount; j++)
                {
                    writer.Write($"{grid.Rows[i].Cells[j].Value.ToString().Replace(' ', '_'), -FILE_OUTPUT_SPACE} ");
                }
                writer.WriteLine();
            }
        }
        private void SaveFile()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Справочник (*.txt)|*.txt";
            saveDialog.InitialDirectory = "C:\\Users\\mi\\source\\repos\\2-Course-Work\\saves";
            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveDialog.FileName);
                writer.WriteLine($"# Общая структура");
                SaveGrid(StructureTable, writer);
                writer.WriteLine($"\n# Название — жанр");
                SaveGrid(NameGenreTable, writer);
                writer.WriteLine($"\n# Название — автор");
                SaveGrid(NameAuthorTable, writer);
                writer.Close();
                saved = true;
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
                saved = false;
                UpdateInfo("Запись успешно добавлена");
            }
        }
        private void NameAuthorAdd(string name, string author)
        {
            if (CHT.Contains(name))
            {
                UpdateInfo("Запись не добавлена. Указанная книга уже есть в справочнике");
            }
            else
            {
                CHT.AddElem(name, author);
                NameAuthorTable.Rows.Add(name, author);
                saved = false;
                UpdateInfo("Запись успешно добавлена");
            }
        }
        private void StructureAdd(string name, string author, string genre, string publisher, int year)
        {
            int index = StructureTable.Rows.Add(name, author, genre, publisher, year);
            RBT.Add(year, index);
            UpdateInfo("Запись успешно добавлена");
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
                saved = false;
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
                saved = false;
                UpdateInfo("Запись успешно изменена");
            }
        }
        private void Add_button_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0) // структура
            {
                structureForm.ResetToDefault();
                structureForm.Text = "Добавить";
                DialogResult result = structureForm.ShowDialog();
                string name, genre, publisher, author;
                int year;
                bool success = false;
                while (!success)
                {
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.OK)
                    {
                        if (structureForm.Name_comboBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = structureForm.ShowDialog();
                        }
                        else if (structureForm.Publisher_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните издательство", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = structureForm.ShowDialog();
                        }
                        else
                        {
                            name = structureForm.Name_comboBox.Text;
                            author = structureForm.Author_textBox.Text;
                            genre = structureForm.Genre_textBox.Text;
                            year = (int)structureForm.Year_numeric.Value;
                            publisher = structureForm.Publisher_textBox.Text;
                            StructureAdd(name, author, genre, publisher, year);
                            success = true;
                        }
                    }
                }
            }
            if (tabControl.SelectedIndex == 1) // справочник Влада
            {
                var form = new NameGenreForm("Добавить");
                DialogResult result = form.ShowDialog();
                string name, genre;
                bool success = false;
                while (!success)
                {
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.OK)
                    {
                        if (form.Name_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else if (form.Genre_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else if (HasIncorrectSymbols(form.Name_textBox.Text) || HasIncorrectSymbols(form.Genre_textBox.Text))
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
                            if (CHT.Contains(name)) structureForm.Name_comboBox.Items.Add(name);
                            success = true;
                        }
                    }
                }
            }
            if (tabControl.SelectedIndex == 2) // справочник Полины
            {
                var form = new NameAuthorForm("Добавить");
                DialogResult result = form.ShowDialog();                
                string name, author;
                bool success = false;
                while (!success)
                {
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.OK)
                    {
                        if (form.Name_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else if (form.Author_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните автора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else if (HasIncorrectSymbols(form.Name_textBox.Text) || HasIncorrectSymbols(form.Author_textBox.Text))
                        {
                            MessageBox.Show("Обнаружен недопустимый символ.\nВ полях можно использовать буквы, цифры и знаки препинания.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = form.ShowDialog();
                        }
                        else
                        {
                            name = form.Name_textBox.Text;
                            author = form.Author_textBox.Text;
                            NameAuthorAdd(name, author);
                            if (OAHT.Contains(name)) structureForm.Name_comboBox.Items.Add(name);
                            success = true;
                        }
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
                var form = new NameGenreForm("Изменить");
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
                            structureForm.Name_comboBox.Items.Remove(prevName);
                            if (CHT.Contains(name)) structureForm.Name_comboBox.Items.Add(name);
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
        private void Save_button_Click(object sender, EventArgs e) => SaveFile();
        private bool WantToSave()
        {
            var result = MessageBox.Show("Текущий справочник не сохранен. Хотите сохранить?", "Предупреждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }
        private bool NotSavedButContinue()
        {
            var result = MessageBox.Show("Текущий справочник не сохранен. Продолжить?", "Предупреждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }
        private void Load_button_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                if (!NotSavedButContinue()) return;
            }
            LoadFile();
            saved = true;            
        }
        private void findByYears_button_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm();
            form.Owner = this;
            form.Show();
            form.Location = new Point(Location.X + Width / 2 - form.Width / 2, Location.Y + Height / 2 - form.Height / 2);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved && WantToSave()) SaveFile();
        }
    }
}
