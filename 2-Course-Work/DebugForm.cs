using System;
using System.Windows.Forms;

namespace _2_Course_Work
{
    public partial class DebugForm : Form
    {
        MainForm mainForm;
        public DebugForm()
        {
            InitializeComponent();
            AcceptButton = showButton;
        }
        public void Clear() => DebugTextBox.Clear();
        private void DebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.debugFormShown = false;
        }
        private void DebugForm_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)Owner;
			ShowNameGenreHT();
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            if (NameGenreHT_radio.Checked)
			{
				ShowNameGenreHT();
			}
			else if (NameAuthorHT_radio.Checked)
			{
				ShowNameAuthorHT();
			}
			else if (YearTree_radio.Checked)
			{
				ShowYearTree();
			}
			else if (PublisherTree_radio.Checked)
			{
				ShowPublisherTree();
			}
			else if (NameTree_radio.Checked)
			{
				ShowNameTree();
			}
		}
		private void ShowNameTree()
		{
			Clear();
			DebugTextBox.Text += "Поиск: по названию\n";
			DebugTextBox.Text += "Дерево: красно-черное\n";
			DebugTextBox.Text += "Список элементов: \n";
			foreach (var item in mainForm.NameTree)
			{
				DebugTextBox.Text += $"   \"{item.Key}\" (индексы: ";

				foreach (var node in item.Value)
				{
					DebugTextBox.Text += $"{node.Key.Index}";
					if (node != item.Value.Last)
					{
						DebugTextBox.Text += ", ";
					}
					else
					{
						DebugTextBox.Text += ")\n";
					}
				}
			}
		}
		private void ShowPublisherTree()
		{
			Clear();
			DebugTextBox.Text += "Поиск: по издателю\n";
			DebugTextBox.Text += "Дерево: бинарное несбалансированное\n";
			DebugTextBox.Text += "Список элементов: \n";
			foreach (var item in mainForm.PublisherTree)
			{
				DebugTextBox.Text += $"   \"{item.Key}\" (индексы: ";
				foreach (var node in item.Values)
				{
					DebugTextBox.Text += $"{node.Key.Index}";
					if (node != item.Values.Last)
					{
						DebugTextBox.Text += ", ";
					}
					else
					{
						DebugTextBox.Text += ")\n";
					}
				}
			}
		}
		private void ShowYearTree()
		{
			Clear();
			DebugTextBox.Text += "Поиск: в диапазоне годов\n";
			DebugTextBox.Text += "Дерево: красно-черное\n";
			DebugTextBox.Text += "Список элементов: \n";
			foreach (var item in mainForm.YearTree)
			{
				DebugTextBox.Text += $"   \"{item.Key}\" (индексы: ";
				foreach (var node in item.Value)
				{
					DebugTextBox.Text += $"{node.Key.Index}";
					if (node != item.Value.Last)
					{
						DebugTextBox.Text += ", ";
					}
					else
					{
						DebugTextBox.Text += ")\n";
					}
				}
			}
		}
		private void ShowNameAuthorHT()
		{
			Clear();
			DebugTextBox.Text += "Справочник: название-автор\nХеш-таблица: метод цепочек\n";
			DebugTextBox.Text += $"Размер: {mainForm.NameAuthorHT.Size}\n";
			DebugTextBox.Text += $"Список элементов: \n";
			foreach (var item in mainForm.NameAuthorHT)
			{
				DebugTextBox.Text += $"   \"{item.Key}\", \"{item.Value.Cells[1].Value}\", хеш: {mainForm.NameAuthorHT.Hash(item.Key)}\n";
			}
		}
		private void ShowNameGenreHT()
		{
            Clear();
			DebugTextBox.Text += "Справочник: название-жанр\nХеш-таблица: открытая адресация, двойное хеширование\n";
			DebugTextBox.Text += $"Заполненность: {mainForm.NameGenreHT.Fullness} ({mainForm.NameGenreHT.Stores}/{mainForm.NameGenreHT.CurrentSize})\n";
			DebugTextBox.Text += $"Список элементов: \n";
			foreach (var item in mainForm.NameGenreHT)
			{
				DebugTextBox.Text += $"   \"{item.Key}\", \"{item.Value.Cells[1].Value}\" (хеш: {mainForm.NameGenreHT.H1(item.Key)}, {mainForm.NameGenreHT.GetIndex(item.Key)})\n";
			}
		}
		private void NameGenreHT_radio_CheckedChanged(object sender, EventArgs e)
		{
			ShowNameGenreHT();
		}
		private void NameAuthorHT_radio_CheckedChanged(object sender, EventArgs e)
		{
			ShowNameAuthorHT();
		}
		private void YearTree_radio_CheckedChanged(object sender, EventArgs e)
		{
			ShowYearTree();
		}
		private void PublisherTree_radio_CheckedChanged(object sender, EventArgs e)
		{
			ShowPublisherTree();
		}
		private void NameTree_radio_CheckedChanged(object sender, EventArgs e)
		{
			ShowNameTree();
		}
	}
}
