namespace DotNet8MediatR.WebApi
{
    public static class HandlerModularService
    {
        public static IServiceCollection AddHandlerModularService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AtmHandler).Assembly));

            return services;
        }
    }
}
