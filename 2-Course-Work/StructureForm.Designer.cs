namespace _2_Course_Work
{
    partial class StructureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OK_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Publisher_textBox = new System.Windows.Forms.TextBox();
            this.Year_numeric = new System.Windows.Forms.NumericUpDown();
            this.Genre_textBox = new System.Windows.Forms.TextBox();
            this.Author_textBox = new System.Windows.Forms.TextBox();
            this.Name_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Year_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // OK_button
            // 
            this.OK_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(189, 220);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(85, 28);
            this.OK_button.TabIndex = 4;
            this.OK_button.Text = "ОК";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // Cancel_button
            // 
            this.Cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button.Location = new System.Drawing.Point(280, 220);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(85, 28);
            this.Cancel_button.TabIndex = 5;
            this.Cancel_button.Text = "Отмена";
            this.Cancel_button.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 39);
            this.label2.TabIndex = 7;
            this.label2.Text = "Автор";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 39);
            this.label3.TabIndex = 10;
            this.label3.Text = "Жанр";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(23, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 39);
            this.label4.TabIndex = 11;
            this.label4.Text = "Год издания";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 39);
            this.label5.TabIndex = 12;
            this.label5.Text = "Издательство";
            // 
            // Publisher_textBox
            // 
            this.Publisher_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Publisher_textBox.Location = new System.Drawing.Point(148, 142);
            this.Publisher_textBox.Name = "Publisher_textBox";
            this.Publisher_textBox.Size = new System.Drawing.Size(217, 22);
            this.Publisher_textBox.TabIndex = 2;
            // 
            // Year_numeric
            // 
            this.Year_numeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Year_numeric.Location = new System.Drawing.Point(148, 182);
            this.Year_numeric.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.Year_numeric.Name = "Year_numeric";
            this.Year_numeric.Size = new System.Drawing.Size(217, 22);
            this.Year_numeric.TabIndex = 3;
            this.Year_numeric.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // Genre_textBox
            // 
            this.Genre_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Genre_textBox.Location = new System.Drawing.Point(148, 103);
            this.Genre_textBox.Name = "Genre_textBox";
            this.Genre_textBox.ReadOnly = true;
            this.Genre_textBox.Size = new System.Drawing.Size(217, 22);
            this.Genre_textBox.TabIndex = 16;
            this.Genre_textBox.TabStop = false;
            // 
            // Author_textBox
            // 
            this.Author_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Author_textBox.Location = new System.Drawing.Point(148, 64);
            this.Author_textBox.Name = "Author_textBox";
            this.Author_textBox.ReadOnly = true;
            this.Author_textBox.Size = new System.Drawing.Size(217, 22);
            this.Author_textBox.TabIndex = 17;
            this.Author_textBox.TabStop = false;
            // 
            // Name_comboBox
            // 
            this.Name_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Name_comboBox.FormattingEnabled = true;
            this.Name_comboBox.Location = new System.Drawing.Point(148, 25);
            this.Name_comboBox.Name = "Name_comboBox";
            this.Name_comboBox.Size = new System.Drawing.Size(217, 24);
            this.Name_comboBox.TabIndex = 1;
            this.Name_comboBox.SelectedIndexChanged += new System.EventHandler(this.Name_comboBox_SelectedIndexChanged);
            // 
            // StructureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 263);
            this.Controls.Add(this.Name_comboBox);
            this.Controls.Add(this.Author_textBox);
            this.Controls.Add(this.Genre_textBox);
            this.Controls.Add(this.Year_numeric);
            this.Controls.Add(this.Publisher_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StructureForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.Year_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.Button OK_button;
        protected internal System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        protected internal System.Windows.Forms.TextBox Publisher_textBox;
        protected internal System.Windows.Forms.TextBox Genre_textBox;
        protected internal System.Windows.Forms.TextBox Author_textBox;
        protected internal System.Windows.Forms.NumericUpDown Year_numeric;
        protected internal System.Windows.Forms.ComboBox Name_comboBox;
    }
}