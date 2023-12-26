namespace DotNet8MediatR.Atm.Features.Atm.Withdrawal;
public class WithdrawalBusinessLogic
    (WithdrawalDataAccess withdrawalDataAccess)
{
    public async Task<WithdrawalResponseModel> CreateWithdrawal(
       WithdrawalRequestModel requestModel)
    {
        return await withdrawalDataAccess.CreateWithdrawal(requestModel);
    }
}
