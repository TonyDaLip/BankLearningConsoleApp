using Bank2Solution.Application.Commands;
using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Domain.Operations;
using Bank2Solution.Infrastructure.Converters;

namespace Bank2Solution.Application.Factories.Commands
{
    internal class WithdrawBalanceCommandFactory : ICommandFactory
    {
        private readonly OperationProcessor _operationProcessor;
        private readonly ClientManager _clientManager;

        public WithdrawBalanceCommandFactory(OperationProcessor operationProcessor, ClientManager clientManager)
        {
            _operationProcessor = operationProcessor;
            _clientManager = clientManager;
        }

        public string CommandName => "WithdrawBalance";

        public IEnumerable<CommandParameters> Parameters => new[]
        {
            new CommandParameters("ClientId", typeof(int)),
            new CommandParameters("Amount", typeof(double))
        };

        public ICommand Create(Request request)
        {
            if (request.IsIncorrectValuesCount(2))
            {
                throw new ArgumentException($"Incorrect number of values for {CommandName}");
            }

            var clientId = InputConverter<int>.Convert(request.Values[0]);
            var client = _clientManager.GetClientFromId(clientId);

            var amount = InputConverter<double>.Convert(request.Values[1]);

            return new OperationCommand<WithdrawBalanceOperation>(_operationProcessor, new WithdrawBalanceOperation(client, amount));
        }
    }
}
