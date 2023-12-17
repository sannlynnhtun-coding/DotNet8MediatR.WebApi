using DotNet8MediatR.Models.Atm;
using DotNet8MediatR.Models.Authenticate;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.Login
{
    public class LoginBusinessLogic
    {
        private readonly LoginDataAccess _loginDataAccess;
        private readonly AuthenticateToken _authenticateToken;
        public LoginBusinessLogic(LoginDataAccess loginDataAccess, 
            AuthenticateToken authenticateToken)
        {
            _loginDataAccess = loginDataAccess;
            _authenticateToken = authenticateToken;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            LoginResponseModel model = new();
            if (requestModel.CardNumber.IsNullOrEmpty())
            {
                model.Response.Set(Codes.Warning0001);
                goto result;
            }
            if (requestModel.Password.IsNullOrEmpty())
            {
                model.Response.Set(Codes.Warning0002);
                goto result;
            }
            model = await _loginDataAccess.Login(requestModel.CardNumber, requestModel.Password);
            var authenticateTokenResponseModel = _authenticateToken
                .GenerateToken(new AuthenticateTokenRequestModel
            {
                CardNumber = model.CardNumber,
                UserName = model.UserName,
                UserRoles = model.UserRoles
            });
            model.AccessToken = authenticateTokenResponseModel.AccessToken;
        result:
            return model;
        }
    }
}
