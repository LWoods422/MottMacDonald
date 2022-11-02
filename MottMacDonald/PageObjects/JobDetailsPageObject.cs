using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald
{
    public class JobDetailsPageObject
    {
        private readonly IWebDriver _driver;

        public JobDetailsPageObject(IWebDriver webDriver)
        {
            _driver = webDriver;
        }


        private IWebElement jobDetailsBreadcrumb => _driver.FindElement(By.XPath("//span[@class='lastBreadcrumb']"), 20);


        public string ReturnJobBreadcrumb()
        {
           return jobDetailsBreadcrumb.Text;
        }
    }
}
