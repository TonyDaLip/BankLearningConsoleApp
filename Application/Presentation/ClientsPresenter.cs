using Bank2Solution.Application.Managers;
using Bank2Solution.Infrastructure.Formatters;
using Bank2Solution.Presentation.Interfaces;

namespace Bank2Solution.Application.Presentation
{
    internal class ClientsPresenter
    {
        private readonly ClientManager _manager;
        private readonly ClientFormatter _formatter;
        private readonly IInfoDisplay _display;

        public ClientsPresenter(ClientManager manager, ClientFormatter formatter, IInfoDisplay display)
        {
            _manager = manager;
            _formatter = formatter;
            _display = display;
        }

        public void Display()
        {
            var clients = _manager.GetClientsForCurrentDepartment();
            var formattedClients = _formatter.FormatClients(clients);
            _display.DisplayList("Clients", formattedClients);
        }
    }
}
