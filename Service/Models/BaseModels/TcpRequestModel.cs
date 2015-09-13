using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.BaseModels
{
    public class TcpBaseJsonModel
    {
        public TcpBaseJsonModel(string request)
        {
            requestType = request;
        }
        public string requestType { get; set; }

    }
}
