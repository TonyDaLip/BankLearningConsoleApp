using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Presentation;
using System.Collections;

namespace Bank2Solution.Application.Commands
{
    internal class ShowCommandsCommand : ICommand
    {
        private readonly Dictionary<string, IEnumerable<CommandParameters>> _commandParameters;
        private readonly CommandsPresenter _presenter;

        public ShowCommandsCommand(Dictionary<string, IEnumerable<CommandParameters>> commandParameters, CommandsPresenter presenter)
        {
            _commandParameters = commandParameters;
            _presenter = presenter;
        }

        public void Execute()
        {
            _presenter.Display(_commandParameters);
        }
    }
}
