using IPR_LIB;
using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Threading;
using System.Windows.Forms;


namespace IPR_CLIENT
{
    public partial class TrainingPanel : Form
    {
        private Patient currentPatient;
        (int, int, int) a;
        BikeHandler Bhandler = new BikeHandler();

        public TrainingPanel()
        {
            InitializeComponent();
            Bhandler.StartConnection();

        }

        public void Start(Patient p)
        {
            currentPatient = p;
        }
        private void doWork()
        {
            while (true)
            {
                if (Bhandler.updated)
                {
                    a = Bhandler.Update();
                    UpdateGUI();
                    //for Vo2
                    currentPatient.CurrentRPM = a.Item1;
                    currentPatient.CurrentBPM = a.Item2;
                    currentPatient.voltage = a.Item3;
                    //for history
                    currentPatient.Voltages.Add(a.Item3);
                    currentPatient.Resistance.Add(Bhandler.CurrentResistance);
                    currentPatient.HeartRate.Add(Bhandler.BPM);
                    currentPatient.RPMHistory.Add(Bhandler.Rpm);
                }
                Thread.Sleep(1);
            }
        }

        private void UpdateGUI()
        {
            this.BeginInvoke((Action)delegate ()
            {
                speed.Text = a.Item1.ToString();
                HR.Text = a.Item2.ToString();
                Voltage.Text = a.Item3.ToString();
            });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bhandler.setUpBikeConection(TB_Bike.Text);
            new Thread(new ThreadStart(doWork)).Start();
            B_start.Hide();
            TB_Bike.Enabled = false;
        }

        private void SpeedHandler()
        {
            if (currentPatient.CurrentRPM > 63) StatusLabel.Text = $"Fiets wat rustiger je gaat {currentPatient.CurrentRPM - 60} RPM te snel!";
            else if (currentPatient.CurrentRPM < 57) StatusLabel.Text = $"Fiets wat rustiger je gaat {60 - currentPatient.CurrentRPM} RPM te te langzaam!";
            else StatusLabel.Text = $"Ga zo door let wel op je snelheid!";
        }

    }
}
