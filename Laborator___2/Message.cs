using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator2
{
    public partial class Message : Form
    {
        private readonly SmtpClient _client;
        public Message(SmtpClient client)
        {
            _client = client;
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailAddress addressHost = new MailAddress("altio.alexandru@gmail.com");
            MailAddress to = new MailAddress(reciever.Text);
            MailMessage mail = new MailMessage(addressHost, to);
            mail.Subject = subject.Text;
            mail.Body = messageText.Text;

            try
            {
                _client.Send(mail);
                MessageBox.Show("Transmis cu succes");
            }
            catch(AggregateException err)
            {
                MessageBox.Show("Eroare de conectare" + err.Message);
            }


        }
    }
}
