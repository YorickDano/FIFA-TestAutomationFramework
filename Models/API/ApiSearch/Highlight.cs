namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Highlight
    {
        [JsonProperty("title")]
        public List<string> Title { get; set; }
        [JsonProperty("body")]
        public List<string> Body { get; set; }
        [JsonProperty("description")]
        public List<string> Description { get; set; }
    }
}
