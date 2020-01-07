namespace IPR_LIB
{
    public class PatientInfo
    {
        public string name { get; set; }
        public int age { get; set; }
        public int weight { get; set; }
        public Config.Gender Gender { get; set; }
        public double VO2 { get; set; }
        public string TimeStart { get; set; }

        public PatientInfo(string name, int age, int weight, Config.Gender gender, double vO2, string TimeStart)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.Gender = gender;
            this.VO2 = vO2;
            this.TimeStart = TimeStart;
        }
    }
}
