namespace _2_Course_Work
{
    partial class NameFindForm
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
            this.Find_button = new System.Windows.Forms.Button();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.Name_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Find_button
            // 
            this.Find_button.Location = new System.Drawing.Point(195, 57);
            this.Find_button.Name = "Find_button";
            this.Find_button.Size = new System.Drawing.Size(100, 28);
            this.Find_button.TabIndex = 7;
            this.Find_button.Text = "Найти";
            this.Find_button.UseVisualStyleBackColor = true;
            this.Find_button.Click += new System.EventHandler(this.Find_button_Click);
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(105, 21);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(190, 22);
            this.name_textBox.TabIndex = 0;
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Location = new System.Drawing.Point(18, 22);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(72, 17);
            this.Name_label.TabIndex = 10;
            this.Name_label.Text = "Название";
            // 
            // NameFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 99);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.Find_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NameFindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Найти";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NameFindForm_FormClosing);
            this.Load += new System.EventHandler(this.NameFindForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.Button Find_button;
        protected internal System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label Name_label;
    }
}