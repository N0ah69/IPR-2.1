using IPR_LIB;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Threading;
using System.Windows.Forms;


namespace IPR_CLIENT
{
    public partial class TrainingPanel : Form
    {
        private Patient currentPatient;
        (double, int, int) a;
        BikeHandler Bhandler = new BikeHandler();
        private ChartValues<ObservableValue> ChartBPM;
        private ChartValues<ObservableValue> ChartRPM;
        private ChartValues<ObservableValue> ChartVoltage;
        private LiveCharts.WinForms.CartesianChart cc;
        private bool warmedup;
        private bool testStarted;
        private bool coolingDown;

        public TrainingPanel()
        {
            InitializeComponent();
            Bhandler.StartConnection();
            cc = new LiveCharts.WinForms.CartesianChart();
            ChartBPM = new ChartValues<ObservableValue>();
            ChartRPM = new ChartValues<ObservableValue>();
            ChartVoltage = new ChartValues<ObservableValue>();
            SeriesCollection sc = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "BPM",
                    Values = ChartBPM
                },
                new LineSeries
                {
                    Title = "RPM",
                    Values = ChartRPM
                },
                new LineSeries
                {
                    Title = "Voltage",
                    Values = ChartVoltage
                }
            };
            cc.Series = sc;
            C_Data = cc;

        }

        public void Start(Patient p)
        {
            currentPatient = p;
        }
        private void doWork()
        {
            this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Warm-Up"; });
            while (true)
            {
                if (Bhandler.updated)
                {
                    a = Bhandler.Update();
                    UpdateGUI();
                    SpeedHandler();
                    //for Vo2
                    currentPatient.CurrentRPM = a.Item1;
                    ChartRPM.Add(new ObservableValue(a.Item1));
                    currentPatient.CurrentBPM = a.Item2;
                    ChartBPM.Add(new ObservableValue(a.Item2));
                    currentPatient.voltage = a.Item3;
                    ChartVoltage.Add(new ObservableValue(a.Item3));
                    cc.Update();
                    C_Data.Update();

                    //for history
                    currentPatient.Voltages.Add(a.Item3);
                    currentPatient.Resistance.Add(Bhandler.CurrentResistance);
                    currentPatient.HeartRate.Add(Bhandler.BPM);
                    currentPatient.RPMHistory.Add(Bhandler.Rpm);

                    if (Bhandler.Time == 120 && !warmedup)
                    {
                        this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Testing"; });
                        Bhandler.Time = 0;
                        warmedup = true;
                    }
                    else if (Bhandler.Time == 240 && !testStarted)
                    {
                        this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Cooling Down"; });
                        Bhandler.Time = 0;
                        testStarted = true;
                    }
                    else if (Bhandler.Time == 60 && !coolingDown)
                    {
                        this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Test Finished"; });
                        coolingDown = true;
                        break;
                    }
                }
                Thread.Sleep(1);
            }
            new Results(currentPatient).Show();
        }

        private void UpdateGUI()
        {
            this.BeginInvoke((Action)delegate ()
            {
                speed.Text = a.Item1.ToString();
                HR.Text = a.Item2.ToString();
                Voltage.Text = a.Item3.ToString();
                TimeLabel.Text = Bhandler.FormatedTime();
            });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bhandler.setUpBikeConection(TB_Bike.Text);
            new Thread(new ThreadStart(doWork)).Start();
            new Thread(new ThreadStart(Bhandler.ResistanceOnHR)).Start();
            B_start.Hide();
            TB_Bike.Enabled = false;
        }

        private void SpeedHandler()
        {
            if (currentPatient.CurrentRPM > 63) this.BeginInvoke((Action)delegate () { StatusLabel.Text = $"Fiets wat rustiger je gaat {currentPatient.CurrentRPM - 60} RPM te snel!"; });
            else if (currentPatient.CurrentRPM < 57) this.BeginInvoke((Action)delegate () { StatusLabel.Text = $"Fiets wat rustiger je gaat {60 - currentPatient.CurrentRPM} RPM te te langzaam!"; });
            else this.BeginInvoke((Action)delegate ()
            {
                StatusLabel.Text = $"Ga zo door let wel op je snelheid!";
            });
        }

    }
}
