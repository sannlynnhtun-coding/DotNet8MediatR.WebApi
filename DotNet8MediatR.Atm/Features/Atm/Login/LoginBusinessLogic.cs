using DotNet8MediatR.Models.Atm;
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

        public LoginBusinessLogic(LoginDataAccess loginDataAccess)
        {
            _loginDataAccess = loginDataAccess;
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

        result:
            return model;
        }
    }
}
