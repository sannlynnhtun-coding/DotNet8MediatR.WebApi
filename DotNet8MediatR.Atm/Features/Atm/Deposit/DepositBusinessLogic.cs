namespace DotNet8MediatR.Atm.Features.Atm.Deposit;
public class DepositBusinessLogic
    (DepositDataAccess depositDataAccess)
{
    public async Task<DepositResponseModel> CreateDeposit(DepositRequestModel requestModel)
    {
        return await depositDataAccess.CreateDeposit(requestModel);
    }
}
