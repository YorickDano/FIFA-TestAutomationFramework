namespace SpecFlowProject.StepDefinitions
{
    using Core.API.Managers;
    using Core.Services;
    using Models.API.ApiSearch;
    using RestSharp;
    using System.Net;
    using System.Text;
    using TechTalk.SpecFlow.Assist;
    using static Core.Utils.AssertsPool;

    [Binding]
    public class RestSharpApiStepDefinitions
    {
        private RequestBuilder RequestBuilder;
        private RestResponse Response;
        private SearchResultsRoot? expectedApiData;

        [Given(@"I create RequestBuilder")]
        public void GivenICreatRequestBuilder()
        {
            if (RequestBuilder == null)
            {
                RequestBuilder = new RequestBuilder();
            }
        }

        [Given(@"I create request")]
        public void GivenICreatRequest()
        {
            RequestBuilder.CreateRequest();
        }

        [Given(@"I set request method ""(.*)""")]
        public void GivenISetRequestMethod(Method method)
        {
            RequestBuilder.SetRequestMethod(method);
        }

        [Given(@"I set request resource ""(.*)""")]
        public void GivenISetRequestResource(string resource)
        {
            RequestBuilder.SetRequestResource(resource);
        }

        [Given(@"I set request parameter with name ""(.*)"" and value ""(.*)""")]
        public void GivenISetRequestParameter(string name, string value)
        {
            RequestBuilder.AddRequestParameter(name, value);
        }

        [Given(@"I set request parameters")]
        public void GivenISetRequestParameters(Table table)
        {
            var parameters = table.Rows;

            foreach (var parameter in parameters)
            {
                RequestBuilder.AddRequestParameter(parameter.GetString("name"), parameter.GetString("value"));
            }
        }

        [When(@"I execute request")]
        public async Task WhenIExecuteRequest()
        {
            Response = await APIClientPool.GetAPIClient().ExecuteAsync(RequestBuilder.GetRequest());
        }


        [Then(@"I verify")]
        public void ThenIVerify()
        {
            var expectedDataFullPath = Path.Combine("API", "ExpectedData", "RecordTypeExpectedData.json");

            var actualData = JsonDeserializer.DeserializeFromString<SearchResultsRoot>(Response.Content);
            var expectedData = JsonDeserializer.DeserializeFromFile<SearchResultsRoot>(expectedDataFullPath);

            var expectedRecordType = expectedData.SearchResults.Hits.Hits.First().Source.RecordType;
            var actualRecordType = actualData.SearchResults.Hits.Hits.First().Source.RecordType;

            Verify(() => expectedRecordType.Should().BeEquivalentTo(actualRecordType));
        }

        [Given(@"Response from request configuration from file ""(.*)""")]
        public async Task ResponseFromRequestConfiguration(string fileName)
        {
            var configurationDataFullPath = Path.Combine("API", "RequestData", fileName);
            Response = await SearchManagerRestSharp.ExecuteGetRequestForSearch(configurationDataFullPath);
        }

        [Given(@"Expected Api data from file ""(.*)""")]
        public void ExpectedApiDataFromFile(string fileName)
        {
            var expectedDataFullPath = Path.Combine("API", "ExpectedData", fileName);
            expectedApiData = JsonDeserializer.DeserializeFromFile<SearchResultsRoot>(expectedDataFullPath);
        }

        [Then("I verify that hit titles should be the same")]
        public void ThenIVerifyThatHitTitlesShouldBeTheSame()
        {
            var actualApiData = JsonDeserializer.DeserializeFromString<SearchResultsRoot>(Response.Content);
 
            var firstHitActualData = actualApiData.SearchResults.Hits.Hits.First().Source.Title;
            var firstHitExpectedData = expectedApiData.SearchResults.Hits.Hits.First().Source.Title;

            Verify(() => firstHitActualData.Should().BeEquivalentTo(firstHitExpectedData));
        }

        [Then(@"HTTP code status should be ""(.*)""")]
        public void ThenHTTPCodeStatusShouldBe(HttpStatusCode httpStatusCode)
        {
           Verify(() => Response.StatusCode.Should().Be(httpStatusCode));
        }
    }
}
