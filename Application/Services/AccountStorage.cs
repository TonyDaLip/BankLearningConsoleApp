using Bank2Solution.Domain.Entities.Accounts;
using Bank2Solution.Domain.Entities.Clients;

namespace Bank2Solution.Application.Services
{
    internal class AccountStorage
    {
        private readonly Dictionary<Client, List<BaseAccount>> _clientAccounts = new Dictionary<Client, List<BaseAccount>>();

        internal void AddAccount(Client client, BaseAccount account)
        {
            if (!_clientAccounts.ContainsKey(client))
            {
                _clientAccounts.Add(client, new List<BaseAccount>());
            }

            if (_clientAccounts[client].Contains(account))
            {
                throw new InvalidOperationException("Account already exists in the collection");
            }

            _clientAccounts[client].Add(account);
        }

        internal void RemoveAccount(Client client, BaseAccount account)
        {
            if (!_clientAccounts.ContainsKey(client))
            {
                throw new InvalidOperationException("Client doesn't exist in the system");
            }

            if (!_clientAccounts[client].Contains(account))
            {
                throw new InvalidOperationException("Client doesn't have this account");
            }

            _clientAccounts[client].Remove(account);
        }

        public IEnumerable<BaseAccount> GetAllAccounts()
        {
            return _clientAccounts.Values.SelectMany(account => account);
        }

        public IEnumerable<BaseAccount> GetClientsAccounts(Client client)
        {
            return _clientAccounts.ContainsKey(client) ? _clientAccounts[client].AsReadOnly() : Enumerable.Empty<BaseAccount>();
        }

        public Client GetClientByAccount(BaseAccount account)
        {
            return _clientAccounts.FirstOrDefault(pair => pair.Value.Contains(account)).Key 
                ?? throw new InvalidOperationException("Client not found for account");
        }

        public CashAccount? FindCashAccount(Client client)
        {
            return GetClientsAccounts(client).FirstOrDefault(x => x is CashAccount) as CashAccount;
        }
    }
}
