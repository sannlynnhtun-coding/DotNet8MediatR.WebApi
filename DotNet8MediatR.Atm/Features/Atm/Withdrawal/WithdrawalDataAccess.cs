using DotNet8MediatR.Db;
using DotNet8MediatR.Models.Withdrawal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.Withdrawal
{
    public class WithdrawalDataAccess(AppDbContext appDbContext)
    {
        public async Task<WithdrawalResponseModel> CreateWithdrawal(
           WithdrawalRequestModel requestModel)
        {
            WithdrawalResponseModel model = new();
            var item = await appDbContext.TblAtmCards
                .FirstOrDefaultAsync(x => x.CardNumber == requestModel.CardNumber);
            if (item is null)
            {
                model.Response.Set(Codes.Warning0003);
                goto result;
            }
            model.RecentBalance = item.Balance;
            model.NewBalance = item.Balance - requestModel.Amount;
            model.Amount = requestModel.Amount;
            model.Response.Set(Codes.Success0003);

            item.Balance = item.Balance - requestModel.Amount;
            appDbContext.Update(item);
            await appDbContext.SaveChangesAsync();

        result:
            return model;
        }
    }
}
