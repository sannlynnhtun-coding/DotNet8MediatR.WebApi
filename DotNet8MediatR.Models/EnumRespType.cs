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
    CreateCardHolder,
    GetCardHolder,
    Deposit,
    Withdrawal
}

public enum EnumModuleType
{
    None,
    User,
    Atm
}
public static class AuthenticateList
{
    private static List<AuthenticateRole>? _authenticateRoles;
    public static List<AuthenticateRole> Get()
    {
        _authenticateRoles = new List<AuthenticateRole>
        {
            new AuthenticateRole(EnumModuleType.User, new List<string>{"Customer","Admin"}),
            new AuthenticateRole(EnumModuleType.Atm, new List<string>{"Customer","Admin"})
        };

        return _authenticateRoles;
    }

    public static bool IsAllow(this EnumModuleType moduleType,string role)
    {
        var result = Get()
            .FirstOrDefault(x => x.moduleType== moduleType && x.userType.Contains(role));
        return result is not null ? true : false;
    }
}
public record AuthenticateRole(EnumModuleType moduleType, List<string> userType);