namespace Bank2Solution.Domain.Entities.Clients
{
    internal class BusinessClient : Client
    {
        public BusinessClient(int id, string firstName, string lastName, bool goodCreditHistory) : base(id, firstName, lastName, goodCreditHistory)
        {
        }

        public override double GetInterestRateMultiplier() => 1.2;
    }
}
