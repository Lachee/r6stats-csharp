using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using R6Stats.Entities;
using R6Stats.Exceptions;
using R6Stats.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace R6Stats
{
    /// <summary>
    /// R6Stats client for fetching information about players.
    /// <para>To obtain a R6Stats API key, please contact support or join the Discord.</para>
    /// </summary>
    public class R6StatsClient
    {
        private const string BASE_URL = "https://api2.r6stats.com/public-api";

        /// <summary>
        /// Current RateLimit
        /// </summary>
        public RateLimit RateLimit { get; }

        private HttpClient client;
        private int requestsMade;
        private DateTime lastRatelimitBreak;
        private JsonSerializerSettings jsonSettings;

        /// <summary>
        /// Creates a new R6 client with default ratelimits.
        /// </summary>
        /// <param name="key">API Key from R6Stats.</param>
        public R6StatsClient(string key) : this(key, new RateLimit() { calls = 60, duration = TimeSpan.FromMinutes(1) }) { }

        /// <summary>
        /// Creates a new R6 client with a custom ratelimit.
        /// <para>If you require a rate limit greater than the default provided by <see cref="R6StatsClient"/> constructor, please contact R6Stats support before using this constructor.</para>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ratelimit"></param>
        public R6StatsClient(string key, RateLimit ratelimit)
        {
            RateLimit = ratelimit;
            requestsMade = 0;
            lastRatelimitBreak = DateTime.UtcNow;

            //Setup the HTTP client
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", $"Lachee R6Stat API Library");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", key);

            //Setup the JSON settings. This apparently doesnt work but keeping it here for future reference
            //https://www.newtonsoft.com/json/help/html/NamingStrategySnakeCase.htm
            jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
        }

        /// <summary>
        /// Gets generic statistics on the username.
        /// </summary>
        /// <param name="username">The username of the profile</param>
        /// <param name="platform">The platform the profile is on.</param>
        /// <returns></returns>
        public Task<GenericStatisticsResponse> GetGenericStatisticsAsync(string username, Platform platform)
        {
            return GetResponseAsync<GenericStatisticsResponse>($"/stats/{username}/{platform.ToString()}/generic");
        }

        /// <summary>
        /// Gets  operator statistics on the username.
        /// </summary>
        /// <param name="username">The username of the profile</param>
        /// <param name="platform">The platform the profile is on.</param>
        /// <returns></returns>
        public Task<OperatorStatisticsResponse> GetOperatorStatisticsAsync(string username, Platform platform)
        {
            return GetResponseAsync<OperatorStatisticsResponse>($"/stats/{username}/{platform.ToString()}/operators");
        }

        /// <summary>
        /// Gets seasonal statistics for the username.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public Task<SeasonalStatisticsResponse> GetSeasonalStatisticsAsync(string username, Platform platform)
        {
            return GetResponseAsync<SeasonalStatisticsResponse>($"/stats/{username}/{platform.ToString()}/seasonal");
        }

        /// <summary>
        /// Gets weapon category statistics for the username.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public Task<WeaponCategoryResponse> GetWeaponCategoriesAsync(string username, Platform platform)
        {
            return GetResponseAsync<WeaponCategoryResponse>($"/stats/{username}/{platform.ToString()}/weapon-categories");
        }

        /// <summary>
        /// Gets weapon category statistics for the username.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public Task<WeaponCategoryResponse> GetWeaponStatisticsAsync(string username, Platform platform)
        {
            return GetResponseAsync<WeaponCategoryResponse>($"/stats/{username}/{platform.ToString()}/weapons");
        }

        /// <summary>
        /// Gets a response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<T> GetResponseAsync<T>(string endpoint) where T : BaseResponse {

            //Check how long ago the last request was. If its greater than our ratelimit duration then reset it.
            var timeSince = DateTime.UtcNow - lastRatelimitBreak;
            if (timeSince > RateLimit.duration) {
                requestsMade = 0;
                lastRatelimitBreak = DateTime.UtcNow;
            }

            //Increment the request count
            requestsMade++;

            //Check if the requests exceed our limits (1 > 60)
            if (requestsMade > RateLimit.calls) {
                throw new RateLimitReachedException(requestsMade, RateLimit);
            }

            var response = await client.GetAsync(BASE_URL + endpoint);
            if (response.IsSuccessStatusCode)
            {
                //Just do normal stuff
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body, jsonSettings);
            }
            else if ((int)response.StatusCode == 429)
            {
                //Invalid, so lets get the response and return the error, updating our ratelimits
                var body = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<RateLimitExceededResponse>(body, jsonSettings);

                //Update our limits
                requestsMade = error.Used;
                throw new RateLimitExceededException();
            }
            else
            {
                //Throw an exception explaining what happened
                throw new HttpRequestException("Exception occured during the request: " + response.StatusCode);
            }
        }
    }
}
