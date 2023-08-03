namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;

    public class FifaSearchApi
    {
        [JsonProperty("searchString")]
        public string SearchString { get; set; }
        [JsonProperty("page")]
        public string Page { get; set; }
        [JsonProperty("pageSize")]
        public string PageSize { get; set; }
        [JsonProperty("contentType")]
        public string ContentType { get; set; }
        [JsonProperty("sort")]
        public string Sort { get; set; }
        [JsonProperty("dateFrom")]
        public string DateFrom { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
    }
}
