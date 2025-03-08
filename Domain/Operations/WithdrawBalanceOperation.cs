using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Interfaces;

namespace Bank2Solution.Domain.Operations
{
    internal class WithdrawBalanceOperation : IOperation
    {
        private readonly Client _client;
        private readonly double _amount;

        public WithdrawBalanceOperation(Client client, double amount)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            if (amount < 0)
            {
                throw new ArgumentException("Amount of money should be larger than 0", nameof(amount));
            }

            _amount = amount;
        }

        public bool IsPossible(AccountStorage accountStorage)
        {
            var account = accountStorage.FindCashAccount(_client);
            return account != null && account.Balance >= _amount;
        }

        public void Proceed(AccountLyfecycleManager manager, AccountFactoryResolver factory)
        {
            var account = manager.GetOrCreateCashAccount(_client, factory);
            account.WithDraw(_amount);
        }
    }
}
