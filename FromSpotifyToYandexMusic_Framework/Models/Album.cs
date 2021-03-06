using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Models
{
    public class Album
    {
        [JsonProperty("album_type")]
        public AlbumTypeEnum AlbumType { get; set; }

        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }

        [JsonProperty("available_markets")]
        public string[] AvailableMarkets { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("release_date")]
        public ReleaseDate ReleaseDate { get; set; }

        [JsonProperty("release_date_precision")]
        public ReleaseDatePrecision ReleaseDatePrecision { get; set; }

        [JsonProperty("total_tracks")]
        public long TotalTracks { get; set; }

        [JsonProperty("type")]
        public AlbumTypeEnum Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}