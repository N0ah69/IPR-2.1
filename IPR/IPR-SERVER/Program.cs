using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace IPR_SERVER
{
    class Program
    {
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clients = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.Title = "IPR-SERVER";
            ReadyServer();
            Console.ReadLine();

        }

        private static void ReadyServer()
        {
            Console.WriteLine("Server is setting up.......");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSocket.Listen(4); ;
            _serverSocket.BeginAccept(new AsyncCallback(AcceptingCallback), null);
        }

        private static void AcceptingCallback(IAsyncResult ar)
        {
            Socket Csocket = _serverSocket.EndAccept(ar);
            _clients.Add(Csocket);
            Console.WriteLine("New client connected......");
            Csocket.BeginReceive(
                _buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceivingCallback), Csocket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptingCallback), null);
        }


        private static void ReceivingCallback(IAsyncResult ar)
        {
            Socket CSocket = (Socket)ar.AsyncState;
            int received = CSocket.EndReceive(ar);
            byte[] dataBuffer = new byte[received];
            Array.Copy(_buffer, dataBuffer, received);
            string temp = Encoding.ASCII.GetString(dataBuffer);
            string[] Info = temp.Split(new string[1] { "!!!" }, StringSplitOptions.None);
            string ID = Info[0];
            string data = Info[1];
            Console.WriteLine($"Received text: { data } from: { ID}");
            switch (ID)
            {
                case "connected":
                    Console.WriteLine($"Clients connected at the moment: { _clients.Count } ");
                    SendResponse(CSocket, "ok");
                    break;
                case "get":

                    break;
                case "save":
                    dynamic json = JsonConvert.DeserializeObject(data);
                    string filepath = getPath() + $"Logs/{(json.TimeStart as JToken).Value<string>().Replace("/", "-").Replace(":", @".")}.txt";
                    if (!File.Exists(filepath)){
                        File.Create(filepath).Close();

                        Thread.Sleep(500);
                        TextWriter TW = new StreamWriter(filepath, false);
                        TW.WriteLine(data);
                        TW.Close();
                    } else if(File.Exists(filepath))
                    {
                        using (var TW = new StreamWriter(filepath, true))
                        {
                            TW.WriteLine(data);
                            TW.Close();
                        }
                    }
                    SendResponse(CSocket, "ok");
                    break;
            }
        }

        private static void SendingCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }


        public static void SendResponse(Socket socket, string response)
        {
            byte[] data = Encoding.ASCII.GetBytes(response);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendingCallback), socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceivingCallback), socket);
        }

        public static string getPath()
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string Startsplit = startupPath.Substring(0, startupPath.LastIndexOf("bin"));
            string split = Startsplit.Replace(@"\", "/");
            return split;
        }
    }
}
