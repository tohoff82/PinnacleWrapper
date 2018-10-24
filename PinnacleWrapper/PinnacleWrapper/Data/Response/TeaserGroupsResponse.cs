using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data.Response
{
    public class TeaserGroupsRespose
    {
        [JsonProperty("teaserGroups")]
        public List<TeaserGroup> TeaserGroups { get; set; }
    }
}
