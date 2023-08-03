namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;

    public class SearchResults
    {
        [JsonProperty("took")]
        public int Took { get; set; }
        [JsonProperty("timed_out")]
        public bool TimedOut { get; set; }
        [JsonProperty("_shards")]
        public Shards Shards { get; set; }
        [JsonProperty("hits")]
        public Hit Hits { get; set; }
    }
}
