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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator4_Voice
{
    public partial class Form1 : Form
    {
        private int portNumber;
        private readonly WaveInEvent _audioSource; // for record audio
        private readonly BufferedWaveProvider _provider;
        private readonly WaveOut _player; // ce se va transla 
        private Socket socket;
        private TcpListener listener;
        private Stream stream;
        private TcpClient tcpClient;
        private byte[] data;
        
        public Form1()
        {
            InitializeComponent();
            _audioSource = new WaveInEvent { WaveFormat=new WaveFormat(44100, WaveIn.GetCapabilities(0).Channels) };
            _audioSource.DataAvailable += _audioSource_DataAvailable;

            _provider = new BufferedWaveProvider(new WaveFormat());
            _player = new WaveOut();
            data = new byte[10000];


        }

        private void _audioSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            BufferPlay(e.Buffer);
        }

        private void BufferPlay(byte [] recv)
        {
            if (recv.Length >0)
            {
                _provider.AddSamples(recv, 0, recv.Length);
                recv.CopyTo(data, 0);
            }
        }

        private void StartAudio()
        {

            _audioSource.StartRecording();
            stream = new NetworkStream(socket);
            socket.Send(data);
            //_player.Init(_provider);
            //_player.Play();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void button2_Click(object sender, EventArgs e)
        {
            StartAudio();

        }

        private void connect_click_Click(object sender, EventArgs e)
        {


            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            
            portNumber = int.Parse(txt_port.Text);
            //tcpClient = new TcpClient(txt_IP.Text, portNumber);
            try
            {
                socket.Connect(txt_IP.Text, portNumber);
                MessageBox.Show("Sa conectat cu succes");
            }
            catch
            {
                MessageBox.Show("Eroare de conectare");
            }
        }
    }
}
