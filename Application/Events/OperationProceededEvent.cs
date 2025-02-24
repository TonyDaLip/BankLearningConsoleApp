using Bank2Solution.Application.Interfaces;
using Bank2Solution.Domain.Interfaces;

namespace Bank2Solution.Application.Events
{
    internal class OperationProceededEvent : IEvent
    {
        public OperationProceededEvent(IOperation operation) 
        {
            Operation = operation;
        }

        public IOperation Operation { get; }

        public DateTime TimeStamp => DateTime.UtcNow;
    }
}
