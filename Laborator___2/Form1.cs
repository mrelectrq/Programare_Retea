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

namespace Laborator2
{
    public partial class Form1 : Form
    {
        private SmtpClient _client;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            _client = new SmtpClient(host_name.Text, Convert.ToInt32(port.Text));
            try
            {
                _client.Credentials = new NetworkCredential(username.Text, password.Text);
                _client.EnableSsl = true;
                MessageBox.Show("Succeseful Contected");
            }catch(AggregateException error)
            {
                MessageBox.Show("Failed to connect" + error.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Message msgForm = new Message(_client);
            msgForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inbox inbox = new Inbox(username.Text,password.Text);
            inbox.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
