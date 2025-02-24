using Bank2Solution.Application.DTOs;

namespace Bank2Solution.Application.Interfaces
{
    internal interface ICommandFactory
    {
        string CommandName { get; }
        IEnumerable<CommandParameters> Parameters { get; }
        ICommand Create(Request request);
    }
}
