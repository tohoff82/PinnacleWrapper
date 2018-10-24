using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleWrapper.Data
{
    public class SportInRunning
    {
        [JsonProperty("id")]
        public int SportId { get; set; }

        [JsonProperty("leagues")]
        public List<LeagueInRunning> InRuningLeagues { get; set; }
    }
}
