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
        //for data handling
        Patient currentPatient;
        BikeHandler Bhandler = new BikeHandler();
        //charts
        ChartValues<ObservableValue> ChartBPM;
        ChartValues<ObservableValue> ChartRPM;
        ChartValues<ObservableValue> ChartVoltage;
        LiveCharts.WinForms.CartesianChart cc;
        //timer
        IPR_LIB.Timer timer;
        //band-aid bools
        bool warmedup;
        bool testStarted;

        public TrainingPanel(Patient p)
        {
            InitializeComponent();

            //init timer and set up connection bike
            currentPatient = p;
            b_results.Enabled = false;
            timer = new IPR_LIB.Timer();
            Bhandler.StartConnection();

            //set up charts
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
                }
            };
            C_Data.Series = sc;

            C_Data.AxisX.Add(new Axis
            {
                Title = "Measurement",

            });

            C_Data.AxisY.Add(new Axis
            {
                Title = "Values",
                MinValue = 0
            });
            cc.LegendLocation = LegendLocation.Right;
            cc.DataClick += CartesianChart1OnDataClick;
        }

        void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        // update method, might need trimming
        private void doWork()
        {
            var testDone = false;
            timer.StartTimer();
            this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Warm-Up"; });
            while (true)
            {
                if (testDone) break;
                if (Bhandler.updated)
                {
                    var a = Bhandler.Update();
                    UpdateChart();
                    UpdateGUI(a);
                    SpeedHandler();
                    UpdateData(a);
                    HandleTimings(ref testDone);
                }
                Thread.Sleep(1);
            }
        }

        void HandleTimings(ref bool testDone)
        {
            if (timer.min == 2 && !warmedup)
            {
                this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Testing"; });
                timer.Reset();
                warmedup = true;
            }
            else if (timer.min == 4 && warmedup && !testStarted)
            {
                this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Cooling Down"; });
                timer.Reset();
                testStarted = true;
                Bhandler.onCool = true;
            }
            else if (timer.min == 1 && testStarted)
            {
                this.BeginInvoke((Action)delegate () { TestStatLabel.Text = "Test Finished"; });
                timer.Pause();
                b_results.Enabled = true;
                testDone = true;
            }
        }

        void UpdateData((double, int, int) a)
        {
            //for Vo2
            currentPatient.CurrentRPM = a.Item1;
            ChartRPM.Add(new ObservableValue(a.Item1));
            currentPatient.CurrentBPM = a.Item2;
            ChartBPM.Add(new ObservableValue(a.Item2));
            currentPatient.voltage = a.Item3;
            ChartVoltage.Add(new ObservableValue(a.Item3));

            //for history
            currentPatient.Voltages.Add(a.Item3);
            currentPatient.Resistance.Add(Bhandler.CurrentResistance);
            currentPatient.HeartRate.Add(Bhandler.BPM);
            currentPatient.RPMHistory.Add(Bhandler.Rpm);
        }

        void UpdateChart()
        {
            if (ChartBPM.Count > 50) ChartBPM.RemoveAt(0);
            if (ChartRPM.Count > 50) ChartRPM.RemoveAt(0);
            if (ChartVoltage.Count > 50) ChartVoltage.RemoveAt(0);
            this.BeginInvoke((Action)delegate () { C_Data.Update(); });
        }

        void UpdateGUI((double, int, int) a)
        {
            this.BeginInvoke((Action)delegate ()
            {
                speed.Text = a.Item1.ToString();
                HR.Text = a.Item2.ToString();
                TimeLabel.Text = timer.GetTime();
                Label_Resistance.Text = Bhandler.CurrentResistance.ToString();
            });
        }

        void Button1_Click(object sender, EventArgs e)
        {
            Bhandler.setUpBikeConection(TB_Bike.Text);
            new Thread(new ThreadStart(doWork)).Start();
            new Thread(new ThreadStart(Bhandler.ResistanceOnHR)).Start();
            B_start.Hide();
            TB_Bike.Enabled = false;
        }

        void SpeedHandler()
        {
            if (currentPatient.CurrentRPM > 63) this.BeginInvoke((Action)delegate () { StatusLabel.Text = $"Fiets wat rustiger je gaat {currentPatient.CurrentRPM - 60} RPM te snel!"; });
            else if (currentPatient.CurrentRPM < 57) this.BeginInvoke((Action)delegate () { StatusLabel.Text = $"Fiets wat harder je gaat {60 - currentPatient.CurrentRPM} RPM te te langzaam!"; });
            else this.BeginInvoke((Action)delegate ()
            {
                StatusLabel.Text = $"Ga zo door let wel op je snelheid!";
            });
        }

        void B_results_Click(object sender, EventArgs e)
        {
            Results results = new Results(currentPatient);
            results.Show();
        }
    }
}
