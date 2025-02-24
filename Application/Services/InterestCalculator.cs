using Bank2Solution.Application.Managers;
using Bank2Solution.Domain.Entities.Accounts;

namespace Bank2Solution.Application.Services
{
    internal class InterestCalculator
    {
        private readonly AccountStorage _accountStorage;
        private readonly ClientManager _clientManager;

        public InterestCalculator(AccountStorage accountStorage, ClientManager clientManager)
        {
            _accountStorage = accountStorage;
            _clientManager = clientManager;
        }

        internal void PerformMonthlyCalculation(int months)
        {
            foreach (var client in _clientManager.GetClients())
            {
                var multiplier = client.GetInterestRateMultiplier();
                var creditHistory = client.GoodCreditHistory;

                foreach (var account in _accountStorage.GetClientsAccounts(client))
                {
                    if (account is CapitalizableAccount interestAccount)
                    {
                        interestAccount.CalculateInterest(months, multiplier, creditHistory);
                    }
                }
            }
        }
    }
}
