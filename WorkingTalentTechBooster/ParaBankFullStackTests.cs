using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

        [TearDown]
        public void CloseBrowser()
        {
            driver?.Quit();
        }
    }
}