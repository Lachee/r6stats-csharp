using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    /// <summary>
    /// Known Aliases
    /// </summary>
    public class PlayerAlias
    {
        /// <summary>
        /// Alias Username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        /// Last time the alias was seen.
        /// </summary>
        [JsonProperty("last_seen_at")]
        public DateTime LastSeenAt { get; private set; }
    }
}
