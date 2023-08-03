namespace Tests.API
{
    using NUnit.Framework;
    using Models.API.ApiSearch;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Core.Services;
    using Core.API.Managers;
    using static Core.Utils.AssertsPool;

    [TestFixture]
    public class TestsRestEase : BaseTestApi
    {
        [Test]
        public async Task CheckHitTitleTest()
        {
            var configurationDataFullPath = Path.Combine("API", "RequestData", "fifaSearchRequestData.json");
            var expectedDataFullPath = Path.Combine("API", "ExpectedData", "searchResultsExpectedData.json");

            var actualApiData =  await SearchManagerRestEase.ExecuteGetRequestForSearch(configurationDataFullPath);
            var expectedApiData = JsonDeserializer.DeserializeFromFile<SearchResultsRoot>(expectedDataFullPath);

            var firstHitActualData = actualApiData.SearchResults.Hits.Hits.First().Source.Title;
            var firstHitExpectedData = expectedApiData.SearchResults.Hits.Hits.First().Source.Title;

            Verify(() => firstHitActualData.Should().BeEquivalentTo(firstHitExpectedData));
        }

        [Test]
        public async Task RecordTypeChangingTest()
        {
            var configurationDataFullPath = Path.Combine("API", "RequestData", "RecordTypeRequestData.json");
            var expectedDataFullPath = Path.Combine("API", "ExpectedData", "RecordTypeExpectedData.json");

            var actualApiData = await SearchManagerRestEase.ExecuteGetRequestForSearch(configurationDataFullPath);
            var expectedApiData = JsonDeserializer.DeserializeFromFile<SearchResultsRoot>(expectedDataFullPath);

            var actualRecordType = actualApiData.SearchResults.Hits.Hits.First().Source.RecordType;
            var expectedRecordType = expectedApiData.SearchResults.Hits.Hits.First().Source.RecordType;

            Verify(() => actualRecordType.Should().BeEquivalentTo(expectedRecordType));
        }
    }
}