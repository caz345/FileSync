using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Utility
{
    public class TcpListenerService
    {
        int _port;
        TcpListener server;
        public TcpListenerService(int port)
        {
            _port = port;
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), _port);

        }

        public Thread startListening()
        {
            
            server.Start();
            var serverThread = new Thread(() =>
            {
                while(true)
                {
                    var connection = server.AcceptTcpClient();
                }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
            return serverThread;
        }
    }
}
