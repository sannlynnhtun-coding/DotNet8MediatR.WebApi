using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8MediatR.WebApi.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExecuteController(IMediator mediator) => _mediator = mediator;
    }
}
