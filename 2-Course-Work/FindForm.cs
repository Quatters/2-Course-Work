using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DoubleLinkedList;

namespace _2_Course_Work
{
    public partial class FindForm : Form
    {
        private MainForm mainForm;
        private DataGridViewRow[] oldRows;
        public FindForm()
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
            else if (!byYears_checkbox.Checked && !byPublisher_checkbox.Checked)
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
            else if (!byYears_checkbox.Checked && !byPublisher_checkbox.Checked)
            {
                Find_button.Enabled = false;
            }
        }
        private void Find_button_Click(object sender, EventArgs e)
        {
            DoubleLinkedList<int> foundYears = GetYearIndices((int)fromYear_numeric.Value, (int)toYear_numeric.Value);
            mainForm.tabControl.SelectedIndex = 0;
            mainForm.StructureTable.Rows.Clear();
            if (byYears_checkbox.Checked && !byPublisher_checkbox.Checked) // выбран только год
            {
                foreach (var index in foundYears) mainForm.StructureTable.Rows.Add(oldRows[index.Key]);
            }
            else if (!byYears_checkbox.Checked && byPublisher_checkbox.Checked) // выбран только издатель
            {

            }
            else // выбрано все
            {

            }
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.FindFormByPublisher_checkBox_Checked = byPublisher_checkbox.Checked;
            Properties.Settings.Default.FindFormByYears_checkBox_Checked = byYears_checkbox.Checked;
            Properties.Settings.Default.FindFormFromYear_numeric_Value = fromYear_numeric.Value;
            Properties.Settings.Default.FindFormToYear_numeric_Value = toYear_numeric.Value;
            Properties.Settings.Default.FindFormPublisher_textBox_Text = publisher_textBox.Text;
        }
        private void LoadSettings()
        {
            byPublisher_checkbox.Checked = Properties.Settings.Default.FindFormByPublisher_checkBox_Checked;
            byYears_checkbox.Checked = Properties.Settings.Default.FindFormByYears_checkBox_Checked;
            fromYear_numeric.Value = Properties.Settings.Default.FindFormFromYear_numeric_Value;
            toYear_numeric.Value = Properties.Settings.Default.FindFormToYear_numeric_Value;
            publisher_textBox.Text = Properties.Settings.Default.FindFormPublisher_textBox_Text;
        }
        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.StructureTable.Rows.Clear();
            foreach (var row in oldRows) mainForm.StructureTable.Rows.Add(row);
            SaveSettings();
        }
        private DoubleLinkedList<int> GetYearIndices(int from, int to)
        {
            DoubleLinkedList<int> result = new DoubleLinkedList<int>();
            DoubleLinkedList<int> currentList = new DoubleLinkedList<int>();
            for (int i = from; i <= to; i++)
            {
                currentList = mainForm.RBT.GetValues(i);
                foreach (var year in currentList)
                {
                    result.AddLast(year.Key);
                }
            }
            return result;
        }
        private void FindForm_Load(object sender, EventArgs e)
        {            
            mainForm = (MainForm)Owner;
            oldRows = new DataGridViewRow[mainForm.StructureTable.Rows.Count];
            mainForm.StructureTable.Rows.CopyTo(oldRows, 0);
        }
    }
}
