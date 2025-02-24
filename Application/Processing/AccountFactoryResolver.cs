using Bank2Solution.Application.Enums;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Accounts;
using Bank2Solution.Domain.Enums;

namespace Bank2Solution.Application.Processing
{
    internal class AccountFactoryResolver
    {
        private readonly Func<AccountType, IAccountFactory> _accountFactoryResolver;
        private readonly Func<StrategiesEnum, ICapitalizationStrategy> _strategyResolver;

        public AccountFactoryResolver(Func<AccountType, IAccountFactory> accountFactoryResolver, Func<StrategiesEnum, ICapitalizationStrategy> strategyResolver)
        {
            _accountFactoryResolver = accountFactoryResolver;
            _strategyResolver = strategyResolver;
        }

        public BaseAccount CreateAccount(AccountType accountType, StrategiesEnum strategy, double initialBalance, int accountID, int termInMonths = 0)
        {
            var accountFactory = _accountFactoryResolver(accountType);
            var capitalizationStrategy = _strategyResolver(strategy);

            return accountFactory.CreateAccount(initialBalance, accountID, capitalizationStrategy, termInMonths);
        }
    }    
}
