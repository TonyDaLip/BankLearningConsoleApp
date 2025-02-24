using Bank2Solution.Application.Events;
using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Interfaces;
using Bank2Solution.Infrastructure.Interfaces;

namespace Bank2Solution.Application.Processing
{
    internal class OperationProcessor
    {
        private readonly AccountLyfecycleManager _manager;
        private readonly AccountStorage _accountStorage;
        private readonly AccountFactoryResolver _accountFactory;
        private readonly IEventAggregator _eventAggregator;

        public OperationProcessor(AccountLyfecycleManager manager, AccountStorage accountStorage, AccountFactoryResolver accountFactory, IEventAggregator eventAggregator)
        {
            _manager = manager;
            _accountStorage = accountStorage;
            _accountFactory = accountFactory;
            _eventAggregator = eventAggregator;
        }

        public bool TryProceedOperation(IOperation operation)
        {
            if (IsOperationPossible(operation))
            {
                operation.Proceed(_manager, _accountFactory);
                _eventAggregator.Publish(new OperationProceededEvent(operation));
                return true;
            }
            return false;
        }

        public bool IsOperationPossible(IOperation operation)
        {
            return operation.IsPossible(_accountStorage);
        }
    }
}
