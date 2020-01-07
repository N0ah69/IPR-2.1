using IPR_LIB;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Windows.Forms;

namespace IPR_CLIENT
{
    public partial class Results : Form
    {
        Patient p;
        PatientInfo pi;

        public Results(Patient p)
        {
            this.p = p;
            InitializeComponent();
            Score.Text = p.Vo2Calculator().ToString();
            pi = new PatientInfo(p.Name, p.Age, p.Weight, p.Gender, p.Vo2Calculator(), DateTime.Now.ToString());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClientConnectionHelp CCH = new ClientConnectionHelp();
            CCH.LoopConnect();
            CCH.SendMesage("save!!!" + JsonConvert.SerializeObject(pi));
            Thread.Sleep(2000);
            this.Hide();
        }
    }
}
