using Bank2Solution.Application.Events;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Clients;
using Bank2Solution.Domain.Enums;
using Bank2Solution.Infrastructure.Interfaces;

namespace Bank2Solution.Application.Managers
{
    internal class ClientManager
    {
        private readonly List<Client> _clients = new List<Client>();
        private List<Client> _clientsOfCurrentDepartment;

        private readonly IEventAggregator _eventAggregator;

        public ClientManager(IClientProvider clientProvider, IEventAggregator eventAggregator)
        {
            _clients = clientProvider.GetClients();
            LastClientId = _clients.Count();
            _clientsOfCurrentDepartment = _clients.FindAll(client => client.GetType() == typeof(IndividualClient));
            _eventAggregator = eventAggregator;
        }

        public int LastClientId { get; private set; }

        public void ChangeDepartment(ClientType newDepartment)
        {
            _clientsOfCurrentDepartment =
                newDepartment switch
                {
                    ClientType.Individual => _clients.FindAll(client => client.GetType() == typeof(IndividualClient)),
                    ClientType.Business => _clients.FindAll(client => client.GetType() == typeof(BusinessClient)),
                    ClientType.VIP => _clients.FindAll(client => client.GetType() == typeof(VIPClient)),
                    _ => Enumerable.Empty<Client>().ToList()
                };
        }

        public IEnumerable<Client> GetClientsForCurrentDepartment()
        {
            return _clientsOfCurrentDepartment.AsReadOnly();
        }

        public IEnumerable<Client> GetClients()
        {
            return _clients.AsReadOnly();
        }

        public Client GetClientFromId(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public void AddClient(Client client)
        {
            if (_clients.Contains(client))
            {
                throw new InvalidOperationException("Client already exists in the collection");
            }

            _clients.Add(client);
            LastClientId++;
            _eventAggregator.Publish(new NewClientAddedEvent(client));
        }
    }
}
