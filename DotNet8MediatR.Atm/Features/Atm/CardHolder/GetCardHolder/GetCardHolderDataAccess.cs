using DotNet8MediatR.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.CardHolder.GetCardHolder
{
    public class GetCardHolderDataAccess
        (AppDbContext appDbContext)
    {
        public async Task<CardHolderResponseModel> GetCardHolder
            (CardHolderRequestModel requestModel)
        {
            CardHolderResponseModel model = new();
            var item = await appDbContext.TblAtmCards.FirstOrDefaultAsync(x => x.CardNumber == requestModel.CardNumber);
            if (item is null)
            {
                model.Response.Set(Codes.Warning0003);
                goto result;
            }

            model.CardNumberId = item.CardNumberId;
            model.UserName = item.UserName;
            model.UserRoles = item.GetRoles();
            model.Balance = item.Balance;

            model.Response.Set(Codes.Success0001);
        result:
            return model;
        }
    }
}
