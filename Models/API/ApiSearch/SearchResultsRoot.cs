namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;

    public class SearchResultsRoot
    {
        [JsonProperty("searchResults")]
        public SearchResults SearchResults { get; set; }
    }
}
