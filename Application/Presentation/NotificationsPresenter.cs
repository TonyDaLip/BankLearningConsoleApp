using Bank2Solution.Application.Services;
using Bank2Solution.Presentation.Interfaces;

namespace Bank2Solution.Application.Presentation
{
    internal class NotificationsPresenter
    {
        private readonly NotificationService _notificationService;
        private readonly IInfoDisplay _display;

        public NotificationsPresenter(NotificationService notificationService, IInfoDisplay display)
        {
            _notificationService = notificationService;
            _display = display;
        }

        public void Display()
        {
            var notifications = _notificationService.GetLastNotifications();
            _display.DisplayList("Notifications", notifications);
        }
    }
}
