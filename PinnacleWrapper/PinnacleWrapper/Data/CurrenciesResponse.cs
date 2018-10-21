using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class CurrenciesResponse
    {
        [JsonProperty(PropertyName = "currencies")]
        public List<Currency> Currencies;
    }
}
