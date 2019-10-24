namespace IPR_LIB
{
    public class Patient
    {
        private string Name;
        private int Age;
        private int Weight;
        private Config.Gender Gender;

        public Patient(string name, int age, int weight)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
        }
    }
}
