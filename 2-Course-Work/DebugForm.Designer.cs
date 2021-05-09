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
            this.OAHT_radio = new System.Windows.Forms.RadioButton();
            this.CHT_radio = new System.Windows.Forms.RadioButton();
            this.RBT_radio = new System.Windows.Forms.RadioButton();
            this.AVL_radio = new System.Windows.Forms.RadioButton();
            this.showButton = new System.Windows.Forms.Button();
            this.StructureNames_radio = new System.Windows.Forms.RadioButton();
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
            this.DebugTextBox.Size = new System.Drawing.Size(505, 422);
            this.DebugTextBox.TabIndex = 0;
            this.DebugTextBox.TabStop = false;
            this.DebugTextBox.Text = "";
            // 
            // OAHT_radio
            // 
            this.OAHT_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OAHT_radio.AutoSize = true;
            this.OAHT_radio.Checked = true;
            this.OAHT_radio.Location = new System.Drawing.Point(12, 433);
            this.OAHT_radio.Name = "OAHT_radio";
            this.OAHT_radio.Size = new System.Drawing.Size(208, 21);
            this.OAHT_radio.TabIndex = 1;
            this.OAHT_radio.TabStop = true;
            this.OAHT_radio.Text = "ХТ с открытой адресацией";
            this.OAHT_radio.UseVisualStyleBackColor = true;
            // 
            // CHT_radio
            // 
            this.CHT_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CHT_radio.AutoSize = true;
            this.CHT_radio.Location = new System.Drawing.Point(12, 460);
            this.CHT_radio.Name = "CHT_radio";
            this.CHT_radio.Size = new System.Drawing.Size(134, 21);
            this.CHT_radio.TabIndex = 2;
            this.CHT_radio.Text = "ХТ с цепочками";
            this.CHT_radio.UseVisualStyleBackColor = true;
            // 
            // RBT_radio
            // 
            this.RBT_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RBT_radio.AutoSize = true;
            this.RBT_radio.Location = new System.Drawing.Point(237, 433);
            this.RBT_radio.Name = "RBT_radio";
            this.RBT_radio.Size = new System.Drawing.Size(100, 21);
            this.RBT_radio.TabIndex = 3;
            this.RBT_radio.Text = "КЧ-дерево";
            this.RBT_radio.UseVisualStyleBackColor = true;
            // 
            // AVL_radio
            // 
            this.AVL_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AVL_radio.AutoSize = true;
            this.AVL_radio.Location = new System.Drawing.Point(237, 460);
            this.AVL_radio.Name = "AVL_radio";
            this.AVL_radio.Size = new System.Drawing.Size(109, 21);
            this.AVL_radio.TabIndex = 4;
            this.AVL_radio.Text = "АВЛ-дерево";
            this.AVL_radio.UseVisualStyleBackColor = true;
            // 
            // showButton
            // 
            this.showButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showButton.Location = new System.Drawing.Point(12, 493);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(100, 30);
            this.showButton.TabIndex = 5;
            this.showButton.Text = "Показать";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // StructureNames_radio
            // 
            this.StructureNames_radio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StructureNames_radio.AutoSize = true;
            this.StructureNames_radio.Location = new System.Drawing.Point(365, 433);
            this.StructureNames_radio.Name = "StructureNames_radio";
            this.StructureNames_radio.Size = new System.Drawing.Size(131, 21);
            this.StructureNames_radio.TabIndex = 6;
            this.StructureNames_radio.Text = "StructureNames";
            this.StructureNames_radio.UseVisualStyleBackColor = true;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 535);
            this.Controls.Add(this.StructureNames_radio);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.AVL_radio);
            this.Controls.Add(this.RBT_radio);
            this.Controls.Add(this.CHT_radio);
            this.Controls.Add(this.OAHT_radio);
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
        private System.Windows.Forms.RadioButton OAHT_radio;
        private System.Windows.Forms.RadioButton CHT_radio;
        private System.Windows.Forms.RadioButton RBT_radio;
        private System.Windows.Forms.RadioButton AVL_radio;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.RadioButton StructureNames_radio;
    }
}