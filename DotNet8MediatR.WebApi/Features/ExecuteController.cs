using DotNet8MediatR.WebApi.Features.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8MediatR.WebApi
{
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
                return Ok(await _mediator.Send(new CustomerCommand(new CustomerApiRequestModel
                {
                    ReqData = requestModel.ReqData,
                    ReqService = requestModel.ReqService,
                }), cancellationToken));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseModel
                {
                    Response = new ResponseModel("999", ex.ToString(), EnumRespType.Error)
                });
            }
        }
    }
}
