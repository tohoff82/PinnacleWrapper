using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data.Response
{
    public class CancellationReasonsResponse
    {
        [JsonProperty("cancellationReasons")]
        public List<CancellationReason> CancellationReasons { get; set; }
    }
}
