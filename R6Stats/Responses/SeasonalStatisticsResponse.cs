using Newtonsoft.Json;
using R6Stats.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Responses
{
    public class SeasonalStatisticsResponse : BaseResponse
    {
        [JsonProperty("seasons")]
        public IReadOnlyDictionary<string, Season> Seasons { get; private set; }
    }
}
