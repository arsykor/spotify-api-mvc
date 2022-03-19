using FromSpotifyToYandexMusic_Framework.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FromSpotifyToYandexMusic_Framework.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            string tracksFromFile = LoadJson();
            string resp = "chech the app";

            //List<Track> Tracks = JsonConvert.DeserializeObject<List<Track>>(tracksFromFile);

            var welcome = Welcome.FromJson(tracksFromFile);

            int b = 1 + 1;

            return resp;
        }

        //public ActionResult Index()
        //{
        //    string tracksFromFile = LoadJson();

        //    List<Track> TasksList = JsonConvert.DeserializeObject<List<Track>>(tracksFromFile);

        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public static string LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\ArsenijKorolkov\Desktop\SpoticToWin\mySongs.txt"))
            {
                string JsonString = r.ReadToEnd();

                return JsonString;
            }
        }
    }
}