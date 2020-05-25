using Limilabs.Client.IMAP;
using Limilabs.Mail;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_2_IDWEB
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }


        private void message_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = user.Text;
            Password = pass.Text;
            LogIn l = new LogIn();
            l.Show();

            using (var client = new ImapClient())
            {
                using (var cancel = new CancellationTokenSource())
                {
                    client.Connect("imap.gmail.com", 993, true, cancel.Token);
                    // If you want to disable an authentication mechanism,
                    // you can do so by removing the mechanism like this:
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate(Username, Password, cancel.Token);

                        // The Inbox folder is always available...
                        var inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadOnly, cancel.Token);
                        string item;
                        var b = inbox.Count.ToString();
                        var a = inbox.Recent.ToString();

                        StringBuilder sb = new StringBuilder();
                        // download each message based on the message index
                        for (int i = 1; i < inbox.Count; i++)
                        {
                            var message = inbox.GetMessage(i, cancel.Token);
                            Subjects.Items.Add(message.Subject + "   |   " + message.Date + "   |   " + message.From + "   |   " + message.TextBody);
                        }
                        client.Disconnect(true, cancel.Token);
                    
                }
            }

        }
        public static string Username;
        public static string Password;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        public static string messages;
        public static string recentmessages;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.PasswordChar = '●';
        }
        private void Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var client = new ImapClient())
            {
                using (var cancel = new CancellationTokenSource())
                {
                    client.Connect("imap.gmail.com", 993, true, cancel.Token);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate(Username, Password, cancel.Token);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly, cancel.Token);
                    string item;
                    var b = inbox.Count.ToString();
                    var a = inbox.Recent.ToString();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i, cancel.Token);
                        listmess.Text = Subjects.SelectedItem.ToString();
                    } 
                    client.Disconnect(true, cancel.Token);
                }

            }
        }
    }
}


