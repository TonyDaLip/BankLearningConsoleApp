using Bank2Solution.Application.Commands;
using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Managers;
using Bank2Solution.Domain.Enums;
using Bank2Solution.Infrastructure.Converters;

namespace Bank2Solution.Application.Factories.Commands
{
    internal class AddClientCommandFactory : ICommandFactory
    {
        private readonly ClientManager _clientManager;
        private readonly IClientFactory _clientFactory;

        public AddClientCommandFactory(ClientManager clientManager, IClientFactory clientFactory)
        {
            _clientManager = clientManager;
            _clientFactory = clientFactory;
        }

        public string CommandName => "AddClient";

        public IEnumerable<CommandParameters> Parameters => new[]
        {
            new CommandParameters("Name", typeof(string)),
            new CommandParameters("LastName", typeof(string)),
            new CommandParameters("ClientType", typeof(ClientType), "Individual", "VIP", "Business"),
            new CommandParameters("CreditHistory", typeof(bool))
        };

        public ICommand Create(Request request)
        {
            if (request.IsIncorrectValuesCount(4))
                throw new ArgumentException($"Incorrect number of values for {CommandName}");

            var name = InputConverter<string>.Convert(request.Values[0]);
            var lastName = InputConverter<string>.Convert(request.Values[1]);
            var clientType = EnumConverter.TryConvertEnum<ClientType>(request.Values[2]);
            var isCreditHistoryGood = InputConverter<bool>.Convert(request.Values[3]);


            return new AddClientCommand(_clientManager, _clientFactory, clientType, name, lastName, isCreditHistoryGood);
        }
    }
}
