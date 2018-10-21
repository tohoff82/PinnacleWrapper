using System;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class BetAmount
    {
        [JsonProperty(PropertyName = "spread")]
        public double Spread { get; set; }

        [JsonProperty(PropertyName = "moneyLine")]
        public double MoneyLine { get; set; }
    }
}
