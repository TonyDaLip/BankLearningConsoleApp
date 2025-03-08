namespace Bank2Solution.Domain.Entities.Accounts
{
    abstract class BaseAccount
    {
        public int AccountID { get; private set; }
        public double Balance { get; protected set; }

        protected BaseAccount(double amount, int accountID)
        {
            Balance = amount;
            AccountID = accountID;
        }

        public override bool Equals(object? obj)
        {
            return obj is BaseAccount other ? AccountID == other.AccountID : false;
        }
    }
}
