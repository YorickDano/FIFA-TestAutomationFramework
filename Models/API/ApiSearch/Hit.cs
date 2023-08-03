namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Hit
    {
        [JsonProperty("_index")]
        public string Index { get; set; }
        [JsonProperty("_type")]
        public string Type { get; set; }
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("_score")]
        public double Score { get; set; }
        [JsonProperty("_source")]
        public Source Source { get; set; }
        [JsonProperty("highlight")]
        public Highlight Highlight { get; set; }
        [JsonProperty("total")]
        public Total Total { get; set; }
        [JsonProperty("max_score")]
        public double MaxScore { get; set; }
        [JsonProperty("hits")]
        public List<Hit> Hits { get; set; }
    }
}
