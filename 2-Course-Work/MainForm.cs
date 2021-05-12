using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using DoubleLinkedList;
using OAHashtable;
using RBTree;
using ChainHashtable;
using BinaryTree;

namespace _2_Course_Work
{
    public partial class MainForm : Form
    {
        private const string CORRECT_USER_INPUT = "^[a-zA-Zа-яА-Я0-9.,-:;'\"()!? ]*$";
        private const int FILE_OUTPUT_SPACE = 36;
        private bool saved = true;
        protected internal bool findFormShown = false;
        protected internal bool debugFormShown = false;
        protected internal OAHashtable<string, DataGridViewRow> NameGenreHT = new OAHashtable<string, DataGridViewRow>();
        protected internal RBTree<int, DataGridViewRow> YearTree = new RBTree<int, DataGridViewRow>();
        protected internal ChainHashtable<string, DataGridViewRow> NameAuthorHT = new ChainHashtable<string, DataGridViewRow>(50);
        protected internal BinaryTree<string, DataGridViewRow> PublisherTree = new BinaryTree<string, DataGridViewRow>();
        /// <summary>
        /// Дерево с названиями и строками в общей структуре, содержащими данное название.
        /// Необходимо для быстрого поиска вхождения названий в структуре при удалении из справочника.
        /// </summary>
        protected internal RBTree<string, DataGridViewRow> NameTree = new RBTree<string, DataGridViewRow>();
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
            int index;
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
                ClearAllStructures();
                try
                {
                    while (!reader.ReadLine().StartsWith("#"));
                    int iter = 0;
                    while (!line.StartsWith("#")) // чтение структуры
                    {
                        line = CleanString(reader.ReadLine());
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');                        
                        index = StructureTable.Rows.Add(cells);
                        YearTree.Add(int.Parse(cells[4]), StructureTable.Rows[index]);
                        PublisherTree.Add(cells[3], StructureTable.Rows[index]);
                        NameTree.Add(cells[0], StructureTable.Rows[index]);
                        iter++;
                    } 

                    while (!reader.ReadLine().StartsWith("#"));
                    line = reader.ReadLine();
                    while (!line.StartsWith("#")) // чтение название - жанр
                    {
                        line = CleanString(line);
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');                        
                        index = NameGenreTable.Rows.Add(cells);
                        NameGenreHT.Add(cells[0], NameGenreTable.Rows[index]);
                        line = reader.ReadLine();
                    } 

                    while (!reader.ReadLine().StartsWith("#"));
                    line = reader.ReadLine();
                    while (!line.StartsWith("#")) // чтение название - автор
                    {
                        line = CleanString(line);
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');                        
                        if (NameGenreHT.Contains(cells[0])) structureForm.Name_comboBox.Items.Add(cells[0]);
                        index = NameAuthorTable.Rows.Add(cells);
                        NameAuthorHT.Add(cells[0], NameAuthorTable.Rows[index]);
                        line = reader.ReadLine();
                    } 

                    reader.Close();
                    saved = true;
                    UpdateInfo("Файл успешно загружен");
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
                writer.WriteLine($"# Конец общей структуры\n\n# Справочник название-жанр");
                SaveGrid(NameGenreTable, writer);
                writer.WriteLine($"# Конец справочника\n\n# Справочник название-автор");
                SaveGrid(NameAuthorTable, writer);
                writer.WriteLine($"# Конец справочника");
                writer.Close();
                saved = true;
                UpdateInfo("Справочник успешно сохранен");
            }
        }
        private string CleanString(string dirtyString) => string.Join(" ", dirtyString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        private bool HasIncorrectSymbols(string text) => !System.Text.RegularExpressions.Regex.IsMatch(text, CORRECT_USER_INPUT);
        private void UpdateInfo(string text) => toolStripStatusLabel.Text = text;
        private void NameGenreAdd(string name, string genre)
        {            
            int index = NameGenreTable.Rows.Add(name, genre);
            NameGenreHT.Add(name, NameGenreTable.Rows[index]);
            saved = false;
            if (NameAuthorHT.Contains(name)) structureForm.Name_comboBox.Items.Add(name);
            UpdateInfo("Запись успешно добавлена");
        }
        private void NameAuthorAdd(string name, string author)
        {
            int index = NameAuthorTable.Rows.Add(name, author);
            NameAuthorHT.Add(name, NameAuthorTable.Rows[index]);            
            saved = false;
            if (NameGenreHT.Contains(name)) structureForm.Name_comboBox.Items.Add(name);
            UpdateInfo("Запись успешно добавлена");
        }
        private void StructureAdd(string name, string author, string genre, string publisher, int year)
        {
            int index = StructureTable.Rows.Add(name, author, genre, publisher, year);
            YearTree.Add(year, StructureTable.Rows[index]);
            NameTree.Add(name, StructureTable.Rows[index]);
            PublisherTree.Add(publisher, StructureTable.Rows[index]);
            saved = false;
            UpdateInfo("Запись добавлена");
        }
        private void NameGenreChange(string name, string genre, DataGridViewRow row)
        {
            string oldName = row.Cells[0].Value.ToString();
            string oldGenre = row.Cells[1].Value.ToString();
            if (name == oldName && genre == oldGenre)
            {
                UpdateInfo("Запись не изменена");
                return;
            }
            if (genre != oldGenre) // изменен жанр
            {
                var rowsToChange = NameTree.GetValues(oldName);
                if (rowsToChange.Size != 0)
                {
                    DialogResult result = MessageBox.Show($"С жанром \"{oldGenre}\" найдены записи в общей структуре ({rowsToChange.Size}), которые" +
                        $" подлежат изменению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
                foreach (var rowToChange in rowsToChange)
                {
                    rowToChange.Key.Cells[2].Value = genre;
                }
                row.Cells[1].Value = genre;
            }
            if (name != oldName) // изменено название
            {
                var rowsToChange = NameTree.GetValues(oldName);
                if (NameAuthorHT.Contains(oldName))
                {
                    DialogResult resultNameAuthorTable = MessageBox.Show($"С названием \"{oldName}\" найдена запись в справочнике Название/автор, которая" +
                            $" подлежит изменению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultNameAuthorTable == DialogResult.No) return;
                    string author = "";
                    foreach (DataGridViewRow naRow in NameAuthorTable.Rows)
                    {
                        if (naRow.Cells[0].Value.ToString() == oldName)
                        {
                            naRow.Cells[0].Value = name;
                            author = naRow.Cells[1].Value.ToString();
                            break;
                        }
                    }
                    NameAuthorHT.Delete(oldName);
                    NameAuthorHT.Add(name, row);
                    if (rowsToChange.Size != 0)
                    {                        
                        DialogResult resultStructure = MessageBox.Show($"С названием \"{oldName}\" найдены записи в общей структуре ({rowsToChange.Size}), которые" +
                            $" подлежат изменению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (resultStructure == DialogResult.No) return;
                        NameTree.RemoveKey(oldName);
                        foreach (var rowToChange in rowsToChange)
                        {
                            rowToChange.Key.Cells[0].Value = name;
                            NameTree.Add(name, rowToChange.Key);
                        }
                    }
                }
                NameGenreHT.Delete(oldName);
                NameGenreHT.Add(name, row);
                row.Cells[0].Value = name;                
            }
            UpdateInfo($"Запись [{oldName}/{oldGenre}] изменена");
        }
        private void NameAuthorChange(string name, string author, DataGridViewRow row)
        {
            string oldName = row.Cells[0].Value.ToString();
            string oldAuthor = row.Cells[1].Value.ToString();
            if (name == oldName && author == oldAuthor)
            {
                UpdateInfo("Запись не изменена");
                return;
            }
            if (author != oldAuthor) // изменен жанр
            {
                var rowsToChange = NameTree.GetValues(oldName);
                if (rowsToChange.Size != 0)
                {
                    DialogResult result = MessageBox.Show($"С автором \"{oldAuthor}\" найдены записи в общей структуре ({rowsToChange.Size}), которые" +
                        $" подлежат изменению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
                foreach (var rowToChange in rowsToChange)
                {
                    rowToChange.Key.Cells[1].Value = author;
                }
                row.Cells[1].Value = author;
            }
            if (name != oldName) // изменено название
            {
                var rowsToChange = NameTree.GetValues(oldName);
                if (NameAuthorHT.Contains(oldName))
                {
                    DialogResult resultNameAuthorTable = MessageBox.Show($"С названием \"{oldName}\" найдена запись в справочнике Название/автор, которая" +
                            $" подлежит изменению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultNameAuthorTable == DialogResult.No) return;
                    string genre = "";
                    foreach (DataGridViewRow ngRow in NameGenreTable.Rows)
                    {
                        if (ngRow.Cells[0].Value.ToString() == oldName)
                        {
                            ngRow.Cells[0].Value = name;
                            genre = ngRow.Cells[1].Value.ToString();
                            break;
                        }
                    }
                    NameGenreHT.Delete(oldName);
                    NameGenreHT.Add(name, row);
                    if (rowsToChange.Size != 0)
                    {
                        DialogResult resultStructure = MessageBox.Show($"С названием \"{oldName}\" найдены записи в общей структуре ({rowsToChange.Size}), которые" +
                            $" подлежат изменению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (resultStructure == DialogResult.No) return;
                        NameTree.RemoveKey(oldName);
                        foreach (var rowToChange in rowsToChange)
                        {
                            rowToChange.Key.Cells[0].Value = name;
                            NameTree.Add(name, rowToChange.Key);
                        }
                    }
                }
                NameAuthorHT.Delete(oldName);
                NameAuthorHT.Add(name, row);
                row.Cells[0].Value = name;
            }
            UpdateInfo($"Запись [{oldName}/{oldAuthor}] изменена");
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
                            MessageBox.Show("Пожалуйста, заполните название.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = structureForm.ShowDialog();
                        }
                        else if (structureForm.Publisher_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните издательство.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else if (tabControl.SelectedIndex == 1) // справочник Влада
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
                            MessageBox.Show("Пожалуйста, заполните название.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else if (form.Genre_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните жанр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            if (NameGenreHT.Contains(name))
                            {
                                MessageBox.Show($"Запись с именем \"{name}\" уже находится в справочнике.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                result = form.ShowDialog();
                                continue;
                            }
                            NameGenreAdd(name, genre);                            
                            success = true;
                        }
                    }
                }
            }
            else  // справочник Полины
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
                            if (NameAuthorHT.Contains(name))
                            {
                                MessageBox.Show($"Запись с именем \"{name}\" уже находится в справочнике.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                result = form.ShowDialog();
                                continue;
                            }
                            NameAuthorAdd(name, author);                            
                            success = true;
                        }
                    }
                }
            }
        }
        private void Change_button_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0) // структура
            {
                if (StructureTable.CurrentCell == null)
                {
                    UpdateInfo("Пожалуйста, выберете ячейку");
                    return;
                }
                var cell = StructureTable.CurrentCell;
                var row = cell.OwningRow;
                int rowIndex = cell.OwningRow.Index;
                string oldName = row.Cells[0].Value.ToString();
                string oldPublisher = row.Cells[3].Value.ToString();
                int oldYear = int.Parse(row.Cells[4].Value.ToString());
                structureForm.ResetToDefault();
                structureForm.Name_comboBox.SelectedItem = oldName;
                structureForm.Publisher_textBox.Text = oldPublisher;
                structureForm.Year_numeric.Value = oldYear;
                structureForm.Text = "Изменить";
                DialogResult result = structureForm.ShowDialog();
                bool success = false;
                while (!success)
                {
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.OK)
                    {
                        if (structureForm.Publisher_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните издательство.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = structureForm.ShowDialog();
                        }
                        else
                        {
                            string name = structureForm.Name_comboBox.Text;
                            string publisher = structureForm.Publisher_textBox.Text;
                            int year = (int)structureForm.Year_numeric.Value;
                            if (name == oldName && publisher == oldPublisher && year == oldYear)
                            {
                                UpdateInfo("Запись не изменена");
                                success = true;
                                continue;
                            }
                            if (name != oldName)
                            {
                                NameTree.GetValues(name).Remove(StructureTable.Rows[rowIndex]);
                                NameTree.Add(name, StructureTable.Rows[rowIndex]);
                                row.Cells[0].Value = name;
                                row.Cells[1].Value = structureForm.Author_textBox.Text;
                                row.Cells[2].Value = structureForm.Genre_textBox.Text;
                            }
                            if (publisher != oldPublisher) 
                            {
                                // добавить для авл-дерева
                                row.Cells[3].Value = structureForm.Publisher_textBox.Text;
                            }
                            if (year != oldYear)
                            {
                                YearTree.GetValues(year).Remove(StructureTable.Rows[rowIndex]);
                                YearTree.Add(year, StructureTable.Rows[rowIndex]);
                                row.Cells[4].Value = structureForm.Year_numeric.Value;
                            }
                            success = true;
                            UpdateInfo("Запись изменена");
                        }
                    }
                }
            }
            else if (tabControl.SelectedIndex == 1) // справочник Влада
            {
                if (NameGenreTable.CurrentCell == null)
                {
                    UpdateInfo("Пожалуйста, выберете ячейку");
                    return;
                }
                var row = NameGenreTable.CurrentCell.OwningRow;
                string prevName = NameGenreTable.CurrentCell.OwningRow.Cells[0].Value.ToString();
                string prevGenre = NameGenreTable.CurrentCell.OwningRow.Cells[1].Value.ToString();
                string name = prevName;
                string genre = prevGenre;
                var form = new NameGenreForm("Изменить");
                form.Name_textBox.Text = name;
                form.Genre_textBox.Text = genre;
                DialogResult result = form.ShowDialog();
                bool success = false;
                while (!success)
                {
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.OK)
                    {
                        if (form.Name_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните название.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else if (form.Genre_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните жанр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            if (prevName != name && NameGenreHT.Contains(name))
                            {
                                MessageBox.Show($"Запись с именем \"{name}\" уже находится в справочнике.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                result = form.ShowDialog();
                                continue;
                            }
                            NameGenreChange(name, genre, row);
                            success = true;
                        }
                    }                    
                }
            }
            else // справочник Полины
            {
                if (NameAuthorTable.CurrentCell == null)
                {
                    UpdateInfo("Пожалуйста, выберете ячейку");
                    return;
                }
                var row = NameAuthorTable.CurrentCell.OwningRow;
                string prevName = NameAuthorTable.CurrentCell.OwningRow.Cells[0].Value.ToString();
                string prevAuthor = NameAuthorTable.CurrentCell.OwningRow.Cells[1].Value.ToString();
                string name = prevName;
                string author = prevAuthor;
                var form = new NameAuthorForm("Изменить");
                form.Name_textBox.Text = name;
                form.Author_textBox.Text = author;
                DialogResult result = form.ShowDialog();
                bool success = false;
                while (!success)
                {
                    if (result == DialogResult.Cancel) return;
                    if (result == DialogResult.OK)
                    {
                        if (form.Name_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните название.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = form.ShowDialog();
                        }
                        else if (form.Author_textBox.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните автора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            if (prevName != name && NameAuthorHT.Contains(name))
                            {
                                MessageBox.Show($"Запись с именем \"{name}\" уже находится в справочнике.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                result = form.ShowDialog();
                                continue;
                            }
                            NameAuthorChange(name, author, row);
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
        }
        private void Find_button_Click(object sender, EventArgs e)
        {
            if (findFormShown) return; 
            FindForm form = new FindForm();
            form.Owner = this;
            form.Show();
            findFormShown = true;
            form.Location = new Point(Location.X + Width / 2 - form.Width / 2, Location.Y + Height / 2 - form.Height / 2);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved && WantToSave()) SaveFile();
        }
        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0) // структура
            {
                if (StructureTable.SelectedCells.Count == 0)
                {
                    UpdateInfo("Пожалуйста, выберете ячейку");
                    return;
                }
                var row = StructureTable.SelectedCells[0].OwningRow;
                var rowCells = StructureTable.SelectedCells[0].OwningRow.Cells;
                PublisherTree.Remove(rowCells[3].Value.ToString(), row);
                YearTree.Remove(int.Parse(rowCells[4].Value.ToString()), row);
                NameTree.Remove(rowCells[0].Value.ToString(), row);
                UpdateInfo($"Запись [{rowCells[0].Value}/{rowCells[1].Value}/{rowCells[2].Value}/{rowCells[3].Value}/{rowCells[4].Value}] удалена");
                StructureTable.Rows.Remove(row);                
                saved = false;
            }
            else if (tabControl.SelectedIndex == 1) // справочник Влада
            {
                if (NameGenreTable.SelectedCells.Count == 0)
                {
                    UpdateInfo("Пожалуйста, выберете ячейку");
                    return;
                }
                string name = NameGenreTable.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
                string genre = NameGenreTable.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
                var rowsToRemove = NameTree.GetValues(name);
                if (rowsToRemove.Size != 0)
                {
                    DialogResult result = MessageBox.Show($"С именем \"{name}\" найдены записи в общей структуре ({rowsToRemove.Size}), которые" +
                        $" подлежат удалению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
                int yearToRemove;
                string publisherToRemove;
                foreach (var rowToRemove in rowsToRemove)
                {
                    yearToRemove = int.Parse(rowToRemove.Key.Cells[4].Value.ToString());
                    publisherToRemove = rowToRemove.Key.Cells[3].Value.ToString();
                    YearTree.Remove(yearToRemove, rowToRemove.Key);
                    PublisherTree.Remove(publisherToRemove, rowToRemove.Key);
                    StructureTable.Rows.Remove(rowToRemove.Key);
                }
                NameGenreHT.Delete(name);
                NameGenreTable.Rows.Remove(NameGenreTable.SelectedCells[0].OwningRow);
                structureForm.Name_comboBox.Items.Remove(name);
                NameTree.RemoveKey(name);
                saved = false;
                UpdateInfo($"Запись [{name}/{genre}] удалена");
            }
            else // справочник Полины
            {
                if (NameAuthorTable.SelectedCells.Count == 0)
                {
                    UpdateInfo("Пожалуйста, выберете ячейку");
                    return;
                }
                string name = NameAuthorTable.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
                string author = NameAuthorTable.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
                var rowsToRemove = NameTree.GetValues(name);
                if (rowsToRemove.Size != 0)
                {
                    DialogResult result = MessageBox.Show($"С именем \"{name}\" найдены записи в общей структуре ({rowsToRemove.Size}), которые" +
                        $" подлежат удалению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
                int yearToRemove;
                string publisherToRemove;
                foreach (var rowToRemove in rowsToRemove)
                {
                    yearToRemove = int.Parse(rowToRemove.Key.Cells[4].Value.ToString());
                    publisherToRemove = rowToRemove.Key.Cells[3].Value.ToString();
                    YearTree.Remove(yearToRemove, rowToRemove.Key);
                    PublisherTree.Remove(publisherToRemove, rowToRemove.Key);
                    StructureTable.Rows.Remove(rowToRemove.Key);
                }
                NameAuthorHT.Delete(name);
                NameAuthorTable.Rows.Remove(NameAuthorTable.SelectedCells[0].OwningRow);
                structureForm.Name_comboBox.Items.Remove(name);
                NameTree.RemoveKey(name);
                saved = false;
                UpdateInfo($"Запись [{name}/{author}] удалена");
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => SaveFile();
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                if (!NotSavedButContinue()) return;
            }
            LoadFile();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                if (!NotSavedButContinue()) return;
            }
            ClearAllStructures();
            UpdateInfo("Новый файл создан");
        }
        private void ClearAllStructures()
        {
            StructureTable.Rows.Clear();
            NameGenreTable.Rows.Clear();
            NameAuthorTable.Rows.Clear();
            NameGenreHT.Clear();
            NameAuthorHT.Clear();
            YearTree.Clear();
            PublisherTree.Clear();
            NameTree.Clear();            
            structureForm.Name_comboBox.Items.Clear();            
        }
        private void openDebugFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (debugFormShown) return;
            DebugForm form = new DebugForm();
            form.Owner = this;
            form.Show();
            debugFormShown = true;
        }
    }
}
