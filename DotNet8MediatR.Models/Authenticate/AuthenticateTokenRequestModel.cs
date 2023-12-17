using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.Authenticate
{
    public class AuthenticateTokenRequestModel
    {
        public string UserName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string[] UserRoles { get; set; } = null!;
    }

    public class AuthenticateTokenResponseModel
    {
        public string? AccessToken { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
