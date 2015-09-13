using Service.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Utility
{
    public static class ThreadService
    {
        public static List<Thread> threads = new List<Thread>();

        public static void startListenThread(int port)
        {
            var thread = new Thread(() =>
            {
                TcpListenerService.startListening(port); 

            });

            thread.Start();
            threads.Add(thread);
        }

        public static void startListControllerThread(TcpClient client)
        {
            var thread = new Thread(() =>
            {
                var controller = new ListenController(client);
                controller.listen();
            });

            thread.Start();
            threads.Add(thread);
        }
    }
}
