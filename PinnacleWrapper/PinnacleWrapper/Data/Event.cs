using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PinnacleWrapper.Enums;

namespace PinnacleWrapper.Data
{
    public class Event
    {
        [JsonProperty(PropertyName = "startDateTime")]
        public DateTime StartDateTime { get; set; }

        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "isLive")]
        public string IsLiveString { get; set; }
        
        public bool isLive
        {
            get
            {
                return IsLiveString.Equals("Yes", StringComparison.OrdinalIgnoreCase);
            }

            set
            {
                IsLiveString = (value ? "Yes" : "No");
            }
        }

        [JsonProperty(PropertyName = "status")]
        public string StatusString { get; set; }
        
        public Status status
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(StatusString))
                {
                    switch (StatusString.ToLower())
                    {
                        case "o":
                            return Status.Open;
                        case "i":
                            return Status.LowerMaximum;
                        case "h":
                            return Status.Unavailable;
                        case "x":
                            return Status.Cancelled;
                        default:
                            throw new Exception("Unrecognized status: " + StatusString);
                    }
                }

                throw new Exception("No status string");
            }
        }

        [JsonProperty(PropertyName = "homeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty(PropertyName = "awayTeam")]
        public Team AwayTeam { get; set; }

        [JsonProperty(PropertyName = "periods")]
        public List<Period> Periods { get; set; }
    }
}
