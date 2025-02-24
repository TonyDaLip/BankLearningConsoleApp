using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Accounts;

namespace Bank2Solution.Application.Factories.Accounts
{
    internal class DepositAccountFactory : IAccountFactory
    {
        public BaseAccount CreateAccount(double initialBalance, int accountID, ICapitalizationStrategy strategy, int termInMonths = 0)
        {
            return new DepositAccount(initialBalance, accountID, termInMonths, strategy);
        }
    }
}
