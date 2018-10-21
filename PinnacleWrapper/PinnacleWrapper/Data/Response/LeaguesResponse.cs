using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data.Response
{
    public class LeaguesResponse
    {
        [JsonProperty("leagues")]
        public List<League> Leagues { get; set; }
    }
}
