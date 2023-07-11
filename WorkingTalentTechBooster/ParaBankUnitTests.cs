using NUnit.Framework;
using WorkingTalentTechBooster.Banking;

namespace WorkingTalentTechBooster
{
    [TestFixture]
    public class ParaBankUnitTests
    {
        [Test]
        public void LoanApplicationFor1000_DownPayment100_ShouldBeApproved()
        {
            LoanApplication loanApplication = new LoanApplication
            {
                Amount = 1000,
                DownPayment = 100,
                FromAccountId = 12345
            };

            LoanApplicationResult result = LoanProcessor.ProcessLoanApplication(loanApplication);

            Assert.That(result, Is.EqualTo(LoanApplicationResult.Approved));
        }

        [Test]
        public void LoanApplicationFor1000_DownPayment99_ShouldBeDenied()
        {
            // Write a test that applies for a 1000 dollar loan with a downpayment of 99 deducted from account 12345

            // Check that the loan application result is equal to Denied
        }

        [Test]
        public void LoanApplicationWithNegativeDownPayment_ShouldThrowException()
        {
            // Create a new LoanApplication with a negative value for the downpayment
            // Check that this results in an ArgumentException
            // (i.e., the test passes when this exception is thrown)
            // Google is your friend here!
        }
    }
}
