using TechTalk.SpecFlow;

namespace MottMacDonald.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinitions
    {
        private readonly HomepagePageObject _homePagePageObject;
        private readonly JobDetailsPageObject _jobDetailsPageObject;
        public HomePageStepDefinitions(BrowserDriver browserDriver)
        {
            _homePagePageObject = new HomepagePageObject(browserDriver.Current);
            _jobDetailsPageObject = new JobDetailsPageObject(browserDriver.Current);
        }

        private readonly string homepageUrl = "https://www.mottmac.com/";

        [Then(@"All links are outputted to a Text File called ""([^""]*)""")]
        public async Task ThenAllLinksAreOutputtedToATextFileCalled(string fileName)
        {
            var links = new List<string>();
            var allLinks = _homePagePageObject.ReturnAllLinks();
            await Parallel.ForEachAsync(allLinks, new ParallelOptions { MaxDegreeOfParallelism = 3 }, async (uri, cancellationToken) =>
            {

                var linkUrl = uri.GetAttribute("href");
                using var client = new HttpClient();
                var response = await client.GetAsync(linkUrl, cancellationToken);
                links.Add($"Link was {linkUrl}, and response was {response.StatusCode}");
            });

            File.WriteAllLines($@"\Work\{fileName}.txt", links);
        }




        [Given(@"I navigate to the homepage")]
        public void GivenINavigateToTheHomepage()
        {
            _homePagePageObject.NavigateToUrl(homepageUrl);
            _homePagePageObject.AcceptCookies();
            _homePagePageObject.CloseLanguageBox();
        }


    }
}