using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm
{
    public record AtmCommand(AtmApiRequestModel reqModel) : IRequest<AtmApiResponseModel>;
}
