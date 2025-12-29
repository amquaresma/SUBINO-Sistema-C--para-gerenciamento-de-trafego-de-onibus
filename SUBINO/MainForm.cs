using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SUBINO
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void Timer1Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }
        }
    }
}
