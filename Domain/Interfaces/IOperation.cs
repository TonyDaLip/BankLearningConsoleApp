using Bank2Solution.Application.Managers;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;

namespace Bank2Solution.Domain.Interfaces
{
    internal interface IOperation
    {
        bool IsPossible(AccountStorage accountStorage);

        void Proceed(AccountLyfecycleManager manager, AccountFactoryResolver factory);
    }
}