using Bank2Solution.Application.Factories.Clients;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Presentation;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution.Infrastructure.Configuration
{
    internal static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<CommandParser>();
            services.AddSingleton<CommandHandler>();
            services.AddSingleton<AccountLyfecycleManager>();
            services.AddSingleton<AccountStorage>();
            services.AddSingleton<ClientManager>();
            services.AddSingleton<InterestCalculator>();
            services.AddSingleton<TimeManager>();
            services.AddSingleton<OperationProcessor>();
            services.AddSingleton<BankService>();
            services.AddSingleton<IClientFactory, ClientFactory>();
            services.AddScoped<ClientsPresenter>();
            services.AddScoped<NotificationsPresenter>();
            services.AddScoped<CommandsPresenter>();

            return services;
        }
    }
}
