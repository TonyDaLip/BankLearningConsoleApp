using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;

namespace Bank2Solution.Presentation.UI
{
    internal class ConsoleLayout
    {
        private const int AreaToClearStartY = 0;

        private readonly BankService _bank;
        private readonly TimeManager _timeManager;

        private readonly ClientsPanel _clientPanel;
        private readonly NotificationsPanel _notificationPanel;

        public ConsoleLayout(BankService bank, TimeManager timeManager, ClientsPanel clientPanel, NotificationsPanel notificationPanel)
        {
            _bank = bank;
            _timeManager = timeManager;
            _clientPanel = clientPanel;
            _notificationPanel = notificationPanel;
        }

        public void DrawUI(string logo) 
        {
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            ClearUpperPart();

            StatusBar.Draw(_timeManager, _bank, logo);

            _clientPanel.Display();
            _notificationPanel.Display();

            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        private void ClearUpperPart()
        {
            for (int y = AreaToClearStartY; y < Console.WindowHeight - 3; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(new String(' ', Console.WindowWidth));
            }
        }
    }
}
