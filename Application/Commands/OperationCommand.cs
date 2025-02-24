using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Processing;
using Bank2Solution.Domain.Interfaces;

namespace Bank2Solution.Application.Commands
{
    internal class OperationCommand<T> : ICommand where T : IOperation
    {
        protected readonly OperationProcessor _operationProcessor;
        protected readonly T _operation;

        public OperationCommand(OperationProcessor operationProcessor, T operation)
        {
            _operationProcessor = operationProcessor;
            _operation = operation;
        }

        public void Execute()
        {
            _operationProcessor.TryProceedOperation(_operation);
        }
    }
}
