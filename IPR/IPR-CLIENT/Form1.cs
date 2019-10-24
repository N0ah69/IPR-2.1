using IPR_LIB;
using System;
using System.Windows.Forms;

namespace IPR_CLIENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Patient p = null;
            if (ValidateLogIn(ref p))
            {
                TrainingPanel t = new TrainingPanel();
                t.Show();
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
    }
}
