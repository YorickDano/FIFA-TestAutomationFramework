namespace Core.API.Managers
{
    using Core.Services;
    using Models.API.ApiSearch;
    using RestEase;
    using System.Threading.Tasks;
    using Models.API;
    using Newtonsoft.Json;
    using static Core.API.RestEaseClient.RestEaseClient;
    using static Configuration.ConfigurationManager;

    public static class SearchManagerRestEase
    {
        public async static Task<SearchResultsRoot> ExecuteGetRequestForSearch(string configurationDataFullPath)
        {
            var configurationData = JsonDeserializer.DeserializeSectionFromFile<FifaSearchApi>(configurationDataFullPath);

            var client = RestClient.For<IFifaSearchApi>(GetConfiguration<ApiSettingsModel>().BaseUrl);

            var respounce = await client.Get(
                configurationData.SearchString,
                configurationData.Page,
                configurationData.PageSize,
                configurationData.ContentType,
                configurationData.Sort,
                configurationData.DateFrom,
                configurationData.Locale
                );

            SearchResultsRoot actualData = JsonConvert.DeserializeObject<SearchResultsRoot>(respounce);
            return actualData;
        }
    }
}
