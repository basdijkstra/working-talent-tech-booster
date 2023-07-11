using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WorkingTalentTechBooster.Pages
{
    public class BasePage
    {
        private WebDriver driver;
        private WebDriverWait wait;

        protected BasePage(WebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        public void Click(By locator)
        {
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(locator);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Click(): element located by {locator} not visible and enabled within 10 seconds.");
            }
        }

        public void SendKeys(By locator, string textToSend)
        {
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(locator);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Clear();
                myElement.SendKeys(textToSend);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {locator} not visible and enabled within 10 seconds.");
            }
        }

        public void Select(By locator, string valueToSelect)
        {
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(locator);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                SelectElement dropdown = new SelectElement(myElement);
                dropdown.SelectByText(valueToSelect);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {locator} not visible and enabled within 10 seconds.");
            }
        }

        public string GetElementText(By locator)
        {
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(locator);
                    return tempElement.Displayed ? tempElement : null;
                }
                );
                return myElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in GetElementText(): element located by {locator} not visible and enabled within 10 seconds.");
            }

            return string.Empty;
        }
        public void SelectMenuItem(string menuItem)
        {
            Click(By.LinkText(menuItem));
        }
    }
}
