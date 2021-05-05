using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class StructureForm : Form
    {
        public StructureForm()
        {
            InitializeComponent();
            AcceptButton = OK_button;
        }
        private void Name_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm mainForm = (MainForm)Owner;
            Genre_textBox.Text = mainForm.OAHT.GetValue(Name_comboBox.Text);
            // добавить автозаполнения поля автора
        }
        protected internal void ResetToDefault()
        {
            Name_comboBox.SelectedItem = null;
            Author_textBox.Text = "";
            Genre_textBox.Text = "";
            Year_numeric.Value = 2000;
            Publisher_textBox.Text = "";
        }
    }
}
