using OpenQA.Selenium;

namespace MottMacDonald
{
    public class BasePageObject
    {
        private readonly IWebDriver _driver;

        public BasePageObject(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        private IWebElement acceptCookies => _driver.FindElement(By.Id("ccc-notify-accept"), 20);
        private IWebElement english => _driver.FindElement(By.CssSelector("#cultureModal > div > div:nth-child(4) > ul > li:nth-child(1) > a"));

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void AcceptCookies()
        {
            if(acceptCookies.Displayed)
            {
                acceptCookies.Click();
            }

        }

        public void CloseLanguageBox()
        {
            if (english.Displayed)
            {
                english.Click();
            }
        }

    }
}
