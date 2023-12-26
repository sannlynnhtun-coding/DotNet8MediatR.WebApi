using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.CardHolder.GetCardHolder
{
    public class GetCardHolderBusinessLogic
        (GetCardHolderDataAccess getCardHolderDataAccess)
    {
        public async Task<CardHolderResponseModel> GetCardHolder
            (CardHolderRequestModel requestModel)
        {
            return await getCardHolderDataAccess.GetCardHolder(requestModel);
        }
    }
}
