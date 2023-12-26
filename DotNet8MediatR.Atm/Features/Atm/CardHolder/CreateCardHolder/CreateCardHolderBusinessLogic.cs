namespace DotNet8MediatR.Atm.Features.Atm.CardHolder.CreateCardHolder;
public class CreateCardHolderBusinessLogic
    (CreateCardHolderDataAccess cardHolderDataAccess)
{
    public async Task<CardHolderResponseModel> CreateCardHolder
        (CardHolderRequestModel requestModel)
    {
        return await cardHolderDataAccess.CreateCardHolder(requestModel);
    }
}
