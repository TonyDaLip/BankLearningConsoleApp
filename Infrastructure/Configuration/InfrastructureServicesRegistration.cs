using Bank2Solution.Application.Interfaces;
using Bank2Solution.Infrastructure.Interfaces;
using Bank2Solution.Infrastructure.Loggers;
using Bank2Solution.Infrastructure.MockData;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution.Infrastructure.Configuration
{
    internal static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IClientProvider, MockClientProvider>();
            services.AddSingleton<IInterestRateProvider, MockInterestRateProvider>();
            services.AddSingleton<ILogger, FileLogger>();

            return services;
        }
    }
}
