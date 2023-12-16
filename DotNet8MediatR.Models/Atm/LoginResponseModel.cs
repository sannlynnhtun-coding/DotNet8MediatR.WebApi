using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.Atm
{
    public class LoginResponseModel
    {
        public ResponseModel Response { get; set; } = new();
        public string UserName { get; set; }
        public string CardNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Balance { get; set; }
        public string[] UserRoles { get; set; }
        public string AccessToken { get; set; }
    }
}
