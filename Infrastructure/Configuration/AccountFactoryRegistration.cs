using Bank2Solution.Application.Enums;
using Bank2Solution.Application.Factories.Accounts;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Strategies;
using Bank2Solution.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution.Infrastructure.Configuration
{
    internal static class AccountFactoryRegistration
    {
        public static IServiceCollection AddAccountFactory(this IServiceCollection services)
        {
            services.AddTransient<EndOfTermCapitalization>();
            services.AddTransient<MonthlyCapitalization>();
            services.AddTransient<Func<StrategiesEnum, ICapitalizationStrategy>>(provider => strategy =>
            {
                return strategy switch
                {
                    StrategiesEnum.EndOfTerm => provider.GetRequiredService<EndOfTermCapitalization>(),
                    StrategiesEnum.Monthly => provider.GetRequiredService<MonthlyCapitalization>(),
                    _ => throw new ArgumentException("Unknown strategy type")
                };
            });

            services.AddTransient<CashAccountFactory>();
            services.AddTransient<DepositAccountFactory>();
            services.AddTransient<LoanAccountFactory>();
            services.AddTransient<Func<AccountType, IAccountFactory>>(provider => accountFactory =>
            {
                return accountFactory switch
                {
                    AccountType.Cash => provider.GetRequiredService<CashAccountFactory>(),
                    AccountType.Loan => provider.GetRequiredService<LoanAccountFactory>(),
                    AccountType.Deposit => provider.GetRequiredService<DepositAccountFactory>(),
                    _ => throw new ArgumentException("Unknown account type")
                };
            });

            services.AddTransient<AccountFactoryResolver>();

            return services;
        }
    }
}
