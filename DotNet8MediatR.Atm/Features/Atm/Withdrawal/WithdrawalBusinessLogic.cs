using DotNet8MediatR.Models.Withdrawal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.Withdrawal
{
    public class WithdrawalBusinessLogic
        (WithdrawalDataAccess withdrawalDataAccess)
    {
        public async Task<WithdrawalResponseModel> CreateWithdrawal(
           WithdrawalRequestModel requestModel)
        {
            return await withdrawalDataAccess.CreateWithdrawal(requestModel);
        }
    }
}
