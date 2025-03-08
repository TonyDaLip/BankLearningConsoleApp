namespace Bank2Solution.Domain.Entities.Clients
{
    internal abstract class Client
    {
        protected Client(int id, string firstName, string lastName, bool goodCreditHistory = true)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            GoodCreditHistory = goodCreditHistory;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool GoodCreditHistory { get; private set; }

        public abstract double GetInterestRateMultiplier();

        public override bool Equals(object? obj)
        {
            if (obj is Client client)
            {
                return Id == client.Id;
            }

            return false;
        }
    }
}
