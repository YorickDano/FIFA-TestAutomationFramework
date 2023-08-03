namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;

    public class Total
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        [JsonProperty("relation")]
        public string Relation { get; set; }
    }
}
