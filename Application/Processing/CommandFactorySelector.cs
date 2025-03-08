using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;

namespace Bank2Solution.Application.Processing
{
    internal class CommandFactorySelector
    {
        private readonly Dictionary<string, ICommandFactory> _factories;

        public CommandFactorySelector(IEnumerable<ICommandFactory> factories)
        {
            _factories = factories.ToDictionary(f => f.CommandName, f => f);
        }

        public ICommand CreateCommand(Request request)
        {
            if (!_factories.TryGetValue(request.Command, out var factory))
            {
                return null;
            }

            return factory.Create(request);
        }
    }
}
