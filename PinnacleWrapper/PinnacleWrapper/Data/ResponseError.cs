using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class ResponseError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
