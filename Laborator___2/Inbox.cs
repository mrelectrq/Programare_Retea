using MailKit;
using MailKit.Net.Imap;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator2
{
    public partial class Inbox : Form
    {
        private readonly string Username;
        private readonly string Password;
        private ImapClient _client;
        public Inbox(string username, string password)
        {
            InitializeComponent();
            Username = username;
            Password = password;
        }
        //("smtp.gmail.com", 587);
        private void Inbox_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var cancel = new CancellationTokenSource())
            {
                _client.Connect(host.Text, Convert.ToInt32(port.Text), true, cancel.Token);
                _client.Authenticate(Username, Password, cancel.Token);
                _client.Inbox.Open(FolderAccess.ReadOnly, cancel.Token);
                for (int i = 1; i < 20; i++)
                {
                    var messageIn = _client.Inbox.GetMessage(i, cancel.Token);
                    message.Text = Messages.SelectedItem.ToString();
                }
                _client.Disconnect(true,cancel.Token);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _client = new ImapClient();
            try
            {
                using (var cancel = new CancellationTokenSource())
                {
                    _client.Connect(host.Text, Convert.ToInt32(port.Text), true, cancel.Token);
                    _client.Authenticate(Username, Password, cancel.Token);
                    _client.Inbox.Open(FolderAccess.ReadOnly, cancel.Token);
                    StringBuilder builder = new StringBuilder();
                    for (int i = 1; i < 20; i++)
                    {
                        var messageIn = _client.Inbox.GetMessage(i, cancel.Token);
                        Messages.Items.Add(messageIn.Subject + "      " + messageIn.Date + "      " + messageIn.From + "      "
                            + messageIn.TextBody + "\r\n");
                    }
                    _client.Disconnect(true, cancel.Token);
                }

            }
            catch (Exception eg)
            {
                MessageBox.Show(eg.Message);
            }
        }
    }
}
