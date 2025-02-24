using Bank2Solution.Application.Commands;
using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution.Application.Factories.Commands
{
    internal class ShowCommandsCommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _provider;
        private readonly CommandsPresenter _presenter;

        public ShowCommandsCommandFactory(IServiceProvider provider, CommandsPresenter presenter)
        {
            _provider = provider;
            _presenter = presenter;
        }

        public string CommandName => "ShowCommands";

        public IEnumerable<CommandParameters> Parameters => Array.Empty<CommandParameters>();

        public ICommand Create(Request request)
        {
            var factories = _provider.GetServices<ICommandFactory>();

            var commandNames = factories.ToDictionary(factory => factory.CommandName, factory => factory.Parameters);
            return new ShowCommandsCommand(commandNames, _presenter);
        }
    }
}
