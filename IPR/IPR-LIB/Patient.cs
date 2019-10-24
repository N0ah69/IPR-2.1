using System.Collections.ObjectModel;

namespace IPR_LIB
{
    public class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public Config.Gender Gender { get; set; }
        public ObservableCollection<int> HeartRate { get; set; }
        public ObservableCollection<double> Resistance { get; set; }

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
