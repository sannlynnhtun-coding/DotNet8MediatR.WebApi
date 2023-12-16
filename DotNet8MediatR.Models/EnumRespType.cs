namespace DotNet8MediatR.Models;

public enum EnumRespType
{
    None,
    Success,
    Information,
    Warning,
    Error,
    Confirm
}

public enum EnumUserModuleType
{
    None,
    BlogList,
    BlogEdit,
    BlogCreate,
    BlogUpdate,
    BlogDelete
}

public enum EnumAtmModuleType
{
    None,
    Login,
    CardHolder,
    Deposit,
    Withdrawal
}

public enum EnumModuleType
{
    None,
    User,
    Atm
}
