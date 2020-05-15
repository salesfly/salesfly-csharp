using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

using Salesfly.Exceptions;

namespace Salesfly.Api
{
    /// <summary>
    /// The Usage API is a free REST API that provides programmatic access and visibility into activity consumption across products for your account.
    /// </summary>
    public class Usage : ApiBase
    {
        private Usage() { }

        /// <summary>
        /// Retrieves the usage for the current subscription period.
        /// </summary>
        /// <returns>
        /// APIUsage struct with usage data.
        /// </returns>
        public static async Task<APIUsage> GetAsync()
        {
            var response = await GetJSON("/v1/usage");
            return await ParseResponse<APIUsage>(response);
        }

        /// <summary>
        /// APIUsage model contains the number of allowed and used requests.
        /// </summary>
        public class APIUsage
        {
            ///
            /// The number of allowed requests you can make every month.
            ///
            [JsonProperty("allowed")]
            public int Allowed { get; set; }

            ///
            /// The number of requests you have made this month.
            ///
            [JsonProperty("used")]
            public int Used { get; set; }
        }
    }
}