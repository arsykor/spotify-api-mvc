using FromSpotifyToYandexMusic_Framework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace SpotifyRequestsTests
{
    public class TracksRequestsTests
    {
        public static List<Track> trackList = new List<Track>();

        [Fact]
        public void GetTracksAsync_RequestReturnsTwentyFirstTracksOfUser_ReturnsTrue()
        {
            string jsonSongs = LoadJson();

            Welcome welcome = Welcome.FromJson(jsonSongs);
            Item[] Items = welcome.Items;

            foreach (var item in Items)
            {
                trackList.Add(item.Track);
            }

            int AmmountOfReceivedSongs = trackList.Count();

            Assert.True(AmmountOfReceivedSongs == 20);
        }

        public static string LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\ArsenijKorolkov\Desktop\SpoticToWin\SongsJSON.txt"))
            {
                string JsonString = r.ReadToEnd();

                return JsonString;
            }
        }
    }
}
