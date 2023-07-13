using NUnit.Framework;
using WorkingTalentTechBooster.Banking;
using static RestAssured.Dsl;

namespace WorkingTalentTechBooster
{
    [TestFixture]
    public class ParaBankIntegrationTests : IntegrationTestBase
    {
        [Test]
        public void RequestLoanFor100With10AsDownPayment_ShouldBeAccepted()
        {
            var loanApplication = new LoanApplication
            {
                Amount = 100,
                DownPayment = 10,
                FromAccountId = 12345
            };

            Given()
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/requestLoan")
                .Then()
                .StatusCode(201)
                .And()
                .Body("Result", NHamcrest.Is.EqualTo("Approved"));
        }

        [Test]
        public void RequestLoanFor500With50AsDownPayment_ShouldBeAccepted()
        {
            // Create a new loanApplication with Amount = 500, DownPayment = 50 and FromAccountId = 12345

            // POST that to the same endpoint

            // Check that the Result is equal to Approved

            var loanApplication = new LoanApplication
            {
                Amount = 500,
                DownPayment = 50,
                FromAccountId = 12345
            };

            Given()
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/requestLoan")
                .Then()
                .StatusCode(201)
                .And()
                .Body("Result", NHamcrest.Is.EqualTo("Approved"));
        }

        [Test]
        public void RequestLoanFor500With10AsDownPayment_ShouldBeDenied()
        {
            // Create a new loanApplication with Amount = 500, DownPayment = 10 and FromAccountId = 12345

            // POST that to the same endpoint

            // Check that the Result is equal to Denied

            var loanApplication = new LoanApplication
            {
                Amount = 500,
                DownPayment = 10,
                FromAccountId = 12345
            };

            Given()
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/requestLoan")
                .Then()
                .StatusCode(201)
                .And()
                .Body("Result", NHamcrest.Is.EqualTo("Denied"));
        }

        [TestCase(100, 10, "Approved", TestName = "A request for a $100 loan with a $10 down payment should be approved")]
        [TestCase(500, 50, "Approved", TestName = "A request for a $500 loan with a $50 down payment should be approved")]
        [TestCase(500, 10, "Denied", TestName = "A request for a $500 loan with a $10 down payment should be approved")]
        public void IsntThereABetterWay(int loanAmount, int downPayment, string expectedResult)
        {
            // The tests above perform the same action (submitting a loan request, then
            // checking the result), just with different data values (arguments).

            // That results in a lot of code duplication

            // Isn't there a better way?

            // Hint: https://www.ontestautomation.com/parameterizing-tests-in-rest-assured-net/

            var loanApplication = new LoanApplication
            {
                Amount = loanAmount,
                DownPayment = downPayment,
                FromAccountId = 12345
            };

            Given()
                .Body(loanApplication)
                .When()
                .Post("http://localhost:9876/requestLoan")
                .Then()
                .StatusCode(201)
                .And()
                .Body("Result", NHamcrest.Is.EqualTo(expectedResult));
        }
    }
}
