using System;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class Spread
    {
        [JsonProperty(PropertyName = "awaySpread")]
        public double AwaySpread { get; set; }

        [JsonProperty(PropertyName = "awayPrice")]
        public double AwayPrice { get; set; }

        [JsonProperty(PropertyName = "homeSpread")]
        public double HomeSpread { get; set; }

        [JsonProperty(PropertyName = "homePrice")]
        public double HomePrice { get; set; }
    }
}
