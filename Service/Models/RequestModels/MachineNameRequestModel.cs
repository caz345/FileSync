using Service.Constants;
using Service.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.RequestModels
{
    class MachineNameRequestModel : TcpBaseJsonModel
    {
        public MachineNameRequestModel() : base(ModelTypes.MachineNameRequest)
        {

        }
    }
}
