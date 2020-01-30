using Newtonsoft.Json;
using R6Stats.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Responses
{
    public class OperatorStatisticsResponse : BaseResponse
    {
        [JsonProperty("operators")]
        public OperatorStatistics[] Operators { get; private set; }
    }
}
