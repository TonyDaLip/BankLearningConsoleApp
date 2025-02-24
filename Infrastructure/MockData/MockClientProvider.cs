using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Clients;

namespace Bank2Solution.Infrastructure.MockData
{
    internal class MockClientProvider : IClientProvider
    {
        public List<Client> GetClients()
        {
            return new List<Client>
            {
                new IndividualClient(1, "First", "Client", true),
                new IndividualClient(2, "Second", "Client", false),
                new BusinessClient(3, "Third", "Client", true),
                new VIPClient(4, "Forth", "Client", false)
            };
        }
    }
}
