using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Enums;

namespace Bank2Solution.Application.Factories.Clients
{
    internal class ClientFactory : IClientFactory
    {
        public Client CreateClient(ClientType clientType, int clientId, string firstName, string lastName, bool goodCreditHistory = true)
        {
            return clientType switch
            {
                ClientType.Individual => new IndividualClient(clientId, firstName, lastName, goodCreditHistory),
                ClientType.Business => new BusinessClient(clientId, firstName, lastName, goodCreditHistory),
                ClientType.VIP => new VIPClient(clientId, firstName, lastName, goodCreditHistory),
                _ => throw new ArgumentException("Invalid client type", nameof(clientType))
            };
        }
    }
}
