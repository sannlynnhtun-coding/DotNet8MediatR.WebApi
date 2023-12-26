
using DotNet8MediatR.Atm.Features.Atm.Withdrawal;

namespace DotNet8MediatR.Atm;

public static class AtmModularService
{
    public static IServiceCollection AddAtmModularService(this IServiceCollection services)
    {
        services.AddAtmBusinessLogic();
        services.AddAtmDataAccess();
        services.AddAtmHandler();
        services.AddScoped<AuthenticateTokenService>();
        return services;
    }

    public static IServiceCollection AddAtmDataAccess(this IServiceCollection services)
    {
        services.AddScoped<LoginDataAccess>();
        services.AddScoped<CreateCardHolderDataAccess>();
        services.AddScoped<GetCardHolderDataAccess>();
        services.AddScoped<DepositDataAccess>();
        services.AddScoped<WithdrawalDataAccess>();
        return services;
    }

    public static IServiceCollection AddAtmBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<LoginBusinessLogic>();
        services.AddScoped<CreateCardHolderBusinessLogic>();
        services.AddScoped<GetCardHolderBusinessLogic>();
        services.AddScoped<DepositBusinessLogic>();
        services.AddScoped<WithdrawalBusinessLogic>();
        return services;
    }

    public static IServiceCollection AddAtmHandler(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AtmHandler).Assembly));
        return services;
    }
}
