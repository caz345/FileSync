using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service.Constants;
using Service.Helper;
using Service.Models;
using Service.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Service.Controller
{
    public class ListenController : IDisposable
    {
        TcpClient _server;
        NetworkStreamHelper stream;

        public void Dispose()
        {
            stream.Dispose();
            _server.Close();            
        }

        public ListenController(TcpClient server)
        {
            _server = server;
            stream = new NetworkStreamHelper(_server.GetStream());
        }

        public void listen()
        {
            while (true)
            {
                var data = stream.readJson();
                var jsonResponse = route(data);
                stream.writeJson(jsonResponse);
            }
        }

        private string route(JObject data)
        {
            string jsonString;

            var requestType = data[ModelTypes.RequestTypeProperty].ToString();
            switch(requestType)
            {
                case ModelTypes.MachineNameRequest:
                    {
                        var responseModel = getMachineName();
                        jsonString = JsonConvert.SerializeObject(responseModel);
                        break;
                    }
                default:
                    {
                        jsonString = @"{""Error"":""There was an error""}"; //Temp
                        break;
                    }
            }
            return jsonString;
        }
        public MachineModel getMachineName()
        {
            var name = ConfigurationManager.AppSettings["computerName"];

            var model = new MachineModel()
            {
                id = Guid.NewGuid().ToString(), //Temp
                machineName = name //Temp
            };

            return model;
        }
    }
}
