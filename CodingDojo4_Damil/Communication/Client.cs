using System;
using System.Net;
using System.Net.Sockets;

namespace CodingDojo4_Damil.ViewModel
{
    public class Client
    {
        byte[] buffer = new byte[512];
        Socket clientsocket;
        Action<string> MsgInformer;
        Action AbortInformer;

        public Client(string ip, int port, Action<string> msgInformer, Action abortInformer)
        {
            try
            {
                this.AbortInformer = abortInformer;
                this.MsgInformer = msgInformer;
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);
                clientsocket = client.Client;
                StartReceiving();
            }
            catch (Exception)
            {
                msgInformer("Connection failed.");
                //to reset client communication
                AbortInformer(); 
            }
        }

        public void StartReceiving()
        {

        }

        public void Receive()
        {

        }

        public void Send(string msg)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {

        }
    }
}