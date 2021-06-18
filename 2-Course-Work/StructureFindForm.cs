using System;
using System.Windows.Forms;

using DoubleLinkedList;

namespace _2_Course_Work
{
    public partial class StructureFindForm : Form
    {
        private MainForm mainForm;
        private DataGridViewRow[] oldRows;
        public StructureFindForm()
        {
            InitializeComponent();
            AcceptButton = Find_button;
            LoadSettings();
        }
        private void byYears_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            fromYear_numeric.Enabled = toYear_numeric.Enabled = byYears_checkbox.Checked;
            if (byYears_checkbox.Checked)
            {
                Find_button.Enabled = true;
            }
            else if (!byYears_checkbox.Checked && !byPublisher_checkbox.Checked && !byName_checkBox.Checked)
            {
                Find_button.Enabled = false;
            }
        }
        private void byPublisher_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            publisher_textBox.Enabled = byPublisher_checkbox.Checked;
            if (byPublisher_checkbox.Checked)
            {
                Find_button.Enabled = true;
            }
            else if (!byYears_checkbox.Checked && !byPublisher_checkbox.Checked && !byName_checkBox.Checked)
            {
                Find_button.Enabled = false;
            }
        }
        private void byName_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            name_textBox.Enabled = byName_checkBox.Checked;
            if (byName_checkBox.Checked)
            {
                Find_button.Enabled = true;
            }
            else if (!byYears_checkbox.Checked && !byPublisher_checkbox.Checked && !byName_checkBox.Checked)
            {
                Find_button.Enabled = false;
            }
        }
        private void Find_button_Click(object sender, EventArgs e)
        {
            int? fromYear = null;
            int? toYear = null;
            if (mainForm.YearTree.First != null)
            {
                fromYear = mainForm.YearTree.First.Key;
                toYear = mainForm.YearTree.Last.Key;
            }
            else return;
            if ((int)fromYear_numeric.Value > fromYear) fromYear = (int)fromYear_numeric.Value;
            if ((int)toYear_numeric.Value < toYear) toYear = (int)toYear_numeric.Value;
            DoubleLinkedList<DataGridViewRow> foundYears;
            DoubleLinkedList<DataGridViewRow> foundPublishers;
            DoubleLinkedList<DataGridViewRow> foundNames;
            mainForm.StructureTable.Rows.Clear();
            mainForm.YearTree.Comparisons = 0;
            mainForm.NameTree.Comparisons = 0;
            mainForm.PublisherTree.Comparisons = 0;
            if (byName_checkBox.Checked && byYears_checkbox.Checked && byPublisher_checkbox.Checked && name_textBox.Text != "" && publisher_textBox.Text != "")
            {
                foundYears = GetYearRows(fromYear.Value, toYear.Value);
                foundPublishers = GetPublisherRows(publisher_textBox.Text);
                foundNames = GetNameRows(name_textBox.Text);
                foreach (var row in foundYears)
                {
                    if (foundNames.Contains(row.Key) && foundPublishers.Contains(row.Key))
                    {
                        mainForm.StructureTable.Rows.Add(row.Key);
                    }
                }
            }
            else if (byName_checkBox.Checked && byPublisher_checkbox.Checked && name_textBox.Text != "" && publisher_textBox.Text != "")
            {
                foundPublishers = GetPublisherRows(publisher_textBox.Text);
                foundNames = GetNameRows(name_textBox.Text);
                foreach (var row in foundNames)
                {
                    if (foundPublishers.Contains(row.Key))
                    {
                        mainForm.StructureTable.Rows.Add(row.Key);
                    }
                }
            }
            else if (byName_checkBox.Checked && byYears_checkbox.Checked && name_textBox.Text != "")
            {
                foundYears = GetYearRows(fromYear.Value, toYear.Value);
                foundNames = GetNameRows(name_textBox.Text);
                foreach (var row in foundYears)
                {
                    if (foundNames.Contains(row.Key))
                    {
                        mainForm.StructureTable.Rows.Add(row.Key);
                    }
                }
            }
            else if (byPublisher_checkbox.Checked && byYears_checkbox.Checked && publisher_textBox.Text != "")
            {
                foundYears = GetYearRows(fromYear.Value, toYear.Value);
                foundPublishers = GetPublisherRows(publisher_textBox.Text);
                foreach (var row in foundYears)
                {
                    if (foundPublishers.Contains(row.Key))
                    {
                        mainForm.StructureTable.Rows.Add(row.Key);
                    }
                }
            }
            else if (byName_checkBox.Checked && name_textBox.Text != "")
            {
                foundNames = GetNameRows(name_textBox.Text);
                foreach (var row in foundNames) mainForm.StructureTable.Rows.Add(row.Key);
            }
            else if (byPublisher_checkbox.Checked && publisher_textBox.Text != "")
            {
                foundPublishers = GetPublisherRows(publisher_textBox.Text);
                foreach (var row in foundPublishers) mainForm.StructureTable.Rows.Add(row.Key);
            }
            else if (byYears_checkbox.Checked)
            {
                foundYears = GetYearRows(fromYear.Value, toYear.Value);
                foreach (var row in foundYears) mainForm.StructureTable.Rows.Add(row.Key);
            }
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.StructureFindFormByPublisher_checkBox_Checked = byPublisher_checkbox.Checked;
            Properties.Settings.Default.StructureFindFormByYears_checkBox_Checked = byYears_checkbox.Checked;
            Properties.Settings.Default.StructureFindFormFromYear_numeric_Value = fromYear_numeric.Value;
            Properties.Settings.Default.StructureFindFormToYear_numeric_Value = toYear_numeric.Value;
            Properties.Settings.Default.StructureFindFormPublisher_textBox_Text = publisher_textBox.Text;
            Properties.Settings.Default.StructureFindFormByName_checkBox_Checked = byName_checkBox.Checked;
            Properties.Settings.Default.StructureFindFormName_textBox_Text = name_textBox.Text;
        }
        private void LoadSettings()
        {
            byPublisher_checkbox.Checked = Properties.Settings.Default.StructureFindFormByPublisher_checkBox_Checked;
            byYears_checkbox.Checked = Properties.Settings.Default.StructureFindFormByYears_checkBox_Checked;
            fromYear_numeric.Value = Properties.Settings.Default.StructureFindFormFromYear_numeric_Value;
            toYear_numeric.Value = Properties.Settings.Default.StructureFindFormToYear_numeric_Value;
            publisher_textBox.Text = Properties.Settings.Default.StructureFindFormPublisher_textBox_Text;
            name_textBox.Text = Properties.Settings.Default.StructureFindFormName_textBox_Text;
            byName_checkBox.Checked = Properties.Settings.Default.StructureFindFormByName_checkBox_Checked;
        }
        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.StructureTable.Rows.Clear();
            foreach (var row in oldRows) mainForm.StructureTable.Rows.Add(row);
            SaveSettings();
            mainForm.findFormShown = false;
        }
        private DoubleLinkedList<DataGridViewRow> GetYearRows(int from, int to)
        {
            DoubleLinkedList<DataGridViewRow> result = new DoubleLinkedList<DataGridViewRow>();
            DoubleLinkedList<DataGridViewRow> currentList;
            for (int i = from; i <= to; i++)
            {
                currentList = mainForm.YearTree.GetValues(i);
                foreach (var year in currentList)
                {
                    result.AddLast(year.Key);
                }
            }
            return result;
        }
        private DoubleLinkedList<DataGridViewRow> GetPublisherRows(string publisher) => mainForm.PublisherTree.GetValues(publisher);
        private DoubleLinkedList<DataGridViewRow> GetNameRows(string name) => mainForm.NameTree.GetValues(name);
        private void FindForm_Load(object sender, EventArgs e)
        {            
            mainForm = (MainForm)Owner;
            oldRows = new DataGridViewRow[mainForm.StructureTable.Rows.Count];
            mainForm.StructureTable.Rows.CopyTo(oldRows, 0);
        }        
    }
}
