using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Models
{
    public class TrackContext : DbContext
    {
        public DbSet<TrackModelForDB> Track { get; set; }
        //public DbSet<Album> Album { get; set; }
        //public DbSet<Artist> Artist { get; set; }
    }
}