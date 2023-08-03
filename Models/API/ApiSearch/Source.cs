namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class Source
    {
        [JsonProperty("contentDate")]
        public DateTime ContentDate { get; set; }
        [JsonProperty("image")]
        public Image Image { get; set; }
        [JsonProperty("recordType")]
        public string RecordType { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("semanticTags")]
        public List<string> SemanticTags { get; set; }
        [JsonProperty("placementTags")]
        public List<string> PlacementTags { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("fifaProducts")]
        public List<string> FifaProducts { get; set; }
    }
}
