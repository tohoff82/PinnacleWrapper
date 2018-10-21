using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data.Response
{
    public class PeriodResponse
    {
        [JsonProperty("periods")]
        public List<Period> Periods { get; set; }
    }
}
