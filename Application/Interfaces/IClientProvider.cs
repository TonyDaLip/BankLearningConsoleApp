using Bank2Solution.Domain.Entities.Clients;

namespace Bank2Solution.Application.Interfaces
{
    internal interface IClientProvider
    {
        List<Client> GetClients();
    }
}
