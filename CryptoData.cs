using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Crypto
{
    public class CryptoData
    {
        [JsonProperty(PropertyName = "status")]
        public Status status { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<Cryptdata> data { get; set; }
    }

    public class Status
    {
        [JsonProperty(PropertyName = "timestamp")]
        public string timestamp { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public Int32 error_code { get; set; }

        [JsonProperty(PropertyName = "elapsed")]
        public Int32 elapsed { get; set; }

        [JsonProperty(PropertyName = "credit_count")]
        public Int32 credit_count { get; set; }

        [JsonProperty(PropertyName = "total_count")]
        public Int32 total_count { get; set; }
    }
}

public class Cryptdata
{
    [JsonProperty(PropertyName = "id")]
    public Int32 id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string name { get; set; }

    [JsonProperty(PropertyName = "symbol")]
    public string symbol { get; set; }

    [JsonProperty(PropertyName = "slug")]
    public string slug { get; set; }

    [JsonProperty(PropertyName = "num_market_pairs")]
    public Int32 num_market_pairs { get; set; }

    [JsonProperty(PropertyName = "date_added")]
    public string date_added { get; set; }

    //[JsonProperty(PropertyName = "tags")]
    //public List<string> tags { get; set; }
    //[JsonProperty(PropertyName = "max_supply")]
    //Int32? max_supply { get; set; }
    [JsonProperty(PropertyName = "circulating_supply")]
    public string circulating_supply { get; set; }

    [JsonProperty(PropertyName = "total_supply")]
    public string total_supply { get; set; }

    [JsonProperty(PropertyName = "last_updated")]
    public string last_updated { get; set; }

    [JsonProperty(PropertyName = "platform")]
    public Platform? platform { get; set; }

    public class Platform
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "token_address")]
        public string token_address { get; set; }
    }
}