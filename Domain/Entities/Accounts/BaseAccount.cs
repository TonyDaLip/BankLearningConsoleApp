namespace Bank2Solution.Domain.Entities.Accounts
{
    abstract class BaseAccount
    {
        public int AccountID { get; private set; }
        public double Balance { get; protected set; }

        public BaseAccount(double amount, int accountID)
        {
            Balance = amount;
            AccountID = accountID;
        }

        public override bool Equals(object? obj)
        {
            if (obj is BaseAccount other)
                return AccountID == other.AccountID;

            return false;
        }
    }
}
