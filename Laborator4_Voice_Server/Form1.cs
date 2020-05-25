using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator4_Voice_Server
{
    public partial class Form1 : Form
    {



        private readonly WaveOut _player;
        private readonly BufferedWaveProvider _provider;
        byte[] buffer = new byte[1028];
        private int port;
        private Socket socket;
        //private NetworkStream stream;

        private  Thread Listening;
        private  Thread SountOut;


        public Form1()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            
            InitializeComponent();
        }


        private void StartListening()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                socket.Bind(localEndPoint);
                socket.Listen(20);
                
                
            }
            catch
            {
                MessageBox.Show("Eroare de ascultare");
            }
        }

        private void ReceiveVoice()
        {
            while (true)
            {
                Socket handler = socket.Accept();
               
                while (true)
                {
                    int bytesRec = handler.Receive(buffer);
                    BufferPlay(buffer);
                    _player.Init(_provider);
                    _player.Play();
                }
            }
        }

        private void BufferPlay(byte [] recv)
        {
            if (recv.Length>0)
            {
                _provider.AddSamples(recv, 0, recv.Length);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            port = int.Parse(txt_port.Text);
            Listening = new Thread(StartListening);
            SountOut = new Thread(ReceiveVoice);
        }
    }
}
