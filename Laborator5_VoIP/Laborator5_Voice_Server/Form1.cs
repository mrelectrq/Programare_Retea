using NAudio.Wave;
using NAudio.Wave.SampleProviders;
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

namespace Laborator5_Voice_Server
{
    public partial class Form1 : Form
    {
        
        private WaveOut _player;
        private BufferedWaveProvider _provider;
        private int port;
        private Thread Listening;
        private Thread SoundOut;
        private byte[] data;
        NotifyingSampleProvider _notify;

        public Form1()
        {
            InitializeComponent();
            _player = new WaveOut();
            _provider = new BufferedWaveProvider(new WaveFormat(44100, 1));
            data = new byte[8000];
            _notify = new NotifyingSampleProvider(_provider.ToSampleProvider());
            
            Listening = new Thread(StartListener);
            SoundOut = new Thread(VoiceOut);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listening.Start();

            _player.Init(_notify);
            _player.Play();

        }

        private void StartListener()
        {

            try
            {
                port = int.Parse(txt_port.Text);
                var udpEndPoint = new IPEndPoint(IPAddress.Parse(txt_IP.Text), port);
                var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                udpSocket.Bind(udpEndPoint);
                while (true)
                {
                    var buffer = new byte[8000];
                    var size = 1000;
                    //var data = new StringBuilder();

                    EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    do
                    {

                        size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                        buffer.CopyTo(data,0);
                        Array.Clear(buffer, 0, buffer.Length);
                        _provider.AddSamples(data, 0, data.Length);

                        //data.Append(Encoding.UTF8.GetString(buffer));
                        //console_box.Text += size.ToString();

                    }
                    while (udpSocket.Available > 0);
                }
            }
            catch
            {
                MessageBox.Show("Eroare de parsare");
            }
            //_socket = new UDPSocket();
            // _socket.Server(txt_IP.Text, port);

            //const string ip = "192.168.56.1";
            // const int port = 8081;


            

        }
        
        private void VoiceOut()
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundOut.Abort();
            Listening.Abort();
        }
    }
}
