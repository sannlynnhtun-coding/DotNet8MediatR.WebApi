using DotNet8MediatR.Atm.Features.Atm.Login;
using DotNet8MediatR.Models.Atm;
using DotNet8MediatR.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm
{
    public class AtmHandler : IRequestHandler<AtmCommand, AtmApiResponseModel>
    {
        private readonly IServiceProvider _serviceProvider;

        public AtmHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<AtmApiResponseModel> Handle(AtmCommand request,
            CancellationToken cancellationToken)
        {
            var model = new AtmApiResponseModel();
            var reqService = request.reqModel.ReqService.ToEnum<EnumAtmModuleType>();
            object? responseData = null;
            var raw = request.reqModel.ReqData.ToString()!;
            switch (reqService)
            {
                case EnumAtmModuleType.Login:
                    var login = _serviceProvider.GetRequiredService<LoginBusinessLogic>();
                    responseData = await login.Login(raw.ToObject<LoginRequestModel>()!);
                    break;
                case EnumAtmModuleType.CardHolder:
                    break;
                case EnumAtmModuleType.Deposit:
                    break;
                case EnumAtmModuleType.Withdrawal:
                    break;
                case EnumAtmModuleType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            model.Response = responseData!.ChangeResponseModel();
            model.RespData = responseData!;
            return model;
        }
    }
}
