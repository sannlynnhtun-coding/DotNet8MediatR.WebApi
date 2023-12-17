
using DotNet8MediatR.Atm.Features.Atm;
using DotNet8MediatR.Models.Authenticate;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DotNet8MediatR.WebApi.Features;

[Route("api/[controller]")]
[ApiController]
public class ExecuteController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly AuthenticateToken _authenticateToken;
    private JwtSecurityToken _decodedToken { get; set; }

    public ExecuteController(IMediator mediator, AuthenticateToken authenticateToken)
    {
        _mediator = mediator;
        _authenticateToken = authenticateToken;
    }

    // public ExecuteController(IMediator mediator)
    //     => _mediator = mediator; 

    [HttpPost]
    public async Task<IActionResult> Execute(ApiRequestModel requestModel, CancellationToken cancellationToken)
    {
        try
        {
            var moduleId = Convert.ToInt32(requestModel.ReqService.Split(':')[0]);
            var moduleType = (EnumModuleType)moduleId;
            if (requestModel.ReqService.Split(':')[1] != "Login")
            {
                ValidToken(moduleType, requestModel.Token);
            }

            object? result = moduleType switch
            {
                EnumModuleType.Atm => await AtmModule(requestModel, cancellationToken),
                EnumModuleType.User => await UserModule(requestModel, cancellationToken),
                EnumModuleType.None => null,
                _ => throw new ArgumentOutOfRangeException()
            };
            return Ok(result);
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
        var token = GetAuthenticateModel(requestModel);
        var model = await _mediator.Send(new UserCommand(new UserApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
        model.Token = token is not null ? _authenticateToken.GenerateToken(token)?.AccessToken : null;
        return model;
    }

    private async Task<AtmApiResponseModel> AtmModule(ApiRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        var token = GetAuthenticateModel(requestModel);
        var model = await _mediator.Send(new AtmCommand(new AtmApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
        model.Token = token is not null ? _authenticateToken.GenerateToken(token)?.AccessToken : null;
        return model;
    }
    private async Task<UserApiResponseModel> UserModuleV1(ApiRequestModel requestModel,
       CancellationToken cancellationToken)
    {
        return await _mediator.Send(new UserCommand(new UserApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
    }
    private async Task<AtmApiResponseModel> AtmModuleV1(ApiRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(new AtmCommand(new AtmApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
    }

    private void ValidToken(EnumModuleType moduleType, string? token)
    {
        var handler = new JwtSecurityTokenHandler();
        _decodedToken = handler.ReadJwtToken(token ??
            throw new Exception("Token is required."));
        var item = _decodedToken?.Claims?
            .FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ??
            throw new Exception("Token doesn't exit.");
        var isAllow = moduleType.IsAllow(item);
        if (!isAllow)
            throw new Exception("Request is not allowed.");
    }

    private AuthenticateTokenRequestModel? GetAuthenticateModel(ApiRequestModel requestModel)
    {
        if (requestModel.ReqService.Split(':')[1] != "Login")
        {
            var model = new AuthenticateTokenRequestModel
            {
                CardNumber = _decodedToken?.Claims?
                            .FirstOrDefault(x => x.Type == "CardNumber")?.Value ??
                            throw new Exception("CardNumber is required."),
                UserName = _decodedToken?.Claims?
                            .FirstOrDefault(x => x.Type == "UserName")?.Value ??
                            throw new Exception("UserName is required."),
                UserRoles = [_decodedToken?.Claims?
                            .FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ??
                            throw new Exception("UserRoles is required.")],
            };
            return model;
        }
        return default;
    }
}