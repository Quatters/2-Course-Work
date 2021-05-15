using System;
using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class NameFindForm : Form
    {
        private MainForm mainForm;
        private DataGridViewRow[] oldRows;
        private DataGridView table = null;
        public NameFindForm(ref DataGridView table)
        {
            InitializeComponent();
            LoadSettings();
            AcceptButton = Find_button;
            this.table = table;
        }
        private void Find_button_Click(object sender, EventArgs e)
        {
            if (table == mainForm.NameGenreTable)
            {
                var row = mainForm.NameGenreHT.GetValue(name_textBox.Text);
                table.Rows.Clear();
                if (row != null) mainForm.NameGenreTable.Rows.Add(row);
            }
            else if (table == mainForm.NameAuthorTable)
            {
                var row = mainForm.NameAuthorHT.GetValue(name_textBox.Text);
                table.Rows.Clear();
                if (row != null) mainForm.NameAuthorTable.Rows.Add(row);
            }
        }
        private void NameFindForm_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)Owner;
            oldRows = new DataGridViewRow[table.Rows.Count];
            table.Rows.CopyTo(oldRows, 0);
        }
        private void NameFindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            table.Rows.Clear();
            foreach (var row in oldRows) table.Rows.Add(row);
            SaveSettings();
            mainForm.findFormShown = false;
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.NameFindForm_Name_textBox_Text = name_textBox.Text;
        }
        private void LoadSettings()
        {
            name_textBox.Text = Properties.Settings.Default.NameFindForm_Name_textBox_Text;
        }
    }
}
