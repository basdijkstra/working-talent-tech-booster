namespace WorkingTalentTechBooster.Banking
{
    public class Account
    {
        public AccountType AccountType { get; }
        public int Balance { get; private set; }
        public int Id { get; }

        public Account(AccountType accountType)
        {
            AccountType = accountType;
            Balance = 0;
            Id = new Random().Next(1, 10000);
        }

        public void Deposit(int amountToDeposit)
        {
            Balance += amountToDeposit;
        }

        public void Withdraw(int amountToWithdraw)
        {
            if (amountToWithdraw > Balance && AccountType.Equals(AccountType.Savings))
            {
                throw new ArgumentException("Cannot overdraw on a savings account");
            }

            Balance -= amountToWithdraw;
        }
    }
}
