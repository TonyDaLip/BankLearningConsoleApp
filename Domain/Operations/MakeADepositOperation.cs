using Bank2Solution.Application.Enums;
using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Interfaces;
using Bank2Solution.Domain.Enums;
using Bank2Solution.Application.Services;

namespace Bank2Solution.Domain.Operations
{
    internal class MakeADepositOperation : IOperation
    {
        private readonly Client _client;        
        private readonly StrategiesEnum _strategy;
        private double _amount;
        private int _termInMonths;

        public MakeADepositOperation(Client client, double amount, StrategiesEnum strategy, int termInMonths)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            if (amount < 0)
                throw new ArgumentException("Amount of money should be larger than 0", nameof(amount));
            _amount = amount;
            _strategy = strategy;
            _termInMonths = termInMonths;
        }

        public bool IsPossible(AccountStorage accountStorage)
        {
            var account = accountStorage.FindCashAccount(_client);
            return account != null && account.Balance >= _amount;
        }

        public void Proceed(AccountLyfecycleManager manager, AccountFactoryResolver factory)
        {
            var cashAccount = manager.GetOrCreateCashAccount(_client, factory);
            cashAccount.WithDraw(_amount);

            var depositAccount = factory.CreateAccount(
                AccountType.Deposit,
                _strategy,
                _amount,
                manager.LastAccountId + 1,
                _termInMonths
                );

            manager.OpenAccount(_client, depositAccount);
        }
    }
}
