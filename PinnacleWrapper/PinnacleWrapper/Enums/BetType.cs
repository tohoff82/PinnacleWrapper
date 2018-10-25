using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BetType
    {
        SPREAD,
        MONEYLINE,
        TOTAL_POINTS,
        TEAM_TOTAL_POINTS
    }
}
