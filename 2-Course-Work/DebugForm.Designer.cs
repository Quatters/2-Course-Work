namespace _2_Course_Work
{
    partial class DebugForm
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
            this.DebugTextBox = new System.Windows.Forms.RichTextBox();
            this.NameGenreHT_radio = new System.Windows.Forms.RadioButton();
            this.NameAuthorHT_radio = new System.Windows.Forms.RadioButton();
            this.YearTree_radio = new System.Windows.Forms.RadioButton();
            this.PublisherTree_radio = new System.Windows.Forms.RadioButton();
            this.showButton = new System.Windows.Forms.Button();
            this.NameTree_radio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // DebugTextBox
            // 
            this.DebugTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DebugTextBox.Location = new System.Drawing.Point(0, 0);
            this.DebugTextBox.Name = "DebugTextBox";
            this.DebugTextBox.ReadOnly = true;
            this.DebugTextBox.Size = new System.Drawing.Size(505, 404);
            this.DebugTextBox.TabIndex = 0;
            this.DebugTextBox.TabStop = false;
            this.DebugTextBox.Text = "";
            // 
            // NameGenreHT_radio
            // 
            this.NameGenreHT_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NameGenreHT_radio.AutoSize = true;
            this.NameGenreHT_radio.Checked = true;
            this.NameGenreHT_radio.Location = new System.Drawing.Point(12, 416);
            this.NameGenreHT_radio.Name = "NameGenreHT_radio";
            this.NameGenreHT_radio.Size = new System.Drawing.Size(220, 21);
            this.NameGenreHT_radio.TabIndex = 1;
            this.NameGenreHT_radio.TabStop = true;
            this.NameGenreHT_radio.Text = "Хеш-таблица название/жанр";
            this.NameGenreHT_radio.UseVisualStyleBackColor = true;
            // 
            // NameAuthorHT_radio
            // 
            this.NameAuthorHT_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NameAuthorHT_radio.AutoSize = true;
            this.NameAuthorHT_radio.Location = new System.Drawing.Point(12, 443);
            this.NameAuthorHT_radio.Name = "NameAuthorHT_radio";
            this.NameAuthorHT_radio.Size = new System.Drawing.Size(225, 21);
            this.NameAuthorHT_radio.TabIndex = 4;
            this.NameAuthorHT_radio.Text = "Хеш-таблица название/автор";
            this.NameAuthorHT_radio.UseVisualStyleBackColor = true;
            // 
            // YearTree_radio
            // 
            this.YearTree_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.YearTree_radio.AutoSize = true;
            this.YearTree_radio.Location = new System.Drawing.Point(253, 416);
            this.YearTree_radio.Name = "YearTree_radio";
            this.YearTree_radio.Size = new System.Drawing.Size(119, 21);
            this.YearTree_radio.TabIndex = 2;
            this.YearTree_radio.Text = "Дерево годов";
            this.YearTree_radio.UseVisualStyleBackColor = true;
            // 
            // PublisherTree_radio
            // 
            this.PublisherTree_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PublisherTree_radio.AutoSize = true;
            this.PublisherTree_radio.Location = new System.Drawing.Point(253, 443);
            this.PublisherTree_radio.Name = "PublisherTree_radio";
            this.PublisherTree_radio.Size = new System.Drawing.Size(165, 21);
            this.PublisherTree_radio.TabIndex = 5;
            this.PublisherTree_radio.Text = "Дерево издательств";
            this.PublisherTree_radio.UseVisualStyleBackColor = true;
            // 
            // showButton
            // 
            this.showButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showButton.Location = new System.Drawing.Point(12, 519);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(100, 30);
            this.showButton.TabIndex = 0;
            this.showButton.Text = "Показать";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // NameTree_radio
            // 
            this.NameTree_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NameTree_radio.AutoSize = true;
            this.NameTree_radio.Location = new System.Drawing.Point(253, 470);
            this.NameTree_radio.Name = "NameTree_radio";
            this.NameTree_radio.Size = new System.Drawing.Size(145, 21);
            this.NameTree_radio.TabIndex = 3;
            this.NameTree_radio.Text = "Дерево названий";
            this.NameTree_radio.UseVisualStyleBackColor = true;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 561);
            this.Controls.Add(this.NameTree_radio);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.PublisherTree_radio);
            this.Controls.Add(this.YearTree_radio);
            this.Controls.Add(this.NameAuthorHT_radio);
            this.Controls.Add(this.NameGenreHT_radio);
            this.Controls.Add(this.DebugTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebugForm";
            this.Text = "Окно отладки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugForm_FormClosing);
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox DebugTextBox;
        private System.Windows.Forms.RadioButton NameGenreHT_radio;
        private System.Windows.Forms.RadioButton NameAuthorHT_radio;
        private System.Windows.Forms.RadioButton YearTree_radio;
        private System.Windows.Forms.RadioButton PublisherTree_radio;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.RadioButton NameTree_radio;
    }
}