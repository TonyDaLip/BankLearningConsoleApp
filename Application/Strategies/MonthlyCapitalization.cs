using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Application.Strategies
{
    internal class MonthlyCapitalization : ICapitalizationStrategy
    {
        private readonly IInterestRateProvider _interestRateProvider;

        public MonthlyCapitalization(IInterestRateProvider interestRateProvider)
        {
            _interestRateProvider = interestRateProvider;
        }

        public double CalculateInterest(double balance, int termInMonths, int totalTermInMonths, double multiplier, bool isTermExpired = false)
        {
            var interestRate = _interestRateProvider.GetInterestRate();

            double total = balance * Math.Pow(1 + interestRate * multiplier / 12, termInMonths);
            return total - balance;
        }
    }
}
