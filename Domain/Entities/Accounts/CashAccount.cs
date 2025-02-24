namespace Bank2Solution.Domain.Entities.Accounts
{
    internal class CashAccount : BaseAccount
    {
        public CashAccount(double amount, int accountID) : base(amount, accountID) { }

        public void Deposit(double amount) => Balance += amount;

        public void WithDraw(double amount) => Balance -= amount;
    }
}
