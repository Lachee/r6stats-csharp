using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Responses
{
    /// <summary>
    /// Error Response for TooManyRequests
    /// </summary>
    internal class RateLimitExceededResponse
    {
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("Error")]
        public string Error { get; private set; }
        [JsonProperty("limit")]
        public string Limit { get; private set; }
        [JsonProperty("used")]
        public int Used { get; private set; }
    }
}
