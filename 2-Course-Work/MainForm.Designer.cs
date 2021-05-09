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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDebugFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_button = new System.Windows.Forms.Button();
            this.Change_button = new System.Windows.Forms.Button();
            this.Add_button = new System.Windows.Forms.Button();
            this.Find_button = new System.Windows.Forms.Button();
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
            this.NameAuthorPage = new System.Windows.Forms.TabPage();
            this.NameAuthorTable = new System.Windows.Forms.DataGridView();
            this.CH_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CH_Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.MainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StructureTable)).BeginInit();
            this.NameGenrePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameGenreTable)).BeginInit();
            this.NameAuthorPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameAuthorTable)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 575);
            this.StatusStrip.Margin = new System.Windows.Forms.Padding(6);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(874, 22);
            this.StatusStrip.TabIndex = 10;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(1, 4, 1, 2);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(874, 28);
            this.MenuStrip.TabIndex = 11;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "Новый";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadToolStripMenuItem.Text = "Загрузить...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Сохранить...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDebugFormToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.debugToolStripMenuItem.Text = "Отладка";
            // 
            // openDebugFormToolStripMenuItem
            // 
            this.openDebugFormToolStripMenuItem.Name = "openDebugFormToolStripMenuItem";
            this.openDebugFormToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.openDebugFormToolStripMenuItem.Text = "Открыть отладочное окно";
            this.openDebugFormToolStripMenuItem.Click += new System.EventHandler(this.openDebugFormToolStripMenuItem_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Delete_button.Location = new System.Drawing.Point(370, 530);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(114, 31);
            this.Delete_button.TabIndex = 3;
            this.Delete_button.TabStop = false;
            this.Delete_button.Text = "Удалить";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Change_button
            // 
            this.Change_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Change_button.Location = new System.Drawing.Point(250, 530);
            this.Change_button.Name = "Change_button";
            this.Change_button.Size = new System.Drawing.Size(114, 31);
            this.Change_button.TabIndex = 4;
            this.Change_button.TabStop = false;
            this.Change_button.Text = "Изменить";
            this.Change_button.UseVisualStyleBackColor = true;
            this.Change_button.Click += new System.EventHandler(this.Change_button_Click);
            // 
            // Add_button
            // 
            this.Add_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_button.Location = new System.Drawing.Point(130, 530);
            this.Add_button.Name = "Add_button";
            this.Add_button.Size = new System.Drawing.Size(114, 31);
            this.Add_button.TabIndex = 2;
            this.Add_button.TabStop = false;
            this.Add_button.Text = "Добавить";
            this.Add_button.UseVisualStyleBackColor = true;
            this.Add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // Find_button
            // 
            this.Find_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Find_button.Location = new System.Drawing.Point(10, 530);
            this.Find_button.Name = "Find_button";
            this.Find_button.Size = new System.Drawing.Size(114, 31);
            this.Find_button.TabIndex = 9;
            this.Find_button.TabStop = false;
            this.Find_button.Text = "Найти";
            this.Find_button.UseVisualStyleBackColor = true;
            this.Find_button.Click += new System.EventHandler(this.Find_button_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.MainPage);
            this.tabControl.Controls.Add(this.NameGenrePage);
            this.tabControl.Controls.Add(this.NameAuthorPage);
            this.tabControl.Location = new System.Drawing.Point(0, 30);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(874, 494);
            this.tabControl.TabIndex = 1;
            this.tabControl.TabStop = false;
            // 
            // MainPage
            // 
            this.MainPage.Controls.Add(this.StructureTable);
            this.MainPage.Location = new System.Drawing.Point(4, 25);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(6);
            this.MainPage.Size = new System.Drawing.Size(866, 465);
            this.MainPage.TabIndex = 0;
            this.MainPage.Text = "Структура";
            this.MainPage.UseVisualStyleBackColor = true;
            // 
            // StructureTable
            // 
            this.StructureTable.AllowUserToAddRows = false;
            this.StructureTable.AllowUserToDeleteRows = false;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StructureTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.StructureTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StructureTable.Location = new System.Drawing.Point(6, 6);
            this.StructureTable.MultiSelect = false;
            this.StructureTable.Name = "StructureTable";
            this.StructureTable.ReadOnly = true;
            this.StructureTable.RowHeadersVisible = false;
            this.StructureTable.RowHeadersWidth = 51;
            this.StructureTable.RowTemplate.Height = 24;
            this.StructureTable.Size = new System.Drawing.Size(854, 453);
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
            this.NameGenrePage.Padding = new System.Windows.Forms.Padding(6);
            this.NameGenrePage.Size = new System.Drawing.Size(866, 465);
            this.NameGenrePage.TabIndex = 1;
            this.NameGenrePage.Text = "Название/жанр";
            this.NameGenrePage.UseVisualStyleBackColor = true;
            // 
            // NameGenreTable
            // 
            this.NameGenreTable.AllowUserToAddRows = false;
            this.NameGenreTable.AllowUserToDeleteRows = false;
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
            this.NameGenreTable.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.NameGenreTable.Size = new System.Drawing.Size(854, 453);
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
            // NameAuthorPage
            // 
            this.NameAuthorPage.Controls.Add(this.NameAuthorTable);
            this.NameAuthorPage.Location = new System.Drawing.Point(4, 25);
            this.NameAuthorPage.Name = "NameAuthorPage";
            this.NameAuthorPage.Padding = new System.Windows.Forms.Padding(6);
            this.NameAuthorPage.Size = new System.Drawing.Size(866, 465);
            this.NameAuthorPage.TabIndex = 2;
            this.NameAuthorPage.Text = "Название/автор";
            this.NameAuthorPage.UseVisualStyleBackColor = true;
            // 
            // NameAuthorTable
            // 
            this.NameAuthorTable.AllowUserToAddRows = false;
            this.NameAuthorTable.AllowUserToDeleteRows = false;
            this.NameAuthorTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NameAuthorTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.NameAuthorTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NameAuthorTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NameAuthorTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CH_Name,
            this.CH_Author});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NameAuthorTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.NameAuthorTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameAuthorTable.Location = new System.Drawing.Point(6, 6);
            this.NameAuthorTable.MultiSelect = false;
            this.NameAuthorTable.Name = "NameAuthorTable";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NameAuthorTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.NameAuthorTable.RowHeadersVisible = false;
            this.NameAuthorTable.RowHeadersWidth = 51;
            this.NameAuthorTable.RowTemplate.Height = 24;
            this.NameAuthorTable.Size = new System.Drawing.Size(854, 453);
            this.NameAuthorTable.TabIndex = 2;
            // 
            // CH_Name
            // 
            this.CH_Name.HeaderText = "Название";
            this.CH_Name.MinimumWidth = 6;
            this.CH_Name.Name = "CH_Name";
            this.CH_Name.ReadOnly = true;
            // 
            // CH_Author
            // 
            this.CH_Author.HeaderText = "Автор";
            this.CH_Author.MinimumWidth = 6;
            this.CH_Author.Name = "CH_Author";
            this.CH_Author.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 597);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.Find_button);
            this.Controls.Add(this.Change_button);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Add_button);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Библиотека";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StructureTable)).EndInit();
            this.NameGenrePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameGenreTable)).EndInit();
            this.NameAuthorPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameAuthorTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDebugFormToolStripMenuItem;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Change_button;
        private System.Windows.Forms.Button Add_button;
        private System.Windows.Forms.Button Find_button;
        protected internal System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage MainPage;
        protected internal System.Windows.Forms.DataGridView StructureTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Publisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.TabPage NameGenrePage;
        private System.Windows.Forms.DataGridView NameGenreTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage NameAuthorPage;
        private System.Windows.Forms.DataGridView NameAuthorTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CH_Author;
    }
}

