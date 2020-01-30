using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn, ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SeasonStatistics
    {
        [JsonProperty("season_id")]
        public int SeasonId { get; private set; }

        [JsonProperty("region")]
        public string Region { get; private set; }

        [JsonProperty("abandons")]
        public int Abandons { get; private set; }

        [JsonProperty("losses")]
        public int Losses { get; private set; }

        /// <summary>
        /// Maximum MMR achieved
        /// </summary>
        [JsonProperty("max_mmr")]
        public uint MaxMMR { get => m_maxMMR; private set { m_maxMMR = value; MaxRank = RankUtilities.GetRank(m_maxMMR); } }
        private uint m_maxMMR;

        /// <summary>
        /// Maximum Rank achieved, relative to the current <see cref="Rank"/>
        /// </summary>
        public Rank MaxRank { get; private set; }

        /// <summary>
        /// Maximum rank index. This is unrelated to <see cref="Rank"/> as it varies between seasons as Ubisoft changes rank requirements.
        /// </summary>
        [JsonProperty("max_rank")]
        public int MaxRankIndex { get; private set; }

        /// <summary>
        /// Current MMR
        /// </summary>
        [JsonProperty("mmr")]
        public uint MMR {
            get => m_mmr;
            private set {
                //Set the MMR value and update our ranks
                m_mmr = value;
                RankUtilities.GetRank(m_mmr, out m_prevRank, out m_rank, out m_nextRank);
            }
        }
        private uint m_mmr;
        private Rank m_prevRank, m_rank, m_nextRank;

        /// <summary>
        /// The rank below.
        /// </summary>
        public Rank PreviousRank => m_prevRank;

        /// <summary>
        /// The rank.
        /// </summary>
        public Rank Rank => m_rank;

        /// <summary>
        /// The rank above.
        /// </summary>
        public Rank NextRank => m_nextRank;

        /// <summary>
        /// The rank index. This is unrelated to <see cref="Rank"/> as it varies between seasons as Ubisoft changes rank requirements.
        /// </summary>
        [JsonProperty("rank")]
        public int RankIndex { get; private set; }
        [JsonProperty("skill_mean")]
        public float SkillMean { get; private set; }
        [JsonProperty("skill_standard_deviation")]
        public float SkillStandardDivation { get; private set; }
        [JsonProperty("created_for_date")]
        public DateTime CreatedForData { get; private set; }
        [JsonProperty("wins")]
        public int Wins { get; private set; }
        [JsonProperty("kills")]
        public int Kills { get; private set; }
        [JsonProperty("deaths")]
        public int Deaths { get; private set; }
        [JsonProperty("last_match_mmr_change")]
        public int LastMatchMMRChange { get; private set; }
        [JsonProperty("last_match_skill_mean_change")]
        public float LastMatchSkillMeanChange { get; private set; }
        [JsonProperty("last_match_skill_standard_deviation_change")]
        public float LastMatchSkillStandardDeviationChange { get; private set; }
        [JsonProperty("last_match_result")]
        public int LastMatchResult { get; private set; }
        [JsonProperty("champions_rank_position")]
        public int ChampionsRankPosition { get; private set; }
        [JsonProperty("rank_text")]
        public string RankText { get; private set; }
        [JsonProperty("rank_image")]
        public string RankImage { get; private set; }
        [JsonProperty("max_rank_text")]
        public string MaxRankText { get; private set; }
        [JsonProperty("max_rank_image")]
        public string MaxRankImage { get; private set; }
    }
}
