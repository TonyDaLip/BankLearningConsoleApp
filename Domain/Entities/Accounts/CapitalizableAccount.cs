using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Domain.Entities.Accounts
{
    internal abstract class CapitalizableAccount : BaseAccount
    {
        protected readonly ICapitalizationStrategy _strategy;
        protected int _totalTermInMonths;

        public CapitalizableAccount(double amount, int accountID, int termInMonths, ICapitalizationStrategy strategy) : base(amount, accountID)
        {
            _strategy = strategy;
            _totalTermInMonths = termInMonths;
            TermInMonths = termInMonths;
        }

        public int TermInMonths { get; private set; }

        public abstract void CalculateInterest(int months, double multiplier, bool GoodCreditHistory);

        protected bool IsTermExpired(int months)
        {
            TermInMonths -= months;
            return TermInMonths <= 0;
        }
    }
}
