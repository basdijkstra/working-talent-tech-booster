using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WorkingTalentTechBooster.Pages;

namespace WorkingTalentTechBooster
{
    public class ParaBankFullStackTests
    {
        private WebDriver? driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LetsSeeIfEverythingWorks()
        {
            driver?.Navigate().GoToUrl("https://parabank.parasoft.com");

            Assert.That(driver?.Title, Is.EqualTo("ParaBank | Welcome | Online Banking"));
        }

        [Test]
        public void UserCanApplyForLoanAndSeeItApproved()
        {
            new LoginPage(driver!)
                .LoginAs("john", "demo");

            new AccountsOverviewPage(driver!)
                .SelectMenuItem("Request Loan");

            RequestLoanPage rlp = new RequestLoanPage(driver!);

            rlp.SubmitLoanApplication(
                amount: "10000",
                downPayment: "1000",
                fromAccountId: "12345");

            Assert.That(rlp.GetLoanApplicationResult(), Is.EqualTo("Approved"));
        }

        [Test]
        public void UserCanApplyForLoanAndSeeItDenied()
        {
            // Write another test applying for a loan for 100000 with downpayment of 100
            // from account ID 12345 and check that it is Denied.

            new LoginPage(driver!)
                .LoginAs("john", "demo");

            new AccountsOverviewPage(driver!)
                .SelectMenuItem("Request Loan");

            RequestLoanPage rlp = new RequestLoanPage(driver!);

            rlp.SubmitLoanApplication(
                amount: "100000",
                downPayment: "100",
                fromAccountId: "12345");

            Assert.That(rlp.GetLoanApplicationResult(), Is.EqualTo("Denied"));
        }

        [TestCase("10000", "1000", "Approved", TestName = "A request for a $10000 loan with a $1000 down payment should be approved")]
        [TestCase("100000", "100", "Denied", TestName = "A request for a $100000 loan with a $100 down payment should be denied")]
        public void ImprovingOurCodeStructure(string loanAmount, string downPayment, string expectedResult)
        {
            // Can you apply the same parameterization principle we used earlier here?

            new LoginPage(driver!)
                .LoginAs("john", "demo");

            new AccountsOverviewPage(driver!)
                .SelectMenuItem("Request Loan");

            RequestLoanPage rlp = new RequestLoanPage(driver!);

            rlp.SubmitLoanApplication(
                amount: loanAmount,
                downPayment: downPayment,
                fromAccountId: "12345");

            Assert.That(rlp.GetLoanApplicationResult(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void TakingAStepBack()
        {
            // Do you think these tests are the most efficient way to get the information
            // that we're looking for? If yes, why? If no, why not?

            // ANSWER: No, I don't think so. Instead of checking that the user can successfully
            // apply for a loan and see the result of the application on the screen, we're now
            // moving into checking the loan application algorithm, which can be done more
            // efficiently through integration tests like those we wrote before.

            // In general, running parameterized / data-driven tests against the UI of an application
            // is a 'test code smell' for me, it isn't wrong per se, but definitely worth questioning.
            // See also http://chrismcmahonsblog.blogspot.com/2017/11/ui-test-heuristic-dont-repeat-your-paths.html
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver?.Quit();
        }
    }
}