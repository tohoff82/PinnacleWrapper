using System;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class MoneyLine
    {
        [JsonProperty(PropertyName = "awayPrice")]
        public double AwayPrice { get; set; }

        [JsonProperty(PropertyName = "homePrice")]
        public double HomePrice { get; set; }

        [JsonProperty(PropertyName = "drawPrice")]
        public double DrawPrice { get; set; }
    }
}
