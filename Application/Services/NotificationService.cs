using Bank2Solution.Application.Events;
using Bank2Solution.Infrastructure.Interfaces;

namespace Bank2Solution.Application.Services
{
    internal class NotificationService
    {
        private readonly Queue<string> _notifications = new Queue<string>();
        private readonly ILogger _logger;

        public NotificationService(ILogger logger)
        {
            _logger = logger;
        }

        private void AddNotification(string notification)
        {
            if (_notifications.Count >= 10)
            {
                _notifications.Dequeue();
            }

            _notifications.Enqueue(notification);
        }

        public IEnumerable<string> GetLastNotifications() => _notifications.ToList().AsReadOnly();

        public void OnAccountOpened(AccountOpenedEvent eventArgs)
        {
            AddNotification($"-Client: Id {eventArgs.Client.Id}; {eventArgs.Client.FirstName} {eventArgs.Client.LastName} " +
                $"opened new account Id: {eventArgs.Account.AccountID} {eventArgs.Account.GetType().Name}");
            _logger.Log($"{eventArgs.TimeStamp} - Client: Id {eventArgs.Client.Id}; {eventArgs.Client.FirstName} {eventArgs.Client.LastName} " +
                $"opened new account Id: {eventArgs.Account.AccountID} {eventArgs.Account.GetType().Name}");
        }

        public void OnAccountClosed(AccountClosedEvent eventArgs)
        {
            AddNotification($"-Client: Id {eventArgs.Client.Id}; {eventArgs.Client.FirstName} {eventArgs.Client.LastName} " +
                $"closed account: Id {eventArgs.Account.AccountID}; {eventArgs.Account.GetType().Name}");
            _logger.Log($"{eventArgs.TimeStamp} - Client: Id {eventArgs.Client.Id}; {eventArgs.Client.FirstName} {eventArgs.Client.LastName} " +
                $"closed account: Id {eventArgs.Account.AccountID}; {eventArgs.Account.GetType().Name}");
        }

        public void OnNewClientAdded(NewClientAddedEvent eventArgs)
        {
            AddNotification($"-{eventArgs.Client.FirstName} {eventArgs.Client.LastName} welcome!");
            _logger.Log($"{eventArgs.TimeStamp} - New Client {eventArgs.Client.FirstName} {eventArgs.Client.LastName} added");
        }

        public void OnOperationProceeded(OperationProceededEvent eventArgs) 
        {
            AddNotification($"-Operation {eventArgs.Operation.GetType().Name} succeded!");
            _logger.Log($"{eventArgs.TimeStamp} - Operation {eventArgs.Operation.GetType().Name} succeded!");
        }
    }
}
