namespace SpecFlowProject.StepDefinitions
{
    using static Core.Utils.AssertsPool;
    using Core.UI;
    using PageObjects.SearchPages;
    using Core.Services;
    using Models.Tests;

    [Binding]
    public class UIStepDefinitions
    {
        SearchedPage? SearchedPage;
        private string? expectedSocialNetworkUrl;
        private List<string>? expectedPartnersList;

        [Given(@"I search for ""(.*)""")]
        public void GivenISearchFor(string information)
        {
            SearchedPage = SearchManager.SearchFor(information);
        }

        [Then(@"Results should be more than ""(.*)""")]
        public void ThenResultSshhouldBeMoreThan(string expectedCount)
        {
            var actualCount = SearchManager.GetCountOfSearchResults(SearchedPage);
            Verify(() => actualCount.Should().BeGreaterThan(int.Parse(expectedCount))); 
        }

        [Given("Expected social network url")]
        public void ExpectedSocialNetworkUrl()
        {
            var testDataFullPath = Path.Combine("UI", "ExpectedData", $"testsData.{Environment.GetEnvironmentVariable("stage")}.json");
            expectedSocialNetworkUrl = JsonDeserializer.DeserializeSectionFromFile<RedirectionTestData>(testDataFullPath).ExpectedUrl;
        }

        [Then("I verify expected url with actual")]
        public void ThenIVerifyExpectedUrlWithActual()
        {
            Verify(() => BrowserPool.GetBrowser().GetCurrentUrl().Should().Be(expectedSocialNetworkUrl));
        }

        [Then($"I verify that header links count should be (.*)")]
        public void ThenIVerifyThatHeaderLinksCountShouldBe(int count)
        {
            Verify(() => HeaderMenuManager.GetLinkCount().Should().Be(count));
        }

        [Given("Expected partners list")]
        public void ExpectedPartnersList()
        {
            var testDataFullPath = Path.Combine("UI", "ExpectedData", $"testsData.{Environment.GetEnvironmentVariable("stage")}.json");
            expectedPartnersList = JsonDeserializer.DeserializeSectionFromFile<FifaPartnersTestData>(testDataFullPath).ExpectedPartners;
        }

        [Then("I verify that partners lists should be the same")]
        public void ThenIVerifyThatPartnersListsShouldBeTheSame()
        {
            Verify(() => PartnersManager.GetPartnersNameList().Should().BeEquivalentTo(expectedPartnersList));
        }
    }
}
