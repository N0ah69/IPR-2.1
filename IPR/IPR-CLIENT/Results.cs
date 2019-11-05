using IPR_LIB;
using System;
using System.Windows.Forms;

namespace IPR_CLIENT
{
    public partial class Results : Form
    {
        Patient p;
        public Results(Patient p)
        {
            this.p = p;
            InitializeComponent();
            Score.Text = p.Vo2Calculator().ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClientConnectionHelp CCH = new ClientConnectionHelp();
            CCH.LoopConnect();
            CCH.SendMesage("save!!!" + p);
            this.Hide();
        }
    }
}
