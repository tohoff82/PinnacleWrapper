using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class Period
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("spreadDescription")]
        public string SpreadDescription { get; set; }

        [JsonProperty("moneylineDescription")]
        public string MoneylineDescription { get; set; }

        [JsonProperty("totalDescription")]
        public string TotalDescription { get; set; }

        [JsonProperty("team1TotalDescription")]
        public string Team1TotalDescription { get; set; }

        [JsonProperty("team2TotalDescription")]
        public string Team2TotalDescription { get; set; }

        [JsonProperty("spreadShortDescription")]
        public string SpreadShortDescription { get; set; }

        [JsonProperty("moneylineShortDescription")]
        public string MoneylineShortDescription { get; set; }

        [JsonProperty("totalShortDescription")]
        public string TotalShortDescription { get; set; }

        [JsonProperty("team1TotalShortDescription")]
        public string Team1TotalShortDescription { get; set; }

        [JsonProperty("team2TotalShortDescription")]
        public string Team2TotalShortDescription { get; set; }
    }
}
