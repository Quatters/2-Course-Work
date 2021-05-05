namespace _2_Course_Work
{
    partial class FindForm
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
            this.fromYear_numeric = new System.Windows.Forms.NumericUpDown();
            this.toYear_numeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.publisher_textBox = new System.Windows.Forms.TextBox();
            this.byYears_checkbox = new System.Windows.Forms.CheckBox();
            this.byPublisher_checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fromYear_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toYear_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // Find_button
            // 
            this.Find_button.Enabled = false;
            this.Find_button.Location = new System.Drawing.Point(78, 192);
            this.Find_button.Name = "Find_button";
            this.Find_button.Size = new System.Drawing.Size(100, 28);
            this.Find_button.TabIndex = 6;
            this.Find_button.Text = "Найти";
            this.Find_button.UseVisualStyleBackColor = true;
            this.Find_button.Click += new System.EventHandler(this.Find_button_Click);
            // 
            // fromYear_numeric
            // 
            this.fromYear_numeric.Enabled = false;
            this.fromYear_numeric.Location = new System.Drawing.Point(33, 61);
            this.fromYear_numeric.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.fromYear_numeric.Name = "fromYear_numeric";
            this.fromYear_numeric.Size = new System.Drawing.Size(78, 22);
            this.fromYear_numeric.TabIndex = 2;
            // 
            // toYear_numeric
            // 
            this.toYear_numeric.Enabled = false;
            this.toYear_numeric.Location = new System.Drawing.Point(145, 61);
            this.toYear_numeric.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.toYear_numeric.Name = "toYear_numeric";
            this.toYear_numeric.Size = new System.Drawing.Size(78, 22);
            this.toYear_numeric.TabIndex = 3;
            this.toYear_numeric.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(117, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "—";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // publisher_textBox
            // 
            this.publisher_textBox.Enabled = false;
            this.publisher_textBox.Location = new System.Drawing.Point(33, 147);
            this.publisher_textBox.Name = "publisher_textBox";
            this.publisher_textBox.Size = new System.Drawing.Size(190, 22);
            this.publisher_textBox.TabIndex = 5;
            // 
            // byYears_checkbox
            // 
            this.byYears_checkbox.AutoSize = true;
            this.byYears_checkbox.Location = new System.Drawing.Point(22, 26);
            this.byYears_checkbox.Name = "byYears_checkbox";
            this.byYears_checkbox.Size = new System.Drawing.Size(113, 21);
            this.byYears_checkbox.TabIndex = 1;
            this.byYears_checkbox.Text = "Год издания";
            this.byYears_checkbox.UseVisualStyleBackColor = true;
            this.byYears_checkbox.CheckedChanged += new System.EventHandler(this.byYears_checkbox_CheckedChanged);
            // 
            // byPublisher_checkbox
            // 
            this.byPublisher_checkbox.AutoSize = true;
            this.byPublisher_checkbox.Location = new System.Drawing.Point(22, 112);
            this.byPublisher_checkbox.Name = "byPublisher_checkbox";
            this.byPublisher_checkbox.Size = new System.Drawing.Size(122, 21);
            this.byPublisher_checkbox.TabIndex = 4;
            this.byPublisher_checkbox.Text = "Издательство";
            this.byPublisher_checkbox.UseVisualStyleBackColor = true;
            this.byPublisher_checkbox.CheckedChanged += new System.EventHandler(this.byPublisher_checkbox_CheckedChanged);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 232);
            this.Controls.Add(this.byPublisher_checkbox);
            this.Controls.Add(this.byYears_checkbox);
            this.Controls.Add(this.publisher_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toYear_numeric);
            this.Controls.Add(this.fromYear_numeric);
            this.Controls.Add(this.Find_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Найти";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindForm_FormClosing);
            this.Load += new System.EventHandler(this.FindForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fromYear_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toYear_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.NumericUpDown fromYear_numeric;
        protected internal System.Windows.Forms.NumericUpDown toYear_numeric;
        protected internal System.Windows.Forms.TextBox publisher_textBox;
        protected internal System.Windows.Forms.Button Find_button;
        protected internal System.Windows.Forms.CheckBox byYears_checkbox;
        protected internal System.Windows.Forms.CheckBox byPublisher_checkbox;
    }
}