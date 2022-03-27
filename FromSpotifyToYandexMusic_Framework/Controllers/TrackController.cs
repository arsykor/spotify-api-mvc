using FromSpotifyToYandexMusic_Framework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FromSpotifyToYandexMusic_Framework.Controllers
{
    public class TrackController : Controller
    {
        static List<Track> trackList = new List<Track>();

        private readonly TrackContext db = new TrackContext();

        static bool DataIsUploaded = false;

        // GET: Tracks
        public ActionResult Index()
        {
            trackList = TracksRepository.trackList;

            ViewData["Ammount"] = trackList.Count();
            ViewData["Data"] = DataIsUploaded;

            return View(trackList);
        }

        //Write tracks to the db
        public ActionResult AddToDb()
        {
            if (trackList.Any())
            {
                List<TrackModelForDB> trackListDb = new List<TrackModelForDB>();

                foreach (var track in trackList)
                {
                    trackListDb.Add(new TrackModelForDB
                    {
                        SpotifyInternalId = track.Id,
                        Name = track.Name,
                        DurationMs = track.DurationMs,
                        Explicit = track.Explicit,
                        Href = track.Href,
                        IsLocal = track.IsLocal,
                        Popularity = track.Popularity,
                        PreviewUrl = track.PreviewUrl,
                        TrackNumber = track.TrackNumber,
                        Uri = track.Uri
                    });
                };

                foreach (var track in trackListDb)
                {
                    db.Track.Add(track); //ошибка
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Track/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int id)
        {
            return View(id);
        }

        // POST: Track/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Track/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //public static string LoadJson()
        //{
        //    using (StreamReader r = new StreamReader(@"C:\Users\ArsenijKorolkov\Desktop\SpoticToWin\SongsJSON.txt"))
        //    {
        //        string JsonString = r.ReadToEnd();

        //        return JsonString;
        //    }
        //}
    }
}
