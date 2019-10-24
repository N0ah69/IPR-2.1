using IPR_LIB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPR_CLIENT
{
    public partial class Form2 : Form
    {
        ObservableCollection<string> names = new ObservableCollection<string>();
        ClientConnectionHelp CCH;
        public Form2(ClientConnectionHelp CCH)
        {
            this.CCH = CCH;
            InitializeComponent();
        }

        public Form2()
        {
            this.CCH = new ClientConnectionHelp();
            InitializeComponent();
            CCH.LoopConnect();
            CCH.ReceiveMessage();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }

        private void RequestButton_Click(object sender, EventArgs e)
        {
            CCH.SendMesage("locate!!!ok");
            Thread.Sleep(2000);
            FileListBox.DataSource = CCH.fileNames;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void DataRequestButton_Click(object sender, EventArgs e)
        {
            if (FileListBox.SelectedItem != null)
            {
                CCH.SendMesage("get!!!" + FileListBox.SelectedItem);
            }
            Patient p = JsonConvert.DeserializeObject<Patient>(CCH.RecentInformation);
            InfoLabel.Text = $"Name: {p.Name} \nAge: {p.Age} \nWeight: {p.Weight} \nGender {p.Gender.ToString()} \n";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
