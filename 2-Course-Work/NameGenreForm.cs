﻿using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class NameGenreForm : Form
    {
        public NameGenreForm(string formName)
        {
            InitializeComponent();
            Text = formName;
            AcceptButton = OK_button;
        }

        private void NameGenreForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
