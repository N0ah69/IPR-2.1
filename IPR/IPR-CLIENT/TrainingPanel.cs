using IPR_LIB;
using System;
using System.Threading;
using System.Windows.Forms;


namespace IPR_CLIENT
{
    public partial class TrainingPanel : Form
    {
        (int, int) a;
        BDataHandler e = new BDataHandler();
        public TrainingPanel()
        {
            e.StartConnection();
            e.setUpBikeConection("");
            InitializeComponent();
            CB_Bikes.DataSource = e.Devices;
        }
        private void doWork()
        {
            while (true) { if (e.updated) a = e.Update(); UpdatGUI(); Thread.Sleep(1); }
        }

        private void UpdatGUI()
        {

            this.BeginInvoke((Action)delegate ()
            {
                speed.Text = a.Item1.ToString();
            });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(doWork)).Start();
        }
    }
}
