using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Entities.Accounts;
using Bank2Solution.Domain.Entities.Clients;
using System.Text;

namespace Bank2Solution.Infrastructure.Formatters
{
    internal class ClientFormatter
    {
        private readonly AccountStorage _accountStorage;

        public ClientFormatter(AccountStorage accountStorage)
        {
            _accountStorage = accountStorage;
        }

        public string FormatClient(Client client)
        {
            var builder = new StringBuilder();
            builder.Append($"ID: {client.Id}, {client.FirstName} {client.LastName}. Accounts:");

            foreach (var account in _accountStorage.GetClientsAccounts(client))
            {
                builder.AppendLine();
                builder.Append($"  ID: {account.AccountID}; {account.GetType().Name}; Balance: {account.Balance: #.##}");
                if (account is CapitalizableAccount capitalizableAccount)
                {
                    builder.Append($"; {capitalizableAccount.TermInMonths} months");
                }                    
            }

            return builder.ToString();
        }

        public IEnumerable<string> FormatClients(IEnumerable<Client> clients)
        {
            return clients.Select(c => FormatClient(c));
        }
    }
}
