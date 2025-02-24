using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Managers;
using Bank2Solution.Domain.Enums;

namespace Bank2Solution.Application.Commands
{
    internal class AddClientCommand : ICommand
    {
        private readonly ClientManager _manager;
        private readonly IClientFactory _factory;
        private ClientType _clientType;
        private string _clientName;
        private string _clientLastName;
        private bool _creditHistory;

        public AddClientCommand(ClientManager manager, IClientFactory factory, ClientType type, string firstName, string lastName, bool goodCreditHistory = true) 
        {
            _manager = manager;
            _factory = factory;
            _clientType = type;
            _clientName = firstName;
            _clientLastName = lastName;
            _creditHistory = goodCreditHistory;
        }

        public void Execute()
        {
            var client = _factory.CreateClient(
                _clientType,
                _manager.LastClientId + 1,
                _clientName,
                _clientLastName,
                _creditHistory
            );

            _manager.AddClient(client);
            _manager.ChangeDepartment(_clientType);
        }
    }
}
