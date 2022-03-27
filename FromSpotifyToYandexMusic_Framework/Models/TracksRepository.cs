using FromSpotifyToYandexMusic_Framework.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Models
{
    public static class TracksRepository
    {
        public static Item[] Items { get; set; }

        public static List<Track> trackList = new List<Track>();

        public static List<Item[]> listItems = new List<Item[]>();

        public static void AddTracksToList()
        {
            //foreach (var item in Items)
            //{
            //    trackList.Add(item.Track);
            //}

            foreach (var itemArray in listItems)
            {
                foreach (var item in itemArray)
                {
                    trackList.Add(item.Track);
                }
            }
        }
    }
}