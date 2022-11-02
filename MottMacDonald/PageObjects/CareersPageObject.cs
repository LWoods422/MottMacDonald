using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald
{
    public class CareersPageObject : BasePageObject
    {
        private readonly IWebDriver _driver;

        public CareersPageObject(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        private IWebElement searchBoxInput => _driver.FindElement(By.Id("search-career-search-temp"));
        private IWebElement searchButton => _driver.FindElement(By.CssSelector("#j-search-box-careers > div.searchBox__container.c-careers-search-box__container > div.searchBox__input-container.input-group > span > button.jst-searchBox__button.searchBox__button.btn-default"));
        private List<IWebElement> viewJob => _driver.FindElements(By.XPath("//a[contains(text(), 'View Job')]")).ToList();
        private List<IWebElement> searchResults => _driver.FindElements(By.ClassName("c-careers-search__title")).ToList();
        private IWebElement searchDropdown => _driver.FindElement(By.CssSelector("#j-careers-search-suggestion__area > li"));

        public void AcceptAlert()
        {
            var alert = _driver.SwitchTo().Alert();
            alert.Accept();
        }


        public void SearchForJob(string job)
        {
            _driver.ElementExists(By.CssSelector("#CountryFacet > ul > li:nth-child(1) > div > label > input"));
            searchBoxInput.Click();
            searchBoxInput.SendKeys(job);
            searchButton.Click();
        }

        public List<IWebElement> ReturnSearchResults(string job)
        {
            var elements = searchResults;
            var jobTitle = job.TitleCaseString();


            //for (int i = 0; i < elements.Count(); i++)
            //{

            var requeryResults = searchResults;

            var matchingvalues = requeryResults
                .Where(stringToCheck => stringToCheck.Text.Contains(jobTitle));
            return matchingvalues.ToList();

            //}
            //return null;


        }

        public void ClickViewJob()
        {
            try
            {
                viewJob.First().ClickWhenDisplayed();
            }
            catch (StaleElementReferenceException)
            {

                viewJob.First().ClickWhenDisplayed();
            }

            _driver.Navigate().Refresh();
        }

    }
}
