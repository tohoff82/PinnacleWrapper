using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class CancellationReason
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
