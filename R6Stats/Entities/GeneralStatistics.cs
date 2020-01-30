using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    public class GeneralStatistics
    {
        [JsonProperty("assists")]
        public int Assists { get; private set; }
        [JsonProperty("barricades_deployed")]
        public int BarricadesDeployed { get; private set; }
        [JsonProperty("blind_kills")]
        public int BlindKills { get; private set; }
        [JsonProperty("bullets_fired")]
        public long BulletsFired { get; private set; }
        [JsonProperty("bullets_hit")]
        public long BulletsHit { get; private set; }
        [JsonProperty("dbnos")]
        public int DBNOs { get; private set; }
        [JsonProperty("deaths")]
        public int Deaths { get; private set; }
        [JsonProperty("distance_travelled")]
        public ulong DistanceTravelled { get; private set; }
        [JsonProperty("drwas")]
        public int Draws { get; private set; }
        [JsonProperty("gadgets_destroyed")]
        public int GadgetsDestroyed { get; private set; }
        [JsonProperty("games_played")]
        public int GamesPlayed { get; private set; }
        [JsonProperty("headshots")]
        public int Headshots { get; private set; }
        [JsonProperty("kd")]
        public float KillDeathRatio { get; private set; }
        [JsonProperty("kills")]
        public int Kills { get; private set; }
        [JsonProperty("losses")]
        public int Losses { get; private set; }
        [JsonProperty("melee_kills")]
        public int MeleeKills { get; private set; }
        [JsonProperty("penetration_kills")]
        public int PenetrationKills { get; private set; }
        [JsonProperty("play_time")]
        public long PlayTime { get; private set; }
        [JsonProperty("rappel_breaches")]
        public int RappelBreaches { get; private set; }
        [JsonProperty("reinforcements_deployed")]
        public int ReinforcementsDeployed { get; private set; }
        [JsonProperty("revives")]
        public int Revives { get; private set; }
        [JsonProperty("suicides")]
        public int Suicides { get; private set; }
        [JsonProperty("wins")]
        public int Wins { get; private set; }
        [JsonProperty("wl")]
        public float WinLossRatio { get; private set; }
    }
}
