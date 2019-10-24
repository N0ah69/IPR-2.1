using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

            
             
            string connected = "connected client!!!Hello world!";
            byte[] buffer = Encoding.ASCII.GetBytes(connected);
            _clientSocket.Send(buffer);

        }

        public void SendMesage(string msg)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            _clientSocket.Send(buffer);
        }
    }
}
