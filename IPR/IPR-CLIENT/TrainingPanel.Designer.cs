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
            this.CB_Bikes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.p = new System.Windows.Forms.Label();
            this.ap = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_Bikes
            // 
            this.CB_Bikes.FormattingEnabled = true;
            this.CB_Bikes.Location = new System.Drawing.Point(12, 38);
            this.CB_Bikes.Name = "CB_Bikes";
            this.CB_Bikes.Size = new System.Drawing.Size(170, 21);
            this.CB_Bikes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select A Bike:";
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
            this.groupBox1.Controls.Add(this.p);
            this.groupBox1.Controls.Add(this.ap);
            this.groupBox1.Controls.Add(this.distance);
            this.groupBox1.Controls.Add(this.speed);
            this.groupBox1.Location = new System.Drawing.Point(221, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 426);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TestData";
            // 
            // p
            // 
            this.p.AutoSize = true;
            this.p.Location = new System.Drawing.Point(140, 99);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(35, 13);
            this.p.TabIndex = 3;
            this.p.Text = "NULL";
            // 
            // ap
            // 
            this.ap.AutoSize = true;
            this.ap.Location = new System.Drawing.Point(140, 75);
            this.ap.Name = "ap";
            this.ap.Size = new System.Drawing.Size(35, 13);
            this.ap.TabIndex = 2;
            this.ap.Text = "NULL";
            // 
            // distance
            // 
            this.distance.AutoSize = true;
            this.distance.Location = new System.Drawing.Point(140, 53);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(35, 13);
            this.distance.TabIndex = 1;
            this.distance.Text = "NULL";
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Location = new System.Drawing.Point(140, 26);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(35, 13);
            this.speed.TabIndex = 0;
            this.speed.Text = "NULL";
            // 
            // TrainingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Bikes);
            this.Name = "TrainingPanel";
            this.Text = "TrainingPanel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Bikes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_start;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label p;
        private System.Windows.Forms.Label ap;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Label speed;
    }
}