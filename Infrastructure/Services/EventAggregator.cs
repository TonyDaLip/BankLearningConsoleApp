using Bank2Solution.Application.Interfaces;
using Bank2Solution.Infrastructure.Interfaces;

namespace Bank2Solution.Infrastructure.Services
{
    internal class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();

        public void Publish<TEvent>(TEvent eventData) where TEvent : IEvent
        {
            if (_subscribers.TryGetValue(typeof(TEvent), out var handlers))
            {
                foreach (var handler in handlers)
                {
                    (handler as Action<TEvent>)?.Invoke(eventData);
                }
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
        {
            if (!_subscribers.ContainsKey(typeof(TEvent)))
                _subscribers.Add(typeof(TEvent), new List<Delegate>());

            _subscribers[typeof(TEvent)].Add(handler);
        }
    }
}
