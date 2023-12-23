using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm
{
    public class AtmApiResponseModel
    {
        public ResponseModel Response { get; set; } = null!;
        public object RespData { get; set; } = null!;
    }
}
