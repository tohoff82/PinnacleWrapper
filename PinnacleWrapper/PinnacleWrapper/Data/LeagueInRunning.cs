using Newtonsoft.Json;
using PinnacleWrapper.Enums;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class LeagueInRunning
    {
        [JsonProperty("id")]
        public int LeagueId { get; set; }

        [JsonProperty("events")]
        public List<EventInRuning> InRuningEvents { get; set; }
    }

    public class EventInRuning
    {
        [JsonProperty("id")]
        public long EventId { get; set; }

        [JsonProperty("state")]
        public InRunningState State { get; set; }

        [JsonProperty("elapsed")]
        public int ElapsedTime { get; set; }

        //State - Enum
        //1 = First half in progress
        //2 = Half time in progress
        //3 = Second half in progress
        //4 = End of regular time
        //5 = First half extra time in progress
        //6 = Extra time half time in progress
        //7 = Second half extra time in progress
        //8 = End of extra time
        //9 = End of Game
        //10 = Game is temporary suspended
        //11 = Penalties in progress
    }
}
