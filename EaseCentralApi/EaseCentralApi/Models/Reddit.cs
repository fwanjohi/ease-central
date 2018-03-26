using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EaseCentralApi.Models
{
    public class Reddit
    {
        [JsonProperty("reddit_id")]
        public string RedditId { get; set; }

        [JsonProperty("permalink")]
        public string PermLink { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
        
    }
}