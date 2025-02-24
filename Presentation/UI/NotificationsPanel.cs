using Bank2Solution.Application.Presentation;

namespace Bank2Solution.Presentation.UI
{
    internal class NotificationsPanel
    {
        private const int NotificationPanelY = 6;

        private readonly NotificationsPresenter _presenter;

        public NotificationsPanel(NotificationsPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Display()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, NotificationPanelY);
            _presenter.Display();
        }
    }
}
