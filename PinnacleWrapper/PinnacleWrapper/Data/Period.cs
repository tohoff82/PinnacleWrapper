using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class Period
    {
        [JsonProperty(PropertyName = "lineId")]
        public long LineId { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "cutoffDateTime")]
        public DateTime CutoffDateTime { get; set; }

        [JsonProperty(PropertyName = "spreads")]
        public List<Spread> Spreads { get; set; }

        [JsonProperty(PropertyName = "moneyLine")]
        public MoneyLine MoneyLine { get; set; }

        [JsonProperty(PropertyName = "totals")]
        public List<TotalPoints> Totals { get; set; }

        //[JsonProperty(PropertyName = "teamTotals")]
        //public TeamTotalPoints TeamTotalPoints { get; set; }      // temporarily unused

        [JsonProperty(PropertyName = "maxBetAmount")]
        public BetAmount MaxBetAmount { get; set; }
    }
}
