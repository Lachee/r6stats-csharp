using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    public class WeaponCategory
    {
        [JsonProperty("category")]
        public string Category { get; private set; }
        [JsonProperty("kills")]
        public int Kills { get; private set; }
        [JsonProperty("deaths")]
        public int Deaths { get; private set; }
        [JsonProperty("kd")]
        public float KillDeathRatio { get; private set; }
        [JsonProperty("headshots")]
        public int Headshots { get; private set; }
        [JsonProperty("headshot_percentage")]
        public float HeadshotPercentage { get; private set; }
        [JsonProperty("times_chosen")]
        public int TimesChosen { get; private set; }
        [JsonProperty("bullets_fired")]
        public int BulletsFired { get; private set; }
        [JsonProperty("bullets_hit")]
        public int BulletsHit { get; private set; }
        [JsonProperty("created")]
        public DateTime Created { get; private set; }
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; private set; }
    }
}
