using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    public class Season
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("start_date")]
        public DateTime StartDate { get; private set; }
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; private set; }
        [JsonProperty("regions")]
        public IReadOnlyDictionary<string, SeasonStatistics[]> RegionHistory { get; private set; }
        [JsonIgnore]
        public SeasonStatistics[] this[string region] => RegionHistory[region];
    }

}
