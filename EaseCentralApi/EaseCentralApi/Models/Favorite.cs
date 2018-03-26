using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EaseCentralApi.Models
{
    public class Favorite
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("reddit_id")]
        public string RedditId { get; set; }

        [JsonProperty("tags")]
        public List<String> Tags { get; set; }
    }
}