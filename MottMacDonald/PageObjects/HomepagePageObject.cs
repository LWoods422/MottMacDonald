using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald
{
    public class HomepagePageObject : BasePageObject
    {
        private readonly IWebDriver _driver;

        public HomepagePageObject(IWebDriver webDriver): base(webDriver)
        {
            _driver = webDriver;
        }

        private List<IWebElement> allLinks => _driver.FindElements(By.TagName("a")).ToList();

        public List<IWebElement> ReturnAllLinks()
        {
            return allLinks;
        }
       

    }
}
