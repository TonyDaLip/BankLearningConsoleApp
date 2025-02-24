using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Infrastructure.MockData
{
    internal class MockInterestRateProvider : IInterestRateProvider
    {
        public double GetInterestRate()
        {
            return 0.10;
        }
    }
}
