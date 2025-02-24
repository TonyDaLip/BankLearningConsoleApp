using Bank2Solution.Application.Interfaces;
using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Services;
using Bank2Solution.Domain.Enums;

namespace Bank2Solution.Application.Commands
{
    internal class ChangeDepartmentCommand : ICommand
    {
        private readonly BankService _bank;
        private readonly ClientManager _manager;
        private readonly ClientType _newDepartment;

        public ChangeDepartmentCommand(BankService bank, ClientManager manager, ClientType newDepartment)
        {
            _bank = bank;
            _manager = manager;
            _newDepartment = newDepartment;
        }

        public void Execute()
        {
            _bank.CurrentDepartment = _newDepartment;
            _manager.ChangeDepartment(_newDepartment);
        }
    }
}
