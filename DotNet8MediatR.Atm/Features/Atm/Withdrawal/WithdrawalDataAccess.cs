namespace DotNet8MediatR.Atm.Features.Atm.Withdrawal;
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

        item.Balance -= requestModel.Amount;
        appDbContext.Update(item);
        await appDbContext.SaveChangesAsync();

        model.Response.Set(Codes.Success0003);
    result:
        return model;
    }
}
