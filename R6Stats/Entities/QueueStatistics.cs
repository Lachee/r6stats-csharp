using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    public class QueueStatisticsGroup
    {
        /// <summary>
        /// Casual Statistics
        /// </summary>
        [JsonProperty("casual")]
        public QueueStatistics Casual { get; private set; }

        /// <summary>
        /// Ranked Statistics
        /// </summary>
        [JsonProperty("ranked")]
        public QueueStatistics Ranked { get; private set; }

        /// <summary>
        /// Other Statistics
        /// </summary>
        [JsonProperty("other")]
        public QueueStatistics Other { get; private set; }
    }

    /// <summary>
    /// A group of statistics for a queue gamemode.
    /// </summary>
    public class QueueStatistics
    {
        [JsonProperty("deaths")]
        public int Deaths { get; private set; }
        [JsonProperty("draws")]
        public int Draws { get; private set; }
        [JsonProperty("games_played")]
        public int GamesPlayed { get; private set; }
        [JsonProperty("kd")]
        public float KillDeathRatio { get; private set; }
        [JsonProperty("kills")]
        public int Kills { get; private set; }
        [JsonProperty("losses")]
        public int Losses { get; private set; }
        [JsonProperty("play_time")]
        public long PlayTime { get; private set; }
        [JsonProperty("wins")]
        public int Wins { get; private set; }
        [JsonProperty("wl")]
        public float WinLossRatio { get; private set; }
    }
}
