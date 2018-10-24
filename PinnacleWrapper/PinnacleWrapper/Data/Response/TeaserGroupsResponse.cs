using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data.Response
{
    public class TeaserGroupsResponse
    {
        [JsonProperty("teaserGroups")]
        public List<TeaserGroup> TeaserGroups { get; set; }
    }
}
