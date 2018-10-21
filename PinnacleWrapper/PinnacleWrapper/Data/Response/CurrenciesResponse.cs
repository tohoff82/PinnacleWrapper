using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data.Response
{
    public class CurrenciesResponse
    {
        [JsonProperty("currencies")]
        public List<Currency> Currencies { get; set; }
    }
}
