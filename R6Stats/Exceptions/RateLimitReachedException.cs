using R6Stats.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Exceptions
{
    /// <summary>
    /// The internal rate limits have been reached. This exception is safe and can be hit numerous times, but it's best avoided.
    /// <para>If you continously get this exeception, consider reaching out to R6Stats and requesting increased limits.</para>
    /// </summary>
    public class RateLimitReachedException : Exception
    {
        public RateLimit RateLimit { get; }
        public int Calls { get; }
        internal RateLimitReachedException(int calls, RateLimit limit) : base ("Rate limit has been reached. Slow down or request new limits.") {
            Calls = calls;
            RateLimit = limit;
        }
    }
}
