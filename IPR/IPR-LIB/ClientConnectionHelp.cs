using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string RecentInformation { get; set; } = "";
        public ObservableCollection<string> fileNames { get; set; } = new ObservableCollection<string>();
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

            
             
            string connected = "connected!!!Hello Server!";
            byte[] buffer = Encoding.ASCII.GetBytes(connected);
            _clientSocket.Send(buffer);

        }

        public void ReceiveMessage()
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
                        string[] SplitData = serverresponse.Split(new[] { "!!!" }, StringSplitOptions.None);
                        switch (SplitData[0])
                        {
                            case "filenames":
                                string[] names = SplitData[1].Split(new[] { "\r\n" }, StringSplitOptions.None);
                                foreach (string n in names)
                                {
                                    if (!fileNames.Contains(n))
                                    {
                                        fileNames.Add(n);
                                    }
                                }
                                break;
                            case "datarequest":
                                RecentInformation = SplitData[1];
                                break;
                        }
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
