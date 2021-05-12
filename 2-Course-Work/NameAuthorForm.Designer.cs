namespace _2_Course_Work
{
    partial class NameAuthorForm
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
            this.Author_textBox = new System.Windows.Forms.TextBox();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK_button
            // 
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(180, 124);
            this.OK_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(96, 35);
            this.OK_button.TabIndex = 11;
            this.OK_button.TabStop = false;
            this.OK_button.Text = "ОК";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // Cancel_button
            // 
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button.Location = new System.Drawing.Point(283, 124);
            this.Cancel_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(96, 35);
            this.Cancel_button.TabIndex = 10;
            this.Cancel_button.TabStop = false;
            this.Cancel_button.Text = "Отмена";
            this.Cancel_button.UseVisualStyleBackColor = true;
            // 
            // Author_textBox
            // 
            this.Author_textBox.Location = new System.Drawing.Point(139, 72);
            this.Author_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Author_textBox.Name = "Author_textBox";
            this.Author_textBox.Size = new System.Drawing.Size(239, 26);
            this.Author_textBox.TabIndex = 9;
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(139, 24);
            this.Name_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(239, 26);
            this.Name_textBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Автор\r\n";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название";
            // 
            // NameAuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 182);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Author_textBox);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NameAuthorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.Button OK_button;
        protected internal System.Windows.Forms.Button Cancel_button;
        protected internal System.Windows.Forms.TextBox Author_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.TextBox Name_textBox;
    }
}