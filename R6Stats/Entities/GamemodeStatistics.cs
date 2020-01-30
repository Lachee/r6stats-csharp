using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    public class GamemodeStatisticGroup
    {
        [JsonProperty("bomb")]
        public BombStatistics Bomb { get; private set; }

        [JsonProperty("hostage")]
        public HostageStatistics Hostage { get; private set; }

        [JsonProperty("secure_area")]
        public SecureAreaStatistics SecureArea { get; private set; }
    }

    public class GamemodeStatistics
    {
        [JsonProperty("best_score")]
        public int BestScore { get; private set; }
        [JsonProperty("games_played")]
        public int GamesPlayed { get; private set; }
        [JsonProperty("losses")]
        public int Losses { get; private set; }
        [JsonProperty("wins")]
        public int Wins { get; private set; }
        [JsonProperty("wl")]
        public float WinLossRatio { get; private set; }
        [JsonProperty("playtime")]
        public long PlayTime { get; private set; }
    }

    public class BombStatistics : GamemodeStatistics { }

    public class HostageStatistics : GamemodeStatistics
    {
        [JsonProperty("extactions_denied")]
        public int ExtractionsDenied { get; private set; }
    }

    public class SecureAreaStatistics : GamemodeStatistics
    {
        [JsonProperty("kills_as_attacker_in_objective")]
        public int KillsAsAttackerInObjective { get; private set; }
        [JsonProperty("kills_as_defender_in_objective")]
        public int KillsAsDefenderInObjective { get; private set; }
        [JsonProperty("times_objective_secured")]
        public int TimesObjectiveSecured { get; private set; }
    }
}
