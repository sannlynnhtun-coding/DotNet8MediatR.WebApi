namespace DotNet8MediatR.Atm.Features.Atm.Deposit;
public class DepositDataAccess(AppDbContext appDbContext)
{
    public async Task<DepositResponseModel> CreateDeposit(DepositRequestModel requestModel)
    {
        DepositResponseModel model = new DepositResponseModel();
        var item = await appDbContext.TblAtmCards
            .FirstOrDefaultAsync(x => x.CardNumber == requestModel.CardNumber);
        if (item is null)
        {
            model.Response.Set(Codes.Warning0003);
            goto result;
        }
        model.RecentBalance = item.Balance;
        model.NewBalance = item.Balance + requestModel.Amount;
        model.Amount = requestModel.Amount;
        model.Response.Set(Codes.Success0004);

        item.Balance += requestModel.Amount;
        appDbContext.Update(item);
        await appDbContext.SaveChangesAsync();

    result:
        return model;
    }
}
