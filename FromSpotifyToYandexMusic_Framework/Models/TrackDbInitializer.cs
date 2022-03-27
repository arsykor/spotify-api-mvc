using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Models
{
    public class TrackDbInitializer : DropCreateDatabaseIfModelChanges<TrackContext>
    {
        protected override void Seed(TrackContext context)
        {
            context.Track.Add(new TrackModelForDB()
            {
                SpotifyInternalId = "123",
                Name = "Test",
                DurationMs = 1234,
                Explicit = true,
                Href = new Uri("https://api.spotify.com/v1/albums/5CZR6ljD0x9fTiS4mh9wMp"),
                IsLocal = false,
                Popularity = 1,
                PreviewUrl = new Uri("https://api.spotify.com/v1/albums/5CZR6ljD0x9fTiS4mh9wMp"),
                TrackNumber = 1,
                Uri = "qwerty"
            }) ;
        }
    }
}