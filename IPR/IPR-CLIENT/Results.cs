﻿using IPR_LIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPR_CLIENT
{
    public partial class Results : Form
    {
        Patient p;
        public Results()
        {
            InitializeComponent();
        }
        public void Start(Patient p) 
        {
            this.p = p;
            label1.Text = p.Vo2Calculator().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}