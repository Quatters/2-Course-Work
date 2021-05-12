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
            CancelButton = Cancel_button;
        }
    }
}
