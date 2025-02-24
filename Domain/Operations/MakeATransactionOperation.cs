using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Interfaces;

namespace Bank2Solution.Domain.Operations
{
    internal class MakeATransactionOperation : IOperation
    {
        private Client _clientWhoSends;
        private Client _clientWhoReceives;
        private double _amount;

        public MakeATransactionOperation(Client clientWhoSends, Client clientWhoReceives, double amount)
        {
            _clientWhoSends = clientWhoSends ?? throw new ArgumentNullException(nameof(clientWhoSends));
            _clientWhoReceives = clientWhoReceives ?? throw new ArgumentNullException(nameof(clientWhoReceives));
            if (amount < 0)
                throw new ArgumentException("Amount of money should be larger than 0", nameof(amount));
            _amount = amount;
        }

        public bool IsPossible(AccountStorage accountStorage)
        {
            var account = accountStorage.FindCashAccount(_clientWhoSends);
            return account != null && account.Balance >= _amount;
        }

        public void Proceed(AccountLyfecycleManager manager, AccountFactoryResolver factory)
        {
            var accountClientWhoSends = manager.GetOrCreateCashAccount(_clientWhoSends, factory);
            var accountClientWhoReceives = manager.GetOrCreateCashAccount(_clientWhoReceives, factory);

            accountClientWhoSends.WithDraw(_amount);
            accountClientWhoReceives.Deposit(_amount);
        }
    }
}