using OpenQA.Selenium;

namespace MottMacDonald
{
    public class HomepagePageObject : BasePageObject
    {
        private readonly IWebDriver _driver;

        public HomepagePageObject(IWebDriver webDriver): base(webDriver)
        {
            _driver = webDriver;
        }

        private List<IWebElement> AllLinks => _driver.FindElements(By.TagName("a")).ToList();

        public List<IWebElement> ReturnAllLinks()
        {
            return AllLinks;
        }
       

    }
}
