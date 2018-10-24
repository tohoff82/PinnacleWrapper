using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleWrapper.Data
{
    public class TeaserGroup
    {
        [JsonProperty("id")]
        public long GroupId { get; set; }

        [JsonProperty("name")]
        public string GroupName { get; set; }

        [JsonProperty("teasers")]
        public List<Teaser> Teasers { get; set; }
    }

    public class Teaser
    {
        [JsonProperty("id")]
        public long TeaserId { get; set; }

        [JsonProperty("description")]
        public string TeaserDescription { get; set; }

        [JsonProperty("sportId")]
        public int SportId { get; set; }

        [JsonProperty("minLegs")]
        public int MinLegs { get; set; }

        [JsonProperty("maxLegs")]
        public int MaxLegs { get; set; }

        [JsonProperty("sameEventOnly")]
        public bool SameEventOnly { get; set; }

        [JsonProperty("payouts")]
        public List<Payout> Payouts { get; set; }

        [JsonProperty("leagues")]
        public List<TeaserLeague> TeaserLeagues { get; set; }

    }

    public class Payout
    {
        [JsonProperty("numberOfLegs")]
        public int NumberOfLegs { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }

    public class TeaserLeague
    {
        [JsonProperty("id")]
        public int LeagueId { get; set; }

        [JsonProperty("spread")]
        public TLSpread Spread { get; set; }

        [JsonProperty("total")]
        public TLSpread Total { get; set; }

    }

    public class TLSpread
    {
        [JsonProperty("points")]
        public double Points { get; set; }
    }

    public class TLTotal
    {
        [JsonProperty("points")]
        public double Points { get; set; }
    }
}
