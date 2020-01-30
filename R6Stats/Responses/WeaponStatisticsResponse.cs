using Newtonsoft.Json;
using R6Stats.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Responses
{
    public class WeaponStatisticsResponse : BaseResponse
    {
        [JsonProperty("weapons")]
        public WeaponStatistics[] Weapons { get; private set; }
    }
}
