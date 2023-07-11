using OpenQA.Selenium;

namespace WorkingTalentTechBooster.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By textfieldUsername = By.Name("username");
        private readonly By textfieldPassword = By.Name("password");
        private readonly By buttonDoLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(WebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl("https://parabank.parasoft.com");
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(textfieldUsername, username);
            SendKeys(textfieldPassword, password);
            Click(buttonDoLogin);
        }
    }
}
