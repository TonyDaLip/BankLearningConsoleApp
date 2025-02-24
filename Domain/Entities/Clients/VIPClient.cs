namespace Bank2Solution.Domain.Entities.Clients
{
    internal class VIPClient : Client
    {
        public VIPClient(int id, string firstName, string lastName, bool goodCreditHistory) : base(id, firstName, lastName, goodCreditHistory)
        {
        }

        public override double GetInterestRateMultiplier() => 0.8;
    }
}
