using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm
{
    public class AtmApiResponseModel
    {
        public ResponseModel Response { get; set; }
        public object RespData { get; set; }
        public string? Token {  get; set; }
    }
}
