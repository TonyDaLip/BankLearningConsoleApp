using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Entities.Accounts;
using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Interfaces;

namespace Bank2Solution.Domain.Operations
{
    internal class CloseLoanAccountOperation : IOperation
    {
        private readonly Client _client;
        private readonly LoanAccount _account;

        public CloseLoanAccountOperation(Client client, LoanAccount account)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _account = account ?? throw new ArgumentNullException(nameof(account));
        }

        public bool IsPossible(AccountStorage accountStorage)
        {
            return accountStorage.GetClientsAccounts(_client).Contains(_account);
        }

        public void Proceed(AccountLyfecycleManager manager, AccountFactoryResolver factory)
        {
            var cashAccount = manager.GetOrCreateCashAccount(_client, factory);
            cashAccount.WithDraw(_account.Balance);
            manager.CloseAccount(_client, _account);
        }
    }
}
