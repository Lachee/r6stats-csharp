using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    /// <summary>
    /// Rank
    /// </summary>
    public enum Rank : uint
    {
        Unranked = 0,

        CopperV = 0001,
        CopperIV = 1200,
        CopperIII = 1300,
        CopperII = 1400,
        CopperI = 1500,

        BronzeV = 1600,
        BronzeIV = 1700,
        BronzeIII = 1800,
        BronzeII = 1900,
        BronzeI = 2000,

        SilverV = 2100,
        SilverIV = 2200,
        SilverIII = 2300,
        SilverII = 2400,
        SilverI = 2500,

        GoldIII = 2600,
        GoldII = 2800,
        GoldI = 3000,

        PlatinumIII = 3200,
        PlatinumII = 3600,
        PlatinumI = 4000,

        Diamond = 4400,
        Champion = 5000,
    }

    /// <summary>
    /// Utility functions to supliment the rank
    /// </summary>
    public static class RankUtilities
    {
        /// <summary>
        /// Gets the colour of the rank
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public static string GetColorHexadecimal(this Rank rank)
        {
            if (rank >= Rank.CopperV && rank < Rank.BronzeV)
                return "#ac1e13";

            if (rank >= Rank.BronzeV && rank < Rank.SilverV)
                return "#e0aa63";

            if (rank >= Rank.SilverV && rank < Rank.GoldIII)
                return "#c5c5c5";

            if (rank >= Rank.GoldIII && rank < Rank.PlatinumIII)
                return "#e5ce1b";

            if (rank >= Rank.PlatinumIII && rank < Rank.Diamond)
                return "#2abdc0";

            if (rank >= Rank.Diamond && rank < Rank.Champion)
                return "#a791ec";

            if (rank >= Rank.Champion)
                return "#941355";

            return null;
        }

        /// <summary>
        /// Gets the rank for the given MMR
        /// </summary>
        /// <param name="mmr"></param>
        /// <param name="previous"></param>
        /// <param name="current"></param>
        /// <param name="next"></param>
        public static void GetRank(uint mmr, out Rank previous, out Rank current, out Rank next)
        {
            var values = Enum.GetValues(typeof(Rank));
            previous = current = next = Rank.Unranked;

            for (int i = 1; i < values.Length; i++)
            {
                int ni = Math.Min(i + 1, values.Length - 1);

                previous = current;
                current = (Rank)values.GetValue(i);
                next = (Rank)values.GetValue(ni);

                //Break up the loop, we found the end
                if (mmr >= (uint)current && mmr < (uint)next)
                    return;
            }
        }

        /// <summary>
        /// Gets the rank from the given MMR
        /// </summary>
        /// <param name="mmr"></param>
        /// <returns></returns>
        public static Rank GetRank(uint mmr)
        {
            Rank previous = Rank.Unranked;
            foreach (var v in Enum.GetValues(typeof(Rank)))
            {
                if (mmr >= (uint)v)
                    previous = (Rank)v;

                if (mmr < (uint)v)
                    break;
            }

            return previous;
        }

        /// <summary>
        /// Gets the next rank for the given MMR
        /// </summary>
        /// <param name="mmr"></param>
        /// <returns></returns>
        public static Rank GetNextRank(uint mmr)
        {
            var values = Enum.GetValues(typeof(Rank));

            for (int i = 0; i < values.Length; i++)
            {
                int ni = Math.Min(i + 1, values.Length - 1);

                var cur = (Rank)values.GetValue(i);
                var nex = (Rank)values.GetValue(ni);

                if (mmr >= (uint)cur && mmr < (uint)nex)
                {
                    return nex;
                }
            }

            return Rank.Champion;
        }

        /// <summary>
        /// Gets the prevoius rank for the MMR
        /// </summary>
        /// <param name="mmr"></param>
        /// <returns></returns>
        public static Rank GetPreviousRank(uint mmr)
        {
            var values = Enum.GetValues(typeof(Rank));

            for (int i = 1; i < values.Length; i++)
            {
                int ni = Math.Min(i + 1, values.Length - 1);

                var cur = (Rank)values.GetValue(i);
                var nex = (Rank)values.GetValue(ni);

                if (mmr >= (uint)cur && mmr < (uint)nex)
                {
                    return (Rank)values.GetValue(i - 1);
                }
            }

            return Rank.Champion;
        }
    }
}
