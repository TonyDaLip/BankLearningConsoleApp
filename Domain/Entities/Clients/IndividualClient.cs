namespace Bank2Solution.Domain.Entities.Clients
{
    internal class IndividualClient : Client
    {
        public IndividualClient(int id, string firstName, string lastName, bool goodCreditHistory) : base(id, firstName, lastName, goodCreditHistory)
        {
        }

        public override double GetInterestRateMultiplier() => 1.0;
    }
}
