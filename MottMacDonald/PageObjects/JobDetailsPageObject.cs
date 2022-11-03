using OpenQA.Selenium;

namespace MottMacDonald
{
    public class JobDetailsPageObject
    {
        private readonly IWebDriver _driver;

        public JobDetailsPageObject(IWebDriver webDriver)
        {
            _driver = webDriver;
        }


        private IWebElement JoDetailsBreadcrumb => _driver.FindElement(By.XPath("//span[@class='lastBreadcrumb']"));


        public string ReturnJobBreadcrumb()
        {
           return JoDetailsBreadcrumb.Text;
        }
    }
}
