namespace DotNet8MediatR.Atm.Features.Atm.CardHolder
{
    public class CardHolderBusinessLogic
        (CardHolderDataAccess cardHolderDataAccess)
    {
        public async Task<CardHolderResponseModel> GetCardHolder
        (CardHolderRequestModel requestModel)
        {
            return await cardHolderDataAccess.GetCardHolder(requestModel);
        }
        public async Task<CardHolderResponseModel> CreateCardHolder
        (CardHolderRequestModel requestModel)
        {
            return await cardHolderDataAccess.CreateCardHolder(requestModel);
        }
    }
}
