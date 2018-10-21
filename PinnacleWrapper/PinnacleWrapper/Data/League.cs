using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class League
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("homeTeamType")]
        public string HomeTeamType { get; set; }

        [JsonProperty("hasOfferings")]
        public bool HasOfferings { get; set; }

        [JsonProperty("container")]
        public string Container { get; set; }

        [JsonProperty("allowRoundRobins")]
        public string AllowRoundRobins { get; set; }

        [JsonProperty("leagueSpecialsCount")]
        public int LeagueSpecialsCount { get; set; }

        [JsonProperty("eventSpecialsCount")]
        public int EventSpecialsCount { get; set; }

        [JsonProperty("eventCount")]
        public int EventCount { get; set; }
    }
}
