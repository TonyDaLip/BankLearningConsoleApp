using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Domain.Entities.Accounts
{
    internal class DepositAccount : CapitalizableAccount
    {
        public DepositAccount(double amount, int accountID, int termInMonths, ICapitalizationStrategy strategy) : base(amount, accountID, termInMonths, strategy)
        { }

        public override void CalculateInterest(int months, double multiplier, bool GoodCreditHistory)
        {
            if (GoodCreditHistory)
                multiplier *= 1.1;

            Balance += _strategy.CalculateInterest(Balance, months, _totalTermInMonths, multiplier, IsTermExpired(months));
        }
    }
}
