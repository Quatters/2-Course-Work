using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class NameAuthorForm : Form
    {
        public NameAuthorForm(string formName)
        {
            InitializeComponent();
            Text = formName;
            AcceptButton = OK_button;
        }

        private void NameAuthorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
