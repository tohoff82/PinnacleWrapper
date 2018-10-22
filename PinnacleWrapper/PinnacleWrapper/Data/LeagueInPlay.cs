using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class LeagueInPlay
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("events")]
        public List<EventInPlay> EventsList { get; set; }
    }

    public class EventInPlay
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("elapsed")]
        public int Elapsed { get; set; }

        //State
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
