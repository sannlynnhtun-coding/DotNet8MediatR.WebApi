using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.Atm
{
    public class LoginRequestModel
    {
        public string? CardNumber { get; set; }
        public string? Password { get; set; }
    }
}
