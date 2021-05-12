﻿using System;
using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class StructureForm : Form
    {
        public StructureForm()
        {
            InitializeComponent();
            AcceptButton = OK_button;
            CancelButton = Cancel_button;
        }
        private void Name_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm mainForm = (MainForm)Owner;
            Genre_textBox.Text = mainForm.NameGenreHT.GetValue(Name_comboBox.Text).Cells[1].Value.ToString();
            Author_textBox.Text = mainForm.NameAuthorHT.GetValue(Name_comboBox.Text).Cells[1].Value.ToString();
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
