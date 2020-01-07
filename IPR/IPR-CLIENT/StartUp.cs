using IPR_LIB;
using System;
using System.Windows.Forms;

namespace IPR_CLIENT
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            Environment.Exit(exitCode: 0);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Patient p = null;
            if (ValidateLogIn(ref p))
            {
                //TrainingPanel t = new TrainingPanel(p);
                Results r = new Results(p);
                r.Show();
                this.Hide();
            }
        }

        private bool ValidateLogIn(ref Patient p)
        {
            try
            {
                var name = TB_Naam.Text;
                var age = int.Parse(TB_Leeftijd.Text);
                var weight = int.Parse(TB_Gewicht.Text);
                var gender = getCheckedButton();
                p = new Patient(name, age, weight, gender);
                return true;
            }
            catch
            {
                TB_Error.Text = "Error, voer fatsoenlijke data in!";
                return false;
            }
        }

        private Config.Gender getCheckedButton()
        {
            string value = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                value = radioButton1.Text;
            else
                value = radioButton2.Text;
            if (value == "man") return (Config.Gender)Enum.Parse(typeof(Config.Gender), "Male");
            else return (Config.Gender)Enum.Parse(typeof(Config.Gender), "Female");
        }

        private void DataBaseButton_Click(object sender, EventArgs e)
        {
            History datascreen = new History();
            datascreen.Show();
            this.Hide();
        }
    }
}
