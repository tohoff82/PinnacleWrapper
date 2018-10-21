using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class SportsResponse
    {
        [JsonProperty("sports")]
        public List<Sport> Sports { get; set; }
    }
}
