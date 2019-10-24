using System.Collections.ObjectModel;

namespace IPR_LIB
{
    public class Patient
    {
        private string Name;
        private int Age;
        private int Weight;
        private Config.Gender Gender;
        private ObservableCollection<int> HeartRate;
        private ObservableCollection<double> Resistance;

        public Patient(string name, int age, int weight, Config.Gender Gender)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.HeartRate = new ObservableCollection<int>();
            this.Resistance = new ObservableCollection<double>();
        }
    }
}
