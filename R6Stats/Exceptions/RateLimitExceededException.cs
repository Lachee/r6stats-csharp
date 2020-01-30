using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Exceptions
{
    /// <summary>
    /// Rate Limit Exceeded exceptions will occure when R6Stats returns exceeded exceptions.
    /// <para>This may happen for incorrectly configured Rate Limits. Avoid hitting this exception for the key maybe revoked.</para>
    /// </summary>
    public class RateLimitExceededException : Exception
    {
        internal RateLimitExceededException() : base("RateLimit has been exceeded. Configured rate limits maybe incorrect. Continued hits may result in key revoke.") { }
    }
}
