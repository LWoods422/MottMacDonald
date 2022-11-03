using OpenQA.Selenium;

namespace MottMacDonald
{
    public class CareersPageObject : BasePageObject
    {
        private readonly IWebDriver _driver;

        public CareersPageObject(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        private IWebElement SearchBoxInput => _driver.FindElement(By.Id("search-career-search-temp"));
        private IWebElement SearchButton => _driver.FindElement(By.CssSelector("#j-search-box-careers > div.searchBox__container.c-careers-search-box__container > div.searchBox__input-container.input-group > span > button.jst-searchBox__button.searchBox__button.btn-default"));
        private List<IWebElement> ViewJob => _driver.FindElements(By.XPath("//a[contains(text(), 'View Job')]")).ToList();
        private List<IWebElement> SearchResults => _driver.FindElements(By.ClassName("c-careers-search__title")).ToList();

        public void SearchForJob(string job)
        {
            _driver.ElementExists(By.CssSelector("#CountryFacet > ul > li:nth-child(1) > div > label > input"));
            SearchBoxInput.Click();
            SearchBoxInput.SendKeys(job);
            SearchButton.Click();
        }

        public List<IWebElement> ReturnSearchResults(string job)
        {

            var jobTitle = job.TitleCaseString();
            try
            {
                var matchingvalues = SearchResults
                .Where(stringToCheck => stringToCheck.Text.Contains(jobTitle));
                return matchingvalues.ToList();
            }
            catch (StaleElementReferenceException)
            {
                var matchingvalues = SearchResults
                .Where(stringToCheck => stringToCheck.Text.Contains(jobTitle));
                return matchingvalues.ToList();
            }

        }

        public void ClickViewJob()
        {
            try
            {
                _driver.ClickOnElement(ViewJob.First());

            }
            catch (Exception e)
            {

                throw new Exception($"Cant Select Element {ViewJob}", e);
            }

            _driver.Navigate().Refresh();
        }

    }
}
