using DotNet8MediatR.User.Features.User;

namespace DotNet8MediatR.User;

public static class UserModularService
{
    public static IServiceCollection AddUserModularService(this IServiceCollection services)
    {
        services.AddScoped<BlogDataAccess>();
        services.AddScoped<BlogBusinessLogic>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserHandler).Assembly));
        return services;
    }
}
