using Bank2Solution.Infrastructure.Formatters;
using Bank2Solution.Presentation.Input;
using Bank2Solution.Presentation.Interfaces;
using Bank2Solution.Presentation.Output;
using Bank2Solution.Presentation.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution.Infrastructure.Configuration
{
    internal static class PresentationServicesRegistration
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddScoped<IInfoDisplay,ConsoleInfoDisplay>();
            services.AddScoped<ClientFormatter>();
            services.AddScoped<ICommandInput, ConsoleCommandInput>();
            services.AddScoped<IOutputService, ConsoleOutputService>();

            services.AddSingleton<ClientsPanel>();
            services.AddSingleton<NotificationsPanel>();
            services.AddSingleton<ConsoleLayout>();

            return services;
        }
    }
}
