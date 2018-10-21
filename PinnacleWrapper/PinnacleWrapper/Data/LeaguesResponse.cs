using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class LeaguesResponse
    {
        [JsonProperty("leagues")]
        public List<League> Leagues { get; set; }
    }
}
