using Bank2Solution.Application.Commands;
using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Domain.Operations;
using Bank2Solution.Infrastructure.Converters;

namespace Bank2Solution.Application.Factories.Commands
{
    internal class MakeATransactionCommandFactory : ICommandFactory
    {
        private readonly OperationProcessor _operationProcessor;
        private readonly ClientManager _clientManager;

        public MakeATransactionCommandFactory(OperationProcessor operationProcessor, ClientManager clientManager)
        {
            _operationProcessor = operationProcessor;
            _clientManager = clientManager;
        }

        public string CommandName => "MakeATransaction";

        public IEnumerable<CommandParameters> Parameters => new[]
        {
            new CommandParameters("SenderId", typeof(int)),
            new CommandParameters("ReceiverId", typeof (int)),
            new CommandParameters("Amount", typeof(double))
        };

        public ICommand Create(Request request)
        {
            if (request.IsIncorrectValuesCount(3))
                throw new ArgumentException($"Incorrect number of values for {CommandName}");

            var senderId = InputConverter<int>.Convert(request.Values[0]);
            var sender = _clientManager.GetClientFromId(senderId);

            var ReceiverId = InputConverter<int>.Convert(request.Values[1]);
            var Receiver = _clientManager.GetClientFromId(ReceiverId);

            var amount = InputConverter<double>.Convert(request.Values[2]);

            return new OperationCommand<MakeATransactionOperation>(_operationProcessor,
                new MakeATransactionOperation(
                    sender,
                    Receiver,
                    amount));
        }
    }
}
