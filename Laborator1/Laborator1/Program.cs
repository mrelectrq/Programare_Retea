using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Laborator1
{
    class Program
    {
        private static Semaphore _pool;
        private static int _padding;
        public static bool ValidateServerCertificate(
            object sender, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors policyErrors)
        {
            if (policyErrors == SslPolicyErrors.None)
                return true;
            Console.WriteLine("Certificate error: {0}", policyErrors);
            return false;
        }
        static void Main(string[] args)
        {

            _pool = new Semaphore(4, 4);
            TcpClient client = new TcpClient("81.180.74.23", 443);

            SslStream ssl = new SslStream(
                client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null
                );

            try
            {
                ssl.AuthenticateAsClient("utm.md");
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                client.Close();
                return;
            }

            byte[] buffer = new byte[2048];
            
            string request_url = "GET / HTTP/1.1\r\n" +
            "Host: utm.md\r\n\r\n"+
            "Accept: *\r\n\r\n";


            byte[] request = Encoding.UTF8.GetBytes(String.Format(request_url));
            ssl.Write(request, 0, request.Length);
            //ssl.Write(request, 0, request.Length);
            //ssl.Write(Encoding.UTF8.GetBytes("\r\n"));
            ssl.Flush();
            //bool state = ssl.IsAuthenticated;
            //IPAddress host = IPAddress.Parse("81.180.74.2");
            //IPEndPoint hostep = new IPEndPoint(host, 443);
            // Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // sock.Connect(hostep);
            int bytes = -1;
            int i=-1;
            StringBuilder messageData = new StringBuilder();
            do
            {
                bytes =ssl.Read(buffer, 0, buffer.Length);

                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, buffer.Length)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }
                // i = ssl.ReadByte();
                //Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytes));
            } while (bytes!=0);
            Console.WriteLine(messageData.ToString());

            string response = messageData.ToString();
            Regex regex = new Regex(@"wp-content/(.*?)(?:jpg|gif|png)");
            var mach = regex.Matches(response);

            var list = new List<string>();
            foreach (Match m in mach)
            {
                var path = m.Value;
                list.Add(m.Value);
                Console.WriteLine(m.Value);
            }
            ssl.Close();

            for (int index = 0; index <=51; index++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(SaveImage));
                Console.WriteLine(index);
                t.Start(list[index]);
                
            }
            //SaveImage(list[5]);
           // Thread.Sleep(500);

            //_pool.Release(3);
            Console.ReadKey();

        }


        public static void SaveImage(object name_path)
        {
            TcpClient client = new TcpClient("81.180.74.23", 443);

            SslStream ssl = new SslStream(
                client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null
                );

            try
            {
                ssl.AuthenticateAsClient("utm.md");
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                client.Close();
                return;
            }

            Console.WriteLine("Thread {0} sa initializat si asteapta semaforul----------------", (string)name_path);
            _pool.WaitOne();
            string data = (string)name_path;
            string data1=data.Replace(@"\\", "");
            string data2 = data1.Replace(@"/", "");
            string data3 = data2.Replace(@"\", "");



            int padding = Interlocked.Add(ref _padding, 100);

            var saveLocation = $@"D:\img\{ padding.ToString()+data3}";
            

            byte[] imageBytes;

            byte[] buffer = new byte[2048];

            var request_img = "GET https://utm.md/" + (string)name_path + " HTTP/1.1\r\n" +
            "Host: utm.md\r\n" +
            "Content-Lenght: 0 \r\n"
            + "\r\n";

            byte[] message = Encoding.UTF8.GetBytes(request_img);
            ssl.Write(message, 0, message.Length);
            ssl.Flush();

            int bytes = -1;
            int i = 0;
            StringBuilder messageData = new StringBuilder();
            var resp = new List<byte>();
            do
            {
                bytes = ssl.Read(buffer, 0, buffer.Length);
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, buffer.Length)];

                decoder.GetChars(buffer, 0, bytes, chars, 0);
                if (i >= 1)
                {

                    resp.AddRange(buffer);
                    messageData.Append(chars);
                }
                i++;
                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }
                // i = ssl.ReadByte();
                //Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytes));
            } while (bytes != 0);

           // Console.WriteLine(messageData.ToString());

            var img = resp.ToArray();
            Bitmap bmp;
            using (var ms = new MemoryStream(img))
            {
                // ms.Seek(0, SeekOrigin.Begin);
                bmp = new Bitmap(ms);
                bmp.Save(saveLocation);
            }
            Console.WriteLine("Thread {0} sa realizat in semafor ----------------{1}", (string)name_path, _pool.Release()); 
        }
    }
}
