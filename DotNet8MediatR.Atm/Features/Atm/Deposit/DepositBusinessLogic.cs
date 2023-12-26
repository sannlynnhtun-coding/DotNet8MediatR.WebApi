using DotNet8MediatR.Models.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.Deposit
{
    public class DepositBusinessLogic
        (DepositDataAccess depositDataAccess)
    {
        public async Task<DepositResponseModel> CreateDeposit(DepositRequestModel requestModel)
        {
            return await depositDataAccess.CreateDeposit(requestModel);
        }
    }
}
