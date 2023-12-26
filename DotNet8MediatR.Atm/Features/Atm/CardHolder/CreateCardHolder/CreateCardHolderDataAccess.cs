namespace DotNet8MediatR.Atm.Features.Atm.CardHolder.CreateCardHolder;

public class CreateCardHolderDataAccess(AppDbContext appDbContext)
{
    public async Task<CardHolderResponseModel> CreateCardHolder
        (CardHolderRequestModel requestModel)
    {
        CardHolderResponseModel model = new();
        var item = requestModel.Change();
        await appDbContext.AddAsync(item);
        await appDbContext.SaveChangesAsync();
        model.Response.Set(Codes.Success0001);
        return model;
    }
}
