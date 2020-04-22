using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator5_Client
{
    public partial class Form1 : Form
    {
        private readonly TcpClient client = new TcpClient();
        private NetworkStream stream;
        private int portNumber;

        private static Image GrabDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics graphic = Graphics.FromImage(screenshot);
            graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size,CopyPixelOperation.SourceCopy);
            return screenshot;
        }

        private void SendDesktopImage()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            stream = client.GetStream();
            formatter.Serialize(stream, GrabDesktop());
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            portNumber = int.Parse(txt_port.Text);
            try
            {
                client.Connect(txt_ip.Text, portNumber);
                MessageBox.Show("Este conectat");
            }
            catch
            {
                MessageBox.Show("Eroare de conectare");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text.StartsWith("Share"))
            {
                timer1.Start();
                button2.Text = "Stopeaza partajarea";
            }
            else
            {
                timer1.Stop();
                button2.Text = "Partajeaza Ecranul";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
        }
    }
}