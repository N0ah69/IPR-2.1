namespace IPR_CLIENT
{
    partial class History
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
            this.BackButton = new System.Windows.Forms.Button();
            this.RequestButton = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.DataRequestButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(294, 385);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(78, 28);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RequestButton
            // 
            this.RequestButton.Location = new System.Drawing.Point(294, 39);
            this.RequestButton.Name = "RequestButton";
            this.RequestButton.Size = new System.Drawing.Size(78, 22);
            this.RequestButton.TabIndex = 1;
            this.RequestButton.Text = "Refresh";
            this.RequestButton.UseVisualStyleBackColor = true;
            this.RequestButton.Click += new System.EventHandler(this.RequestButton_Click);
            // 
            // FileListBox
            // 
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.Location = new System.Drawing.Point(42, 39);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(206, 225);
            this.FileListBox.TabIndex = 2;
            // 
            // DataRequestButton
            // 
            this.DataRequestButton.Location = new System.Drawing.Point(294, 88);
            this.DataRequestButton.Name = "DataRequestButton";
            this.DataRequestButton.Size = new System.Drawing.Size(77, 24);
            this.DataRequestButton.TabIndex = 3;
            this.DataRequestButton.Text = "Get Data";
            this.DataRequestButton.UseVisualStyleBackColor = true;
            this.DataRequestButton.Click += new System.EventHandler(this.DataRequestButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filenames";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(538, 43);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 13);
            this.InfoLabel.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataRequestButton);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.RequestButton);
            this.Controls.Add(this.BackButton);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button RequestButton;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.Button DataRequestButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label InfoLabel;
    }
}