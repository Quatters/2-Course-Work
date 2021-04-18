using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class NameGenre : Form
    {
        public NameGenre(string formName)
        {
            InitializeComponent();
            Text = formName;
            AcceptButton = OK_button;
        }
    }
}
