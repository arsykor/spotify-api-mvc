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
        public ActionResult Index()
        {
            return View();
        }

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