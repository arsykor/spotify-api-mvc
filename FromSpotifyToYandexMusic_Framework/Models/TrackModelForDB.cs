using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Models
{
    public class TrackModelForDB
    {
        [Key]
        public string Id { get; set; }

        public string SpotifyInternalId { get; set; }

        public string Name { get; set; }

        public long DurationMs { get; set; }

        public bool Explicit { get; set; }

        public Uri Href { get; set; }

        public bool IsLocal { get; set; }

        public long Popularity { get; set; }

        public Uri PreviewUrl { get; set; }

        public long TrackNumber { get; set; }

        public string Uri { get; set; }
    }
}