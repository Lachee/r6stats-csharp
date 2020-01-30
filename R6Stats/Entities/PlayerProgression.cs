using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    /// <summary>
    /// Details such as the player's level and total experience.
    /// </summary>
    public class PlayerProgression
    {
        /// <summary>
        /// Current level of the player
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; private set; }

        /// <summary>
        /// Probability of their next lootbox
        /// </summary>
        [JsonProperty("lootbox_probability")]
        public float LootboxProbability { get; private set; }

        /// <summary>
        /// Total experience
        /// </summary>
        [JsonProperty("total_xp")]
        public long TotalXP { get; private set; }
    }
}
