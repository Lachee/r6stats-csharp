using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    /// <summary>
    /// Statistic Response for generic stats.
    /// </summary>
    public class GenericStatisticsGroup
    {
        /// <summary>
        /// General Statistics
        /// </summary>
        [JsonProperty("general")]
        public GeneralStatistics General { get; private set; }

        /// <summary>
        /// Statistics for Queued Game Modes (Casual, Ranked, Other).
        /// </summary>
        [JsonProperty("queue")]
        public QueueStatisticsGroup Queue { get; private set; }

        /// <summary>
        /// Statistics for Gamemodes.
        /// </summary>
        [JsonProperty("gamemode")]
        public GamemodeStatisticGroup Gamemode { get; private set; }

        [JsonProperty("timestamps")]
        public GenericTimestamps Timestamps { get; private set; }

        public class GenericTimestamps
        {
            [JsonProperty("created")]
            public DateTime Created { get; private set; }
            [JsonProperty("last_updated")]
            public DateTime LastUpdated { get; private set; }
        }
    }
}
