using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace IPR_LIB
{
    public class ClientConnectionHelp
    {
        Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        string _prefix = "client!!!";
        public void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {


                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException e)
                {
                  

                }
            }

            
             
            string connected = "get!!!connected//TextFile1.txt";
            byte[] buffer = Encoding.ASCII.GetBytes(connected);
            _clientSocket.Send(buffer);

        }

        private void ReceiveMessage()
        {

            Thread receivemessages = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        byte[] receivedBuffer = new byte[1024];
                        int rec = _clientSocket.Receive(receivedBuffer);
                        byte[] data = new byte[rec];

                        Array.Copy(receivedBuffer, data, rec);
                        string serverresponse = Encoding.ASCII.GetString(data);
                        string[] prefixwithmessage = serverresponse.Split(new[] { "!!!" }, StringSplitOptions.None);
                        Console.WriteLine(serverresponse);
                    }
                    catch (Exception e)
                    {
                        
                        Console.WriteLine(e.Message);
                    }
                }
            });
            receivemessages.Start();

        }

        public void SendMesage(string msg)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            _clientSocket.Send(buffer);
        }
    }
}
