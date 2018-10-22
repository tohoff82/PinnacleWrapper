using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleWrapper.Data
{
    public class SportInPlay
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("leagues")]
        public List<LeagueInPlay> LeaguesList { get; set; }
    }
}
