namespace DotNet8MediatR.Atm.Features.Atm.CardHolder
{
    public class CardHolderDataAccess(AppDbContext appDbContext)
    {
        public async Task<CardHolderResponseModel> CreateCardHolder
        (CardHolderRequestModel requestModel)
        {
            CardHolderResponseModel model = new();
            var item = requestModel.Change();
            await appDbContext.TblAtmCards.AddAsync(item);
            int result = await appDbContext.SaveChangesAsync();
            if (result > 1)
                model.Response.Set(Codes.Success0001);
            else
                model.Response.Set(Codes.Warning0005);
            return model;
        }

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
