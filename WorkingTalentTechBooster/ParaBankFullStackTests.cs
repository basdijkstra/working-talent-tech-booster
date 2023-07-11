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
        }

        [Test]
        public void ImprovingOurCodeStructure()
        {
            // Can you apply the same parameterization principle we used earlier here?
        }

        [Test]
        public void TakingAStepBack()
        {
            // Do you think these tests are the most efficient way to get the information
            // that we're looking for? If yes, why? If no, why not?
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver?.Quit();
        }
    }
}