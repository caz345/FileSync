using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper
{
    public class NetworkStreamHelper : IDisposable
    {
        NetworkStream dataStream;

        public void Dispose()
        {
            dataStream.Close();
            dataStream.Dispose();
        }

        public NetworkStreamHelper(NetworkStream stream)
        {
            dataStream = stream;
        }

        public JObject readJson()
        {
            var lengthArray = new byte[4];
            dataStream.Read(lengthArray, 0, 4);

            var bufferlength = BitConverter.ToInt32(lengthArray, 0);

            var dataArray = new byte[bufferlength];
            dataStream.Read(dataArray, 0, bufferlength);

            var dataString = BitConverter.ToString(dataArray);

            var data = JObject.Parse(dataString);
            dataStream.Flush();
            return data;
        }

        public void writeJson(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);

            dataStream.Write(BitConverter.GetBytes(data.Length), 0, 4);
            dataStream.Write(data, 0, data.Length);
        }

    }
}
