namespace _2_Course_Work
{
    partial class NameGenre
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.Genre_textBox = new System.Windows.Forms.TextBox();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.OK_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Жанр";
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(130, 22);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(213, 22);
            this.Name_textBox.TabIndex = 1;
            // 
            // Genre_textBox
            // 
            this.Genre_textBox.Location = new System.Drawing.Point(130, 61);
            this.Genre_textBox.Name = "Genre_textBox";
            this.Genre_textBox.Size = new System.Drawing.Size(213, 22);
            this.Genre_textBox.TabIndex = 2;
            // 
            // Cancel_button
            // 
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button.Location = new System.Drawing.Point(258, 102);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(85, 28);
            this.Cancel_button.TabIndex = 4;
            this.Cancel_button.TabStop = false;
            this.Cancel_button.Text = "Отмена";
            this.Cancel_button.UseVisualStyleBackColor = true;
            // 
            // OK_button
            // 
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(167, 102);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(85, 28);
            this.OK_button.TabIndex = 5;
            this.OK_button.TabStop = false;
            this.OK_button.Text = "ОК";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // NameGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 142);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Genre_textBox);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NameGenre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Button OK_button;
        protected internal System.Windows.Forms.Button Cancel_button;
        protected internal System.Windows.Forms.TextBox Name_textBox;
        protected internal System.Windows.Forms.TextBox Genre_textBox;
    }
}