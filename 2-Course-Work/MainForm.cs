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

namespace _2_Course_Work
{
    public partial class MainForm : Form
    {
        private const string CORRECT_USER_INPUT = "^[a-zA-Zа-яА-Я0-9.,-:;'\"()!? ]*$";
        private const int FILE_OUTPUT_SPACE = 36;
        private bool saved = true;
        protected internal bool findFormShown = false;
        protected internal bool debugFormShown = false;
        protected internal OAHashtable<string, string> OAHT = new OAHashtable<string, string>();
        protected internal RBTree<int, DataGridViewRow> RBT = new RBTree<int, DataGridViewRow>();
        protected internal ChainHashtable<string, string> CHT = new ChainHashtable<string, string>(50);
        /// <summary>
        /// Дерево с названиями и строками в общей структуре, содержащими данное название.
        /// Необходимо для быстрого поиска вхождения названий в структуре при удалении из справочника.
        /// </summary>
        protected internal RBTree<string, DataGridViewRow> StructureNames = new RBTree<string, DataGridViewRow>();
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
                        RBT.Add(int.Parse(cells[4]), StructureTable.Rows[index]);
                        StructureNames.Add(cells[0], StructureTable.Rows[index]);
                        iter++;
                    } 

                    while (!reader.ReadLine().StartsWith("#"));
                    line = reader.ReadLine();
                    while (!line.StartsWith("#")) // чтение название - жанр
                    {
                        line = CleanString(line);
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');
                        OAHT.Add(cells[0], cells[1]);
                        NameGenreTable.Rows.Add(cells);
                        line = reader.ReadLine();
                    } 

                    while (!reader.ReadLine().StartsWith("#"));
                    line = reader.ReadLine();
                    while (!line.StartsWith("#")) // чтение название - автор
                    {
                        line = CleanString(line);
                        if (line.StartsWith("#")) continue;
                        cells = line.Replace(' ', '%').Replace('_', ' ').Split('%');
                        CHT.AddElem(cells[0], cells[1]);
                        if (OAHT.Contains(cells[0])) structureForm.Name_comboBox.Items.Add(cells[0]);
                        NameAuthorTable.Rows.Add(cells);
                        line = reader.ReadLine();
                    } 

                    reader.Close();
                    saved = true;
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
            RBT.Add(year, StructureTable.Rows[index]);
            StructureNames.Add(name, StructureTable.Rows[index]);
            // добавить добавление в авл-дерево
            saved = false;
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
                            MessageBox.Show("Пожалуйста, заполните издательство", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = structureForm.ShowDialog();
                        }
                        else
                        {
                            string name = structureForm.Name_comboBox.Text;
                            string publisher = structureForm.Publisher_textBox.Text;
                            int year = (int)structureForm.Year_numeric.Value;
                            if (name != oldName)
                            {
                                StructureNames.GetValues(name).Remove(StructureTable.Rows[rowIndex]);
                                StructureNames.Add(name, StructureTable.Rows[rowIndex]);
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
                                RBT.GetValues(year).Remove(StructureTable.Rows[rowIndex]);
                                RBT.Add(year, StructureTable.Rows[rowIndex]);
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
                var row = StructureTable.SelectedCells[0].OwningRow.Cells;
                UpdateInfo($"Запись [{row[0].Value}/{row[1].Value}/{row[2].Value}/{row[3].Value}/{row[4].Value}] удалена");
                StructureTable.Rows.Remove(StructureTable.SelectedCells[0].OwningRow);
                RBT.Remove(int.Parse(row[4].Value.ToString()));
                // добавить удаление из авл-дерева
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
                var rowsToRemove = StructureNames.GetValues(name);
                if (rowsToRemove.Size != 0)
                {
                    DialogResult result = MessageBox.Show($"С именем \"{name}\" найдены записи в общей структуре ({rowsToRemove.Size}), которые" +
                        $" подлежат удалению. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
                int yearToRemove;
                foreach (var rowToRemove in rowsToRemove)
                {
                    yearToRemove = int.Parse(rowToRemove.Key.Cells[4].Value.ToString());
                    RBT.GetValues(yearToRemove).Remove(rowToRemove.Key);
                    if (RBT.GetValues(yearToRemove).Size == 0) RBT.Remove(yearToRemove);
                    StructureTable.Rows.Remove(rowToRemove.Key);
                }
                OAHT.Delete(name);
                NameGenreTable.Rows.Remove(NameGenreTable.SelectedCells[0].OwningRow);
                structureForm.Name_comboBox.Items.Remove(name);
                StructureNames.Remove(name);
                saved = false;
                UpdateInfo($"Запись [{name}/{genre}] удалена");
            }
            else // справочник Полины
            {

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
            OAHT.Clear();
            RBT.Clear();
            CHT.Clear();
            StructureNames.Clear();
            structureForm.Name_comboBox.Items.Clear();
            // добавить очистку авл-дерева
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
