using FalzoniNetApi.Infra.IoC.Enum;
using Microsoft.Extensions.DependencyInjection;

namespace FalzoniNetApi.Infra.IoC.Services
{
    public class DependencyService<T> where T : class
    {

        public static T GetRequiredService(EServiceType type)
        {
            IServiceProvider provider = GetProvider(type);
            return provider.GetRequiredService<T>();
        }

        private static IServiceProvider GetProvider(EServiceType type)
        {
            ServiceCollection services = new ServiceCollection();

            switch(type)
            {
                case EServiceType.OnlyContext:
                    services.AddDatabaseConfiguration(ServiceLifetime.Scoped);
                    break;

                case EServiceType.Repository:
                    services.AddDatabaseConfiguration(ServiceLifetime.Scoped);
                    services.AddRepositories();
                    break;

                case EServiceType.Identity:
                    services.AddDatabaseConfiguration(ServiceLifetime.Transient);
                    services.AddIdentityConfiguration();
                    services.AddAuthenticationConfiguration();
                    break;

                case EServiceType.Service:
                    services.AddServices();
                    services.AddUnitOfWork();
                    break;
            }

            return services.BuildServiceProvider();
        }
    }
}
