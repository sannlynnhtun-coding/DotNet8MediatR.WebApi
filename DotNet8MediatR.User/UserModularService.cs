using DotNet8MediatR.User.Features.User;

namespace DotNet8MediatR.User;

public static class UserModularService
{
    public static IServiceCollection AddUserModularService(this IServiceCollection services)
    {
        services.AddUserDataAccess();
        services.AddUserBusinessLogic();
        services.AddUserHandler();
        return services;
    }

    public static IServiceCollection AddUserBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<BlogDataAccess>();
        return services;
    }

    public static IServiceCollection AddUserDataAccess(this IServiceCollection services)
    {
        services.AddScoped<BlogBusinessLogic>();
        return services;
    }

    public static IServiceCollection AddUserHandler(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserHandler).Assembly));
        return services;
    }
}
