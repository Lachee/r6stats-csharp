using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    public class WeaponStatistics : WeaponCategory
    {
        [JsonProperty("weapon")]
        public string Name { get; private set; }
    }
}
