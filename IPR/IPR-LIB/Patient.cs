using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IPR_LIB
{
    public class Patient
    {
        private string Name;
        private int Age;
        private int Weight;
        private Config.Gender Gender;
        public ObservableCollection<int> HeartRate;
        public ObservableCollection<int> RPMHistory;
        public ObservableCollection<double> Resistance;
        public int CurrentBPM { set; get; }
        public int CurrentRPM { set; get; }
        public ObservableCollection<double> Voltages;
        public int voltage;

        public Patient(string name, int age, int weight, Config.Gender Gender)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.HeartRate = new ObservableCollection<int>();
            this.Resistance = new ObservableCollection<double>();
            this.RPMHistory = new ObservableCollection<int>();
            this.Voltages = new ObservableCollection<double>();
        }
        private double correction(int Age)
        {
            if (Age <= 15)
            {
                return 1.1 + (15 - Age) * 0.01;
            }
            else if (Age <= 25)
            {
                return 1.0 + (25 - Age) * 0.01;
            }
            else if (Age <= 35)
            {
                return 0.87 + (35 - Age) * (0.013);
            }
            else if (Age <= 40)
            {
                return 0.83 + (40 - Age) * 0.008;
            }
            else if (Age <= 45)
            {
                return 0.78 + (45 - Age) * 0.01;
            }
            else if (Age <= 50)
            {
                return 0.75 + (50 - Age) * 0.006;
            }
            else if (Age <= 55)
            {
                return 0.71 + (55 - Age) * 0.008;
            }
            else if (Age <= 60)
            {
                return 0.68 + (60 - Age) * 0.006;
            }
            else if (Age <= 65)
            {
                return 0.65 + (65 - Age) * 0.006;
            }
            else
            {
                return 0.65 - (Age - 65) * 0.006;
            }
        }
        public double Vo2Calculator(Config.Gender g)
        {
            if (g == Config.Gender.Female)
            {
                double workload = 0;
                foreach (double voltage in Voltages)
                {
                    workload += voltage;
                }
                workload = workload / Voltages.Count;
                workload = workload * 6.12;
                return ((0.00193 * workload + 0.326) / (0.769 * this.CurrentBPM - 56.1) * 100) * correction(this.Age);
            }
            else
            {
                double workload = 0;
                foreach (double voltage in Voltages)
                {
                    workload += voltage;
                }
                workload = workload / Voltages.Count;
                workload = workload * 6.12;
                return ((0.00212 * workload + 0.299) / (0.769 * this.CurrentBPM - 48.5) * 100) * correction(this.Age);
            }
        }
    }
}

