﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Salesfly.Api
{
    public class GeoLocation : ApiBase
    {
        private GeoLocation() { }

        public static async Task<IPLocation> GetAsync(string ip, string fields = null, bool hostname = false, bool security = false)
        {
            var query = makeQuery(fields, hostname, security);
            var response = await GetJSON("/v1/geoip/" + ip + query);
            return await ParseResponse<IPLocation>(response);
        }

        public static async Task<IPLocation> GetCurrentAsync(string fields = null, bool hostname = false, bool security = false)
        {
            return await GeoLocation.GetAsync("myip", fields, hostname, security);
        }

        public static async Task<List<IPLocation>> GetBulkAsync(string[] ipList, string fields = null, bool hostname = false, bool security = false)
        {
            var param = String.Join(",", ipList);
            var query = makeQuery(fields, hostname, security);
            var response = await GetJSON("/v1/geoip/" + param + query);
            return await ParseResponse<List<IPLocation>>(response);
        }

        private static string makeQuery(string fields = "", bool hostname = false, bool security = false)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(fields))
            {
                sb.Append("?fields=" + fields);
            }
            if (hostname)
            {
                sb.Append(sb.Length == 0 ? "?" : "&");
                sb.Append("hostname=true");
            }
            if (security)
            {
                sb.Append(sb.Length == 0 ? "?" : "&");
                sb.Append("security=true");
            }

            return sb.ToString();
        }

    }

    public class IPLocation
    {
        [JsonProperty("ip")]
        public string IpAddress { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } // ipv4 or ipv6       

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("continent_code")]
        public string ContinentCode { get; set; }

        [JsonProperty("country_name")]
        public string Country { get; set; }

        [JsonProperty("country_name_native")]
        public string CountryNative { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_code3")]
        public string CountryCode3 { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("region_name")]
        public string Region { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("latitude")]
        public double Latitude = 0;

        [JsonProperty("longitude")]
        public double Longitude = 0;

        [JsonProperty("phone_prefix")]
        public string PhonePrefix { get; set; }

        [JsonProperty("currencies")]
        public IPCurrency[] Currencies { get; set; }

        [JsonProperty("languages")]
        public IPLanguage[] Languages { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("flag_emoji")]
        public string FlagEmoji { get; set; }

        [JsonProperty("is_eu")]
        public bool IsEU { get; set; }

        [JsonProperty("internet_tld")]
        public string TLD { get; set; }

        [JsonProperty("timezone")]
        public IPTimezone Timezone { get; set; }

        [JsonProperty("security")]
        public IPSecurity Security { get; set; }
    }

    public class IPCurrency
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("num_code")]
        public string NumericCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_plural")]
        public string PluralName { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("symbol_native")]
        public string NativeSymbol { get; set; }

        [JsonProperty("decimal_digits")]
        public int DecimalDigits { get; set; }

        public IPCurrency() { }
    }

    public class IPLanguage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("code2")]
        public string Code2 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("native_name")]
        public string NativeName { get; set; }

        [JsonProperty("rtl")]
        public bool RTL = false;

        public IPLanguage() { }
    }

    public class IPTimezone
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("localtime")]
        public DateTime LocalTime { get; set; }

        [JsonProperty("gmt_offset")]
        public int GMTOffset { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("daylight_saving")]
        public bool DaylightSaving { get; set; }

        public IPTimezone() { }
    }

    public class IPSecurity
    {
        public IPSecurity() { }

        [JsonProperty("is_proxy")]
        public bool IsProxy { get; set; }

        [JsonProperty("proxy_type")]
        public string ProxyType { get; set; }

        [JsonProperty("is_crawler")]
        public bool IsCrawler { get; set; }

        [JsonProperty("crawler_name")]
        public string CrawlerName { get; set; }

        [JsonProperty("crawler_type")]
        public string CrawlerType { get; set; }

        [JsonProperty("is_tor")]
        public bool IsTOR { get; set; }

        [JsonProperty("threat_level")]
        public string ThreatLevel { get; set; }

        [JsonProperty("threat_types")]
        public string[] ThreatTypes { get; set; }
    }
}
