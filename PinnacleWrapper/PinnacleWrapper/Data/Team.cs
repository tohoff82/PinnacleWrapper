using Newtonsoft.Json;


namespace PinnacleWrapper.Data
{
    public class Team
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "rotNum")]
        public int RotNum { get; set; }
    }
}
