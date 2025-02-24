using Bank2Solution.Domain.Entities.Accounts;

namespace Bank2Solution.Application.Interfaces
{
    internal interface IAccountFactory
    {
        BaseAccount CreateAccount(double initialBalance, int accountID, ICapitalizationStrategy strategy, int termInMonths = 0);
    }
}
