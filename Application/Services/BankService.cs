using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Domain.Enums;

namespace Bank2Solution.Application.Services
{
    internal class BankService
    {
        private readonly AccountLyfecycleManager _lyfecycleManager;
        private readonly InterestCalculator _interestCalculator;
        private readonly OperationProcessor _operationProcessor;

        public BankService(AccountLyfecycleManager lyfecycleManager, InterestCalculator interestCalculator, OperationProcessor operationProcessor)
        {
            _lyfecycleManager = lyfecycleManager;
            _interestCalculator = interestCalculator;
            _operationProcessor = operationProcessor;
        }

        public ClientType CurrentDepartment { get; set; }

        public void AdvanceTime(int months)
        {
            _interestCalculator.PerformMonthlyCalculation(months);
            _lyfecycleManager.ProcessAccountLifecycle(_operationProcessor);
        }
    }    
}