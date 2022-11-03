using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MottMacDonald.StepDefinitions
{
    [Binding]
    public class Careers
    {
        private readonly CareersPageObject _careersPageObject;
        private readonly JobDetailsPageObject _jobDetailsPageObject;
        public Careers(BrowserDriver browserDriver)
        {
            _careersPageObject = new CareersPageObject(browserDriver.Current);
            _jobDetailsPageObject = new JobDetailsPageObject(browserDriver.Current);
        }


        private readonly string careersUrl = "https://www.mottmac.com/careers/search";

        [Given(@"I navigate to the Careers Page")]
        public void GivenINavigateToTheCareersPage()
        {
            _careersPageObject.NavigateToUrl(careersUrl);
            _careersPageObject.AcceptCookies();
            _careersPageObject.CloseLanguageBox();
        }


        [When(@"I search for '([^']*)'")]
        public void WhenISearchFor(string job)
        {
            _careersPageObject.SearchForJob(job);
        }

        [Then(@"I verify the search returns '([^']*)'")]
        public void ThenIVerifyTheSearchReturns(string job)
        {
            var matchingJobs = _careersPageObject.ReturnSearchResults(job);

            Assert.IsTrue(matchingJobs.Any());

        }

        [Then(@"I verify when I click on “view Job” I am directed to the details for the '([^']*)'")]
        public void ThenIVerifyWhenIClickOnViewJobIAmDirectedToTheDetailsForThe(string job)
        {
            var expectedJob = job.TitleCaseString();
            _careersPageObject.ClickViewJob();
            var actualJob = _jobDetailsPageObject.ReturnJobBreadcrumb();
            Assert.AreEqual(expectedJob, actualJob, $"Expected job title to be {expectedJob} but was {actualJob}");

        }



    }
}