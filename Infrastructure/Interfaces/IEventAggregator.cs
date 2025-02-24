using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Infrastructure.Interfaces
{
    internal interface IEventAggregator
    {
        void Publish<TEvent>(TEvent eventData) where TEvent : IEvent;
        void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent;
    }
}
