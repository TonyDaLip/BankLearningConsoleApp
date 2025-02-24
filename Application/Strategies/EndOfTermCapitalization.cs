using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Application.Strategies
{
    internal class EndOfTermCapitalization : ICapitalizationStrategy
    {
        private readonly IInterestRateProvider _interestRateProvider;

        public EndOfTermCapitalization(IInterestRateProvider interestRateProvider)
        {
            _interestRateProvider = interestRateProvider;
        }
        public double CalculateInterest(double balance, int termInMonths, int totalTermInMonths, double multiplier, bool isTermExpired = false)
        {
            var interestRate = _interestRateProvider.GetInterestRate();
            if (isTermExpired)
                return balance * interestRate * multiplier * totalTermInMonths / 12;

            return 0;
        }
    }
}
