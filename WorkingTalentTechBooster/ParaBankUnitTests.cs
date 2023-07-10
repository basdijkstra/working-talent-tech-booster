using NUnit.Framework;
using WorkingTalentTechBooster.Banking;

namespace WorkingTalentTechBooster
{
    [TestFixture]
    public class ParaBankUnitTests
    {
        [Test]
        public void Deposit10ToCheckingAccount_CheckBalance_ShouldBe10()
        {
            Account account = new Account(AccountType.Checking);

            account.Deposit(10);

            Assert.That(account.Balance, Is.EqualTo(10));
        }

        [Test]
        public void Deposit50ToSavingsAccount_CheckBalance_ShouldBe50()
        {
            // Create a new Savings account
            // Deposit 50 into the account
            // Check that the balance is equal to 50
        }

        [Test]
        public void CreateSavingsAccount_Deposit40ThenWithdraw20_CheckBalance_ShouldBe20()
        {
            // Create a new Savings account
            // First, deposit 40 into the account
            // Then withdraw 20 from the account
            // Check that the resulting balance is 20
        }

        [Test]
        public void CreateSavingsAccount_Withdraw20_ShouldThrowException()
        {
            // Create a new Savings account
            // Try to withdraw 20 from the account
            // Check that this results in an ArgumentException
            // (i.e., the test passes when this exception is thrown)
            // Google is your friend here!
        }
    }
}
