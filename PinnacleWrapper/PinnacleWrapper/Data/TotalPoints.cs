using System;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class TotalPoints
    {
        [JsonProperty(PropertyName = "@altLineId")]
        public int? AltLineId;

        [JsonProperty(PropertyName = "points")]
        public decimal Points;

        [JsonProperty(PropertyName = "overPrice")]
        public decimal OverPrice;

        [JsonProperty(PropertyName = "underPrice")]
        public decimal UnderPrice;
    }
}
