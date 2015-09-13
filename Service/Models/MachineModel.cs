using Service.Constants;
using Service.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class MachineModel : TcpBaseJsonModel
    {
        public MachineModel() : base(ModelTypes.Machine.ToString())
        {

        }
        public string id { get; set; }
        public string machineName { get; set; }
    }
}
