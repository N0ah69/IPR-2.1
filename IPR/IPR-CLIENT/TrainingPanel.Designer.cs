namespace IPR_CLIENT
{
    partial class TrainingPanel
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
            this.B_start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TestStatLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.C_Data = new LiveCharts.WinForms.CartesianChart();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HR = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.TB_Bike = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.Label_Resistance = new System.Windows.Forms.Label();
            this.b_results = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "voer de laatste vijf cijfers van de fiets in:";
            // 
            // B_start
            // 
            this.B_start.Location = new System.Drawing.Point(11, 65);
            this.B_start.Name = "B_start";
            this.B_start.Size = new System.Drawing.Size(75, 23);
            this.B_start.TabIndex = 2;
            this.B_start.Text = "start";
            this.B_start.UseVisualStyleBackColor = true;
            this.B_start.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_Resistance);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TestStatLabel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.C_Data);
            this.groupBox1.Controls.Add(this.TimeLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.StatusLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.HR);
            this.groupBox1.Controls.Add(this.speed);
            this.groupBox1.Location = new System.Drawing.Point(221, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 547);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TestData";
            // 
            // TestStatLabel
            // 
            this.TestStatLabel.AutoSize = true;
            this.TestStatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestStatLabel.Location = new System.Drawing.Point(459, 53);
            this.TestStatLabel.Name = "TestStatLabel";
            this.TestStatLabel.Size = new System.Drawing.Size(233, 37);
            this.TestStatLabel.TabIndex = 11;
            this.TestStatLabel.Text = "Waiting to start";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(462, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Status:";
            // 
            // C_Data
            // 
            this.C_Data.Location = new System.Drawing.Point(6, 218);
            this.C_Data.Name = "C_Data";
            this.C_Data.Size = new System.Drawing.Size(686, 329);
            this.C_Data.TabIndex = 9;
            this.C_Data.Text = "cartesianChart1";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(309, 53);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(150, 55);
            this.TimeLabel.TabIndex = 8;
            this.TimeLabel.Text = "00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(309, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Time:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(16, 127);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(647, 124);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Begin met fietsen. Probeer de RPM op 60 te houden,\r\n want het word zwaarder!\r\n\r\n\r" +
    "\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hartslag:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "RPM:";
            // 
            // HR
            // 
            this.HR.AutoSize = true;
            this.HR.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HR.Location = new System.Drawing.Point(203, 53);
            this.HR.Name = "HR";
            this.HR.Size = new System.Drawing.Size(100, 37);
            this.HR.TabIndex = 1;
            this.HR.Text = "NULL";
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speed.Location = new System.Drawing.Point(203, 16);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(100, 37);
            this.speed.TabIndex = 0;
            this.speed.Text = "NULL";
            // 
            // TB_Bike
            // 
            this.TB_Bike.Location = new System.Drawing.Point(13, 39);
            this.TB_Bike.Name = "TB_Bike";
            this.TB_Bike.Size = new System.Drawing.Size(73, 20);
            this.TB_Bike.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "Weerstand:";
            // 
            // Label_Resistance
            // 
            this.Label_Resistance.AutoSize = true;
            this.Label_Resistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Resistance.Location = new System.Drawing.Point(203, 90);
            this.Label_Resistance.Name = "Label_Resistance";
            this.Label_Resistance.Size = new System.Drawing.Size(100, 37);
            this.Label_Resistance.TabIndex = 13;
            this.Label_Resistance.Text = "NULL";
            // 
            // b_results
            // 
            this.b_results.Location = new System.Drawing.Point(68, 468);
            this.b_results.Name = "b_results";
            this.b_results.Size = new System.Drawing.Size(75, 23);
            this.b_results.TabIndex = 5;
            this.b_results.Text = "Results";
            this.b_results.UseVisualStyleBackColor = true;
            this.b_results.Click += new System.EventHandler(this.B_results_Click);
            // 
            // TrainingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 571);
            this.Controls.Add(this.b_results);
            this.Controls.Add(this.TB_Bike);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_start);
            this.Controls.Add(this.label1);
            this.Name = "TrainingPanel";
            this.Text = "TrainingPanel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_start;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label HR;
        private System.Windows.Forms.Label speed;
        private System.Windows.Forms.TextBox TB_Bike;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label StatusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private LiveCharts.WinForms.CartesianChart C_Data;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TestStatLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Label_Resistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_results;
    }
}