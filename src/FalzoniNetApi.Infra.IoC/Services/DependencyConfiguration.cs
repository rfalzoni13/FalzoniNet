using Microsoft.Extensions.DependencyInjection;

namespace FalzoniNetApi.Infra.IoC.Services
{
    public static class DependencyConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDatabaseConfiguration(ServiceLifetime.Scoped);

            services.AddIdentityConfiguration();

            services.AddAuthenticationConfiguration();

            // Unit of Work
            services.AddUnitOfWork();

            // Repositories
            services.AddRepositories();

            // Services
            services.AddServices();
        }
    }
}
