using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace MottMacDonald
{
    public static class WebDriverExtensions
    {

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }


        public static void ElementExists(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

        public static void ClickOnElement(this IWebDriver driver, IWebElement element)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until((IWebDriver d) => {
                element.Click();
                return true;
            }); 
        }
    }
}
