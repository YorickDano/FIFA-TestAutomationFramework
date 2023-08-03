namespace Tests.API
{
    using Core.API.Managers;
    using Core.Services;
    using FluentAssertions;
    using Models.API.ApiSearch;
    using NUnit.Framework;
    using System.Net;
    using static Core.Utils.AssertsPool;

    [TestFixture]
    public class TestsRestSharp : BaseTestApi
    {
        [Test]
        public async Task CheckHitTitleTest()
        {
            var configurationDataFullPath = Path.Combine("API", "RequestData", "fifaSearchRequestData.json");
            var expectedDataFullPath = Path.Combine("API", "ExpectedData", "searchResultsExpectedData.json");

            var response = await SearchManagerRestSharp.ExecuteGetRequestForSearch(configurationDataFullPath);

            var actualApiData = JsonDeserializer.DeserializeFromString<SearchResultsRoot>(response.Content);
            var expectedApiData = JsonDeserializer.DeserializeFromFile<SearchResultsRoot>(expectedDataFullPath);

            var firstHitActualData = actualApiData.SearchResults.Hits.Hits.First().Source.Title;
            var firstHitExpectedData = expectedApiData.SearchResults.Hits.Hits.First().Source.Title;

            Verify(() => firstHitActualData.Should().BeEquivalentTo(firstHitExpectedData));
        }

        [Test]
        public async Task CheckResponseCodeTest()
        {
            var configurationDataFullPath = Path.Combine("API", "RequestData", "fifaSearchRequestData.json");

            var response = await SearchManagerRestSharp.ExecuteGetRequestForSearch(configurationDataFullPath);

            Verify(() => response.StatusCode.Should().Be(HttpStatusCode.OK));
        }

        [Test]
        public async Task RecordTypeChangingTest()
        {
            var configurationDataFullPath = Path.Combine("API", "RequestData", "RecordTypeRequestData.json");
            var expectedDataFullPath = Path.Combine("API", "ExpectedData", "RecordTypeExpectedData.json");

            var response = await SearchManagerRestSharp.ExecuteGetRequestForSearch(configurationDataFullPath);

            var actualData = JsonDeserializer.DeserializeFromString<SearchResultsRoot>(response.Content);
            var expectedData = JsonDeserializer.DeserializeFromFile<SearchResultsRoot>(expectedDataFullPath);

            var expectedRecordType = expectedData.SearchResults.Hits.Hits.First().Source.RecordType;
            var actualRecordType = actualData.SearchResults.Hits.Hits.First().Source.RecordType;

            Verify(() => expectedRecordType.Should().BeEquivalentTo(actualRecordType));
        }
    }
}
