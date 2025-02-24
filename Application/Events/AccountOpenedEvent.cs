using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Entities.Accounts;
using Bank2Solution.Domain.Entities.Clients;

namespace Bank2Solution.Application.Events
{
    internal class AccountOpenedEvent : IEvent
    {      
        public AccountOpenedEvent(Client client, BaseAccount account) 
        {
            Client = client;
            Account = account;
        }

        public Client Client { get; }
        public BaseAccount Account { get; }

        public DateTime TimeStamp => DateTime.UtcNow;
    }
}
