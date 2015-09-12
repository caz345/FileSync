using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Controller
{
    public class ListenController : IDisposable
    {
        TcpClient _server;
        NetworkStream listenStream;

        public void Dispose()
        {
            listenStream.Dispose();
            _server.Close();            
        }

        public ListenController(TcpClient server)
        {
            _server = server;
        }

        public void listen()
        {
            listenStream = _server.GetStream();
            while (true)
            {
                var lengthArray = new byte[4];
                listenStream.Read(lengthArray, 0, 4);

                var bufferlength = BitConverter.ToInt32(lengthArray, 0);

                var dataArray = new byte[bufferlength];
                listenStream.Read(dataArray, 0, bufferlength);

                var dataString = BitConverter.ToString(dataArray);

                var data = JObject.Parse(dataString);
                listenStream.Flush();
            }
        }
    }
}
