using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Clients;

namespace Bank2Solution.Application.Events
{
    internal class NewClientAddedEvent : IEvent
    {
        public NewClientAddedEvent(Client client) 
        {
            Client = client;
        }

        public Client Client { get; }

        public DateTime TimeStamp => DateTime.UtcNow;
    }
}
