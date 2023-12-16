
namespace DotNet8MediatR.WebApi.Features;

[Route("api/[controller]")]
[ApiController]
public class ExecuteController : ControllerBase
{
    private readonly IMediator _mediator;
    public ExecuteController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Execute(ApiRequestModel requestModel, CancellationToken cancellationToken)
    {
        try
        {
            var moduleId = Convert.ToInt32(requestModel.ReqService.Split(':')[0]);
            var moduleType = (EnumModuleType)moduleId;
            object result = moduleType switch
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
        return await _mediator.Send(new UserCommand(new UserApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
    }

    private async Task<AtmApiResponseModel> AtmModule(ApiRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(new AtmCommand(new AtmApiRequestModel
        {
            ReqService = requestModel.GetServiceName(),
            ReqData = requestModel.ReqData,
        }), cancellationToken);
    }
}