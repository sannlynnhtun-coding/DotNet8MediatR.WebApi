using DotNet8MediatR.Atm.Features.Atm;

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

    public static IServiceCollection AddAtmBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<LoginDataAccess>();
        return services;
    }

    public static IServiceCollection AddAtmDataAccess(this IServiceCollection services)
    {
        services.AddScoped<LoginBusinessLogic>();
        return services;
    }

    public static IServiceCollection AddAtmHandler(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AtmHandler).Assembly));
        return services;
    }
}
