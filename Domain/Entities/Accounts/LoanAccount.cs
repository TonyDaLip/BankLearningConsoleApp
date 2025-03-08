using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Domain.Entities.Accounts
{
    internal class LoanAccount : CapitalizableAccount
    {
        public LoanAccount(double amount, int accountID, int termInMonths, ICapitalizationStrategy strategy) : base(amount, accountID, termInMonths, strategy)
        { }

        public override void CalculateInterest(int months, double multiplier, bool GoodCreditHistory)
        {
            if (GoodCreditHistory)
            {
                multiplier *= 0.9;
            }

            Balance += _strategy.CalculateInterest(Balance, months, _totalTermInMonths, multiplier, IsTermExpired(months));
        }
    }
}
