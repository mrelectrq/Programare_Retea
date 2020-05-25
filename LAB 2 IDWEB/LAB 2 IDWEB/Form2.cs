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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            


        InitializeComponent();
            this.Text = "Lab 2";
        }

        
        private void ButtonSend_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            
            // Who send?
            MailAddress From = new MailAddress("altio.alexandru@gmail.com", "Alex");
            Form1 f1 = new Form1();
            string utilizator = Username;
            string password = Password;
            // where to send?
            string email=sendemail.Text;
            MailAddress To = new MailAddress(email);
            MailMessage msg = new MailMessage(From, To);
            msg.Subject = Subject.Text;
            msg.Body = Message.Text;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(utilizator, password);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
                Form3 f3 = new Form3();
                f3.Show();
            }
            catch
            {
                MessageBox.Show("Eroare de Conectare");
            }


        
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }
        public static string Username;
        public static string Password;
        private void button1_Click(object sender, EventArgs e)
        {
            Username = user.Text;
            Password = pass.Text;
            LogIn l = new LogIn();
            l.Show();

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.PasswordChar = '●';
        }
    }
}
