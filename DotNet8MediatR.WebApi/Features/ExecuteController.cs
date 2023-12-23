
using DotNet8MediatR.Atm.Features.Atm;
using DotNet8MediatR.Models.Authenticate;
using DotNet8MediatR.Shared;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace DotNet8MediatR.WebApi.Features;

[Route("api/[controller]")]
[ApiController]
public class ExecuteController(IMediator mediator, AuthenticateTokenService authenticateTokenService) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly AuthenticateTokenService _authenticateTokenService = authenticateTokenService;
    private JwtSecurityToken DecodedToken { get; set; }

    [HttpPost]
    public async Task<IActionResult> Execute(ApiRequestModel requestModel, CancellationToken cancellationToken)
    {
        try
        {
            var moduleId = Convert.ToInt32(requestModel.ReqService.Split(':')[0]);
            var moduleType = (EnumModuleType)moduleId;
            var valid = ValidToken(requestModel, moduleType, requestModel.Token);
            if (valid!.Response.IsError)
                return Ok(valid);

            object? result = moduleType switch
            {
                EnumModuleType.Atm => await AtmModule(requestModel, cancellationToken),
                EnumModuleType.User => await UserModule(requestModel, cancellationToken),
                EnumModuleType.None => null,
                _ => throw new ArgumentOutOfRangeException()
            };
            var token = GetAuthenticateModel(requestModel);
            JObject jObj = result.ToJObject();
            jObj.TryAdd("Token", token is not null ? _authenticateTokenService.GenerateToken(token)?.AccessToken : null);
            return Content(jObj.ToJson()!, Application.Json);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponseModel
            {
                Response = new ResponseModel("999", ex.ToString(), EnumRespType.Error)
            });
        }
    }

    private async Task<UserApiResponseModel> UserModule(ApiRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new UserCommand(new UserApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
        return model;
    }

    private async Task<AtmApiResponseModel> AtmModule(ApiRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        var model = await _mediator.Send(new AtmCommand(new AtmApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
        return model;
    }

    private ApiResponseModel? ValidToken(ApiRequestModel requestModel, EnumModuleType moduleType, string? token)
    {
        if (requestModel.ReqService.Split(':')[1] != "Login")
        {
            var handler = new JwtSecurityTokenHandler();
            if (token is null)
                return TokenError("Token is required.");

            DecodedToken = handler.ReadJwtToken(token);
            var item = DecodedToken?.Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? null;
            if (item is null)
                return TokenError("Role doesn't exist.");

            var isAllow = moduleType.IsAllow(item);
            if (!isAllow)
                return TokenError("Request is not allowed.");
        }
        return new ApiResponseModel { Response = new ResponseModel { RespType = EnumRespType.Success } };
    }

    private AuthenticateTokenRequestModel? GetAuthenticateModel(ApiRequestModel requestModel)
    {
        if (requestModel.ReqService.Split(':')[1] != "Login")
        {
            var model = new AuthenticateTokenRequestModel
            {
                CardNumber = DecodedToken?.Claims?
                            .FirstOrDefault(x => x.Type == "CardNumber")?.Value ??
                            throw new Exception("CardNumber is required."),
                UserName = DecodedToken?.Claims?
                            .FirstOrDefault(x => x.Type == "UserName")?.Value ??
                            throw new Exception("UserName is required."),
                UserRoles = [DecodedToken?.Claims?
                            .FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ??
                            throw new Exception("UserRoles is required.")],
            };
            return model;
        }
        return default;
    }

    private ApiResponseModel TokenError(string error)
    {

        return new ApiResponseModel
        {
            Response = new ResponseModel("999", error, EnumRespType.Error)
        };
    }
}