using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Responses
{
    /// <summary>
    /// Generic Response
    /// </summary>
    public class BaseResponse
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("ubisoft_id")]
        public string UbisoftId { get; set; }

        [JsonProperty("uplay_id")]
        public string UplayId { get; set; }

        [JsonProperty("avatar_url_146")]
        public string AvatarUrl146 { get; set; }

        [JsonProperty("avatar_url_256")]
        public string AvatarUrl256 { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
