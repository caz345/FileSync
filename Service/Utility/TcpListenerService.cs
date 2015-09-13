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
    public static class TcpListenerService
    {
        public static void startListening(int port)
        {
            var server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            server.Start();
            while(true)
            {
                var connection = server.AcceptTcpClient();
                //Start Controller
            }            
        }
    }
}
