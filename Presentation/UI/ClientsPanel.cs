using Bank2Solution.Application.Presentation;

namespace Bank2Solution.Presentation.UI
{
    internal class ClientsPanel
    {
        private const int ClientPanelX = 0;
        private const int ClientPanelY = 6;

        private readonly ClientsPresenter _presenter;

        public ClientsPanel(ClientsPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Display()
        {
            Console.SetCursorPosition(ClientPanelX, ClientPanelY);
            _presenter.Display();
        }
    }
}
