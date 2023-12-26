using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Atm.Features.Atm.CardHolder.CreateCardHolder
{
    public class CreateCardHolderBusinessLogic
        (CreateCardHolderDataAccess cardHolderDataAccess)
    {
        public async Task<CardHolderResponseModel> CreateCardHolder
            (CardHolderRequestModel requestModel)
        {
            return await cardHolderDataAccess.CreateCardHolder(requestModel);
        }
    }
}
