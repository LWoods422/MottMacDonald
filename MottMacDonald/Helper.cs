using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void ClickWhenDisplayed(this IWebElement webElement)
        {
            if (SpinWait.SpinUntil(() => webElement.Displayed, 20000))
            {
                webElement.Click();
            }
            else
            {
                throw new ElementNotInteractableException($"WebElement {webElement} not found, when attempting to click");
            }
        }

        public static string TitleCaseString(this string stringToConvert)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(stringToConvert);
        }

        public static void ElementExists(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

    }
}
