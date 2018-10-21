using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class League
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("homeTeamType")]
        public string HomeTeamType;

        [JsonProperty("hasOfferings")]
        public bool HasOfferings;

        [JsonProperty("allowRoundRobins")]
        public string AllowRoundRobins;
    }
}
