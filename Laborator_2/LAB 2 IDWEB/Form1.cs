using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_2_IDWEB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           InitializeComponent();
            this.Text = "Lab 2";
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Login_Click(object sender, EventArgs e)
        {

            LogIn lg = new LogIn();
            lg.Show();
        }

    }
}
