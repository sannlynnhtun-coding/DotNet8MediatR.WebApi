﻿namespace DotNet8MediatR.Atm.Features.Atm.Login;
public class LoginBusinessLogic(
    LoginDataAccess loginDataAccess,
    AuthenticateTokenService authenticateTokenService)
{
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
        model = await loginDataAccess.Login(requestModel.CardNumber!, requestModel.Password!);
        var authenticateTokenResponseModel = authenticateTokenService
            .GenerateToken(new AuthenticateTokenRequestModel
        {
            CardNumber = model.CardNumber,
            UserName = model.UserName,
            UserRoles = model.UserRoles
        });
        model.AccessToken = authenticateTokenResponseModel!.AccessToken!;
    result:
        return model;
    }
}
