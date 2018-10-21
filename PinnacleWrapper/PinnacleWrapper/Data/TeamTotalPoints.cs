using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class TeamTotalPoints
    {
        [JsonProperty(PropertyName = "homeTeamTotal")]
        private TotalPoints HomeTeamTotal;

        [JsonProperty(PropertyName = "awayTeamTotal")]
        private TotalPoints AwayTeamTotal;
    }
}
