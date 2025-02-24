using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Application.Processing
{
    internal class CommandHandler
    {
        private readonly CommandFactorySelector _commandFactory;
        private readonly CommandParser _commandParser;

        public CommandHandler(CommandFactorySelector commandFactory, CommandParser commandParser)
        {
            _commandFactory = commandFactory;
            _commandParser = commandParser;
        }

        public ICommand GetCommand(string rawCommand)
        {
            Request request = _commandParser.ParseString(rawCommand);
            return _commandFactory.CreateCommand(request);
        }
    }
}
