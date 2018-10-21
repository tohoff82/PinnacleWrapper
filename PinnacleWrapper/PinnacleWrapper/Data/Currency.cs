using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class Currency
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }
}
