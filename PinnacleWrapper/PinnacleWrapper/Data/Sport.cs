using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class Sport
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("hasOfferings")]
        public bool HasOfferings;

        [JsonProperty("leagueSpecialsCount")]
        public int leagueSpecialsCount;

        [JsonProperty("eventSpecialsCount")]
        public int eventSpecialsCount;

        [JsonProperty("eventCount")]
        public int eventCount;
    }
}
