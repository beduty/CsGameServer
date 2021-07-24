using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCore
{
    class Program
    {
        static Listener _listener =  new Listener();

        static void Main(string[] args)
        {
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress iPAddress = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(iPAddress, 7777);

            _listener.Init(endPoint);

            while (true)
            {
                Console.WriteLine("Listening...");

                // accept 
                Socket clientSocket = _listener.Accept();

                // receive
                byte[] recvBuff = new byte[1024];
                int recvBytes = clientSocket.Receive(recvBuff);
                string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                Console.WriteLine($"[From Client] {recvData}");

                // send
                byte[] sendBuff = Encoding.UTF8.GetBytes("Welcom to MMORPG Server !");
                clientSocket.Send(sendBuff);
                
                // close
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
