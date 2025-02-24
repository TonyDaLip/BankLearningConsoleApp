using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Accounts;

namespace Bank2Solution.Application.Factories.Accounts
{
    internal class CashAccountFactory : IAccountFactory
    {
        public BaseAccount CreateAccount(double initialBalance, int accountID, ICapitalizationStrategy strategy = null, int termInMonths = 0)
        {
            return new CashAccount(initialBalance, accountID);
        }
    }
}
