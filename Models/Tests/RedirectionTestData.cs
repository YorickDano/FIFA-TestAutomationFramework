namespace Models.Tests
{
    using Newtonsoft.Json;

    public class RedirectionTestData
    {
        [JsonProperty("expectedUrl")]
        public string ExpectedUrl { get; set; }
    }
}
