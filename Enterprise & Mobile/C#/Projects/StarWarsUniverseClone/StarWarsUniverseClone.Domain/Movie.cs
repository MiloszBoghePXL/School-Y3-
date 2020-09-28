﻿using Newtonsoft.Json;
using System;

namespace StarWarsUniverseClone.Domain
{
    public class Movie : Resource
    {
        public string Title { get; set; }
        [JsonProperty(PropertyName = "episode_id")]
        public int EpisodeId { get; set; }
        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }
    }
}
