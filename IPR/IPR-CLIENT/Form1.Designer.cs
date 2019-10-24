namespace IPR_CLIENT
{
    partial class Form1
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
            this.TB_Naam = new System.Windows.Forms.TextBox();
            this.TB_Gewicht = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Leeftijd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FLP_Gender = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.StartButton = new System.Windows.Forms.Button();
            this.FLP_Gender.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(755, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welkom, Vul de volgende gegevens in om door te gaan met deze Test.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Naam:";
            // 
            // TB_Naam
            // 
            this.TB_Naam.Location = new System.Drawing.Point(12, 49);
            this.TB_Naam.Name = "TB_Naam";
            this.TB_Naam.Size = new System.Drawing.Size(301, 20);
            this.TB_Naam.TabIndex = 2;
            // 
            // TB_Gewicht
            // 
            this.TB_Gewicht.Location = new System.Drawing.Point(12, 130);
            this.TB_Gewicht.Name = "TB_Gewicht";
            this.TB_Gewicht.Size = new System.Drawing.Size(38, 20);
            this.TB_Gewicht.TabIndex = 4;
            this.TB_Gewicht.UseSystemPasswordChar = true;
            this.TB_Gewicht.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gewicht in KG:";
            // 
            // TB_Leeftijd
            // 
            this.TB_Leeftijd.Location = new System.Drawing.Point(12, 166);
            this.TB_Leeftijd.Name = "TB_Leeftijd";
            this.TB_Leeftijd.Size = new System.Drawing.Size(38, 20);
            this.TB_Leeftijd.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Leeftijd";
            // 
            // FLP_Gender
            // 
            this.FLP_Gender.Controls.Add(this.radioButton1);
            this.FLP_Gender.Controls.Add(this.radioButton2);
            this.FLP_Gender.Location = new System.Drawing.Point(12, 85);
            this.FLP_Gender.Name = "FLP_Gender";
            this.FLP_Gender.Size = new System.Drawing.Size(116, 26);
            this.FLP_Gender.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Geslacht:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Man";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(55, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Vrouw";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 193);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "Ga Door";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 227);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FLP_Gender);
            this.Controls.Add(this.TB_Leeftijd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Gewicht);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Naam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FLP_Gender.ResumeLayout(false);
            this.FLP_Gender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Naam;
        private System.Windows.Forms.TextBox TB_Gewicht;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Leeftijd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel FLP_Gender;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button StartButton;
    }
}

