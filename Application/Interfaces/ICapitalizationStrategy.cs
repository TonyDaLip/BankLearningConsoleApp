namespace Bank2Solution.Application.Interfaces
{
    internal interface ICapitalizationStrategy
    {
        double CalculateInterest(double balance, int termInMonths, int totalTermInMonths, double multiplier, bool isTermExpired = false);
    }
}
