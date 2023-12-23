using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm
{
    public class AtmApiRequestModel
    {
        public string ReqService { get; set; }
        public object ReqData { get; set; }
    }
}
