using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Enums;

namespace Bank2Solution.Application.Interfaces
{
    internal interface IClientFactory
    {
        Client CreateClient(ClientType clientType, int clientId, string firstName, string lastName, bool goodCreditHistory);
    }
}
