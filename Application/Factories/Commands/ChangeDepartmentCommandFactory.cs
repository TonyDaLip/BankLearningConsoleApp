using Bank2Solution.Application.Commands;
using Bank2Solution.Application.DTOs;
using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Enums;
using Bank2Solution.Infrastructure.Converters;

namespace Bank2Solution.Application.Factories.Commands
{
    internal class ChangeDepartmentCommandFactory : ICommandFactory
    {
        private readonly BankService _bank;
        private readonly ClientManager _manager;

        public ChangeDepartmentCommandFactory(BankService bank, ClientManager manager)
        {
            _bank = bank;
            _manager = manager;
        }

        public string CommandName => "ChangeDepartment";

        public IEnumerable<CommandParameters> Parameters => new[]
        {
            new CommandParameters("Department", typeof(ClientType), "Individual", "VIP", "Business")
        };

        public ICommand Create(Request request)
        {
            if (request.IsIncorrectValuesCount(1))
            {
                throw new ArgumentException($"Incorrect number of values for {CommandName}");
            }

            var newDepartment = EnumConverter.TryConvertEnum<ClientType>(request.Values[0]);

            return new ChangeDepartmentCommand(_bank, _manager, newDepartment);
        }
    }
}
