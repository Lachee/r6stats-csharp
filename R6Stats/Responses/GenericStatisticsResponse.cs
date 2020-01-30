using Newtonsoft.Json;
using R6Stats.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Responses
{
    public class GenericStatisticsResponse : BaseResponse
    {
        /// <summary>
        /// The Player's known aliases
        /// </summary>
        [JsonProperty("aliases")]
        public PlayerAlias[] Aliases { get; private set; }

        /// <summary>
        /// The progression the player has made on their account
        /// </summary>
        [JsonProperty("progression")]
        public PlayerProgression Progression { get; private set; }

        /// <summary>
        /// Generic Stats
        /// </summary>
        [JsonProperty("stats")]
        public GenericStatisticsGroup Stats { get; private set; }


    }
}
