namespace DotNet8MediatR.WebApi
{
    public static class MediatRModularService
    {
        public static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            return services;
        }
    }
}
