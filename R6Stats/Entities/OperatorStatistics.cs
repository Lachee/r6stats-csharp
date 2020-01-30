using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    public class OperatorStatistics
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("ctu")]
        public string CTU { get; private set; }
        [JsonProperty("role")]
        public Role Role { get; private set; }
        [JsonProperty("kills")]
        public int Kills { get; private set; }
        [JsonProperty("deaths")]
        public int Deaths { get; private set; }
        [JsonProperty("kd")]
        public float KillDeathRatio { get; private set; }
        [JsonProperty("wins")]
        public int Wins { get; private set; }
        [JsonProperty("losses")]
        public int Losses { get; private set; }
        [JsonProperty("wl")]
        public float WinLossRatio { get; private set; }
        [JsonProperty("headshots")]
        public int Headshots { get; private set; }
        [JsonProperty("dbnos")]
        public int DBNOs { get; private set; }
        [JsonProperty("melee_kills")]
        public int MeleeKills { get; private set; }
        [JsonProperty("experience")]
        public ulong Experience { get; private set; }
        [JsonProperty("playtime")]
        public long PlayTime { get; private set; }
        [JsonProperty("badge_image")]
        public string BadgeImage { get; private set; }
        [JsonProperty("abilities")]
        public Ability[] Abilities { get; private set; }

    }

    public class Ability
    {
        [JsonProperty("ability")]
        public string Action { get; private set; }

        [JsonProperty("value")]
        public long Value { get; private set;  }
    }
}
