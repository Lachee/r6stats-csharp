using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Entities
{
    /// <summary>
    /// RateLimit
    /// </summary>
    public struct RateLimit
    {
        /// <summary>
        /// How many calls can be made
        /// </summary>
        public int calls;

        /// <summary>
        /// How quickly can those calls me made
        /// </summary>
        public TimeSpan duration;
    }
}
