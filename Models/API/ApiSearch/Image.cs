namespace Models.API.ApiSearch
{
    using Newtonsoft.Json;

    public class Image
    {
        [JsonProperty("src")]
        public string Src { get; set; }
        [JsonProperty("alt")]
        public string Alt { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("focalPosX")]
        public int? FocalPosX { get; set; }
        [JsonProperty("focalPosY")]
        public int? FocalPosY { get; set; }
    }
}
