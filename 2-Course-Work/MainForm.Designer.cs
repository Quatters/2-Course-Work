namespace _2_Course_Work
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.StructureTable = new System.Windows.Forms.DataGridView();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameGenrePage = new System.Windows.Forms.TabPage();
            this.NameGenreTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Add_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.Change_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.Load_button = new System.Windows.Forms.Button();
            this.CurStateInfo = new System.Windows.Forms.RichTextBox();
            this.findByYears_button = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.MainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StructureTable)).BeginInit();
            this.NameGenrePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameGenreTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.MainPage);
            this.tabControl.Controls.Add(this.NameGenrePage);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(877, 504);
            this.tabControl.TabIndex = 1;
            this.tabControl.TabStop = false;
            // 
            // MainPage
            // 
            this.MainPage.Controls.Add(this.StructureTable);
            this.MainPage.Location = new System.Drawing.Point(4, 25);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(869, 475);
            this.MainPage.TabIndex = 0;
            this.MainPage.Text = "Структура";
            this.MainPage.UseVisualStyleBackColor = true;
            // 
            // StructureTable
            // 
            this.StructureTable.AllowUserToAddRows = false;
            this.StructureTable.AllowUserToDeleteRows = false;
            this.StructureTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StructureTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StructureTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.StructureTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StructureTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StructureTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookName,
            this.Author,
            this.Genre,
            this.Publisher,
            this.Year});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StructureTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.StructureTable.Location = new System.Drawing.Point(6, 6);
            this.StructureTable.MultiSelect = false;
            this.StructureTable.Name = "StructureTable";
            this.StructureTable.ReadOnly = true;
            this.StructureTable.RowHeadersVisible = false;
            this.StructureTable.RowHeadersWidth = 51;
            this.StructureTable.RowTemplate.Height = 24;
            this.StructureTable.Size = new System.Drawing.Size(857, 463);
            this.StructureTable.TabIndex = 0;
            // 
            // BookName
            // 
            this.BookName.HeaderText = "Название";
            this.BookName.MinimumWidth = 6;
            this.BookName.Name = "BookName";
            this.BookName.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.HeaderText = "Автор";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // Genre
            // 
            this.Genre.HeaderText = "Жанр";
            this.Genre.MinimumWidth = 6;
            this.Genre.Name = "Genre";
            this.Genre.ReadOnly = true;
            // 
            // Publisher
            // 
            this.Publisher.HeaderText = "Издательство";
            this.Publisher.MinimumWidth = 6;
            this.Publisher.Name = "Publisher";
            this.Publisher.ReadOnly = true;
            // 
            // Year
            // 
            this.Year.HeaderText = "Год издания";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            // 
            // NameGenrePage
            // 
            this.NameGenrePage.Controls.Add(this.NameGenreTable);
            this.NameGenrePage.Location = new System.Drawing.Point(4, 25);
            this.NameGenrePage.Name = "NameGenrePage";
            this.NameGenrePage.Padding = new System.Windows.Forms.Padding(3);
            this.NameGenrePage.Size = new System.Drawing.Size(869, 475);
            this.NameGenrePage.TabIndex = 1;
            this.NameGenrePage.Text = "Название/жанр";
            this.NameGenrePage.UseVisualStyleBackColor = true;
            // 
            // NameGenreTable
            // 
            this.NameGenreTable.AllowUserToAddRows = false;
            this.NameGenreTable.AllowUserToDeleteRows = false;
            this.NameGenreTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameGenreTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NameGenreTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.NameGenreTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NameGenreTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NameGenreTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NameGenreTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.NameGenreTable.Location = new System.Drawing.Point(6, 6);
            this.NameGenreTable.MultiSelect = false;
            this.NameGenreTable.Name = "NameGenreTable";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NameGenreTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.NameGenreTable.RowHeadersVisible = false;
            this.NameGenreTable.RowHeadersWidth = 51;
            this.NameGenreTable.RowTemplate.Height = 24;
            this.NameGenreTable.Size = new System.Drawing.Size(857, 547);
            this.NameGenreTable.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Название";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Жанр";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(869, 475);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Справочник Полины";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Add_button
            // 
            this.Add_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_button.Location = new System.Drawing.Point(10, 510);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(114, 32);
            this.Add_button.TabIndex = 2;
            this.Add_button.TabStop = false;
            this.Add_button.Text = "Добавить";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Delete_button.Location = new System.Drawing.Point(250, 510);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(114, 32);
            this.Delete_button.TabIndex = 3;
            this.Delete_button.TabStop = false;
            this.Delete_button.Text = "Удалить";
            this.Delete_button.UseVisualStyleBackColor = true;
            // 
            // Change_button
            // 
            this.Change_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Change_button.Location = new System.Drawing.Point(130, 510);
            this.Change_button.Name = "Change_button";
            this.Change_button.Size = new System.Drawing.Size(114, 32);
            this.Change_button.TabIndex = 4;
            this.Change_button.TabStop = false;
            this.Change_button.Text = "Изменить";
            this.Change_button.UseVisualStyleBackColor = true;
            this.Change_button.Click += new System.EventHandler(this.Change_button_Click);
            // 
            // Save_button
            // 
            this.Save_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Save_button.Location = new System.Drawing.Point(490, 510);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(114, 32);
            this.Save_button.TabIndex = 5;
            this.Save_button.TabStop = false;
            this.Save_button.Text = "Сохранить...";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Load_button
            // 
            this.Load_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Load_button.Location = new System.Drawing.Point(610, 510);
            this.Load_button.Name = "Load_button";
            this.Load_button.Size = new System.Drawing.Size(114, 32);
            this.Load_button.TabIndex = 6;
            this.Load_button.TabStop = false;
            this.Load_button.Text = "Загрузить...";
            this.Load_button.UseVisualStyleBackColor = true;
            this.Load_button.Click += new System.EventHandler(this.Load_button_Click);
            // 
            // CurStateInfo
            // 
            this.CurStateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurStateInfo.BackColor = System.Drawing.SystemColors.Control;
            this.CurStateInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CurStateInfo.Location = new System.Drawing.Point(12, 554);
            this.CurStateInfo.Name = "CurStateInfo";
            this.CurStateInfo.Size = new System.Drawing.Size(855, 31);
            this.CurStateInfo.TabIndex = 7;
            this.CurStateInfo.TabStop = false;
            this.CurStateInfo.Text = "";
            // 
            // findByYears_button
            // 
            this.findByYears_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findByYears_button.Location = new System.Drawing.Point(370, 510);
            this.findByYears_button.Name = "findByYears_button";
            this.findByYears_button.Size = new System.Drawing.Size(114, 32);
            this.findByYears_button.TabIndex = 9;
            this.findByYears_button.TabStop = false;
            this.findByYears_button.Text = "Найти";
            this.findByYears_button.UseVisualStyleBackColor = true;
            this.findByYears_button.Click += new System.EventHandler(this.findByYears_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 597);
            this.Controls.Add(this.findByYears_button);
            this.Controls.Add(this.CurStateInfo);
            this.Controls.Add(this.Load_button);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.Change_button);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Библиотека";
            this.tabControl.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StructureTable)).EndInit();
            this.NameGenrePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameGenreTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage MainPage;
        private System.Windows.Forms.TabPage NameGenrePage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView NameGenreTable;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Change_button;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Button Load_button;
        private System.Windows.Forms.RichTextBox CurStateInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button findByYears_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Publisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        protected internal System.Windows.Forms.DataGridView StructureTable;
        protected internal System.Windows.Forms.TabControl tabControl;
    }
}

