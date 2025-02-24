using Bank2Solution.Application.Enums;
using Bank2Solution.Application.Events;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Entities.Accounts;
using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Enums;
using Bank2Solution.Domain.Interfaces;
using Bank2Solution.Domain.Operations;
using Bank2Solution.Infrastructure.Interfaces;

namespace Bank2Solution.Application.Managers
{
    internal class AccountLyfecycleManager
    {
        private readonly AccountStorage _storage;
        private readonly IEventAggregator _eventAggregator;

        public AccountLyfecycleManager(AccountStorage storage, IEventAggregator eventAggregator)
        {
            _storage = storage;
            _eventAggregator = eventAggregator;
        }

        public int LastAccountId { get; private set; } = 0;

        public void OpenAccount(Client client, BaseAccount account)
        {
            LastAccountId++;
            _storage.AddAccount(client, account);

            _eventAggregator.Publish(new AccountOpenedEvent(client, account));
        }

        public void CloseAccount(Client client, BaseAccount account)
        {
            _storage.RemoveAccount(client, account);

            _eventAggregator.Publish(new AccountClosedEvent(client, account));
        }

        public void ProcessAccountLifecycle(OperationProcessor operationProcessor)
        {
            foreach (var account in GetAccountsToClose())
            {
                var client = _storage.GetClientByAccount(account);
                var operation = CloseAccountOperation(client, account);

                operationProcessor.TryProceedOperation(operation);
            }
        }

        public CashAccount GetOrCreateCashAccount(Client client, AccountFactoryResolver factory)
        {
            var cashAccount = _storage.FindCashAccount(client);

            if (cashAccount == null)
            {
                cashAccount = factory.CreateAccount(AccountType.Cash, StrategiesEnum.EndOfTerm, initialBalance: 0, LastAccountId + 1) as CashAccount;
                OpenAccount(client, cashAccount);
            }

            return cashAccount;
        }

        private IOperation CloseAccountOperation(Client client, BaseAccount account)
        {
            IOperation operation = account switch
            {
                DepositAccount depositAccount => new CloseDepositAccountOperation(client, depositAccount),
                LoanAccount loanAccount => new CloseLoanAccountOperation(client, loanAccount),
                _ => throw new InvalidOperationException("Unsupported account type")
            };

            return operation;
        }

        private IEnumerable<BaseAccount> GetAccountsToClose()
        {
            var accountsToClose = new List<BaseAccount>();

            foreach (var account in _storage.GetAllAccounts())
            {
                if (account is CapitalizableAccount interestAccount && interestAccount.TermInMonths <= 0)
                    accountsToClose.Add(account);
            }

            return accountsToClose;
        }
    }
}
