using DotNet8MediatR.Atm.Features.Atm.CardHolder.CreateCardHolder;
using DotNet8MediatR.Atm.Features.Atm.Login;
using DotNet8MediatR.Atm.Features.Atm.Withdrawal;
using DotNet8MediatR.Models.Atm;
using DotNet8MediatR.Models.Deposit;
using DotNet8MediatR.Models.Withdrawal;
using DotNet8MediatR.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm
{
    public class AtmHandler(IServiceProvider serviceProvider) : IRequestHandler<AtmCommand, AtmApiResponseModel>
    {
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
                    var login = serviceProvider.GetRequiredService<LoginBusinessLogic>();
                    responseData = await login.Login(raw.ToObject<LoginRequestModel>()!);
                    break;
                case EnumAtmModuleType.CreateCardHolder:
                    var createCardHolder = serviceProvider.GetRequiredService<CreateCardHolderBusinessLogic>();
                    responseData = await createCardHolder.CreateCardHolder(raw.ToObject<CardHolderRequestModel>()!);
                    break;
                case EnumAtmModuleType.GetCardHolder:
                    var getCardHolder = serviceProvider.GetRequiredService<GetCardHolderBusinessLogic>();
                    responseData = await getCardHolder.GetCardHolder(raw.ToObject<CardHolderRequestModel>()!);
                    break;
                case EnumAtmModuleType.Deposit:
                    var deposit = serviceProvider.GetRequiredService<DepositBusinessLogic>();
                    responseData = await deposit.CreateDeposit(raw.ToObject<DepositRequestModel>()!);
                    break;
                case EnumAtmModuleType.Withdrawal:
                    var withdrawal = serviceProvider.GetRequiredService<WithdrawalBusinessLogic>();
                    responseData = await withdrawal.CreateWithdrawal(raw.ToObject<WithdrawalRequestModel>()!);
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
