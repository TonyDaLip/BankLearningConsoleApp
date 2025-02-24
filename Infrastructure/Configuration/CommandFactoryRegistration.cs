using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Processing;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution.Infrastructure.Configuration
{
    internal static class CommandFactoryRegistration
    {
        public static IServiceCollection AddCommandFactory(this IServiceCollection services) 
        {
            services.AddScoped<CommandFactorySelector>();

            services.Scan(scan => scan
                .FromAssemblyOf<ICommandFactory>()
                .AddClasses(classes => classes.AssignableTo<ICommandFactory>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
