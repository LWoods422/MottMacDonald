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

        private IWebElement AcceptCookiesButton => _driver.FindElement(By.Id("ccc-notify-accept"));
        private IWebElement GlobalEnglishButton => _driver.FindElement(By.CssSelector("#cultureModal > div > div:nth-child(4) > ul > li:nth-child(1) > a"));

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public void AcceptCookies()
        {
            if(AcceptCookiesButton.Displayed)
            {
                AcceptCookiesButton.Click();
            }

        }

        public void CloseLanguageBox()
        {
            if (GlobalEnglishButton.Displayed)
            {
                GlobalEnglishButton.Click();
            }
        }

    }
}
