using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class PeriodResponse
    {
        [JsonProperty("periods")]
        public List<Period> Periods { get; set; }
    }
}
