using FromSpotifyToYandexMusic_Framework.Models;
using FromSpotifyToYandexMusic_Framework.ModelViews;
using FromSpotifyToYandexMusic_Framework.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FromSpotifyToYandexMusic_Framework.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        public ActionResult Index()
        {
            return View();
        }

        // GET: Authorization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorization/Create
        [HttpPost]
        public ActionResult Create(Authorization auth)
        {
            Requests.Request.clientId = auth.clientId;
            Requests.Request.clientSecret = auth.clientSecret;

            var redirectAuth = Requests.Request.GetCode();

            Response.Redirect(redirectAuth);

            return View();
        }

        // GET: Authorization/InsertCode
        public ActionResult InsertCode()
        {
            return View();
        }

        // POST: Authorization/InsertToken
        [HttpPost]
        public async Task<ActionResult> InsertCode(string code)
        {
            Requests.Request.code = code;

            //Get token, based on received code

            string jsonString = await Requests.Request.GetToken();
            var welcomeToken = WelcomToken.FromJson(jsonString);
            string token = welcomeToken.AccessToken;

            //Get user's liked songs

            List<Item[]> listItems = new List<Item[]>();
            int offset = 0;

            while (true)
            {
                string mySongs = await Requests.TrackRequests.GetTracksAsync(token, offset);
                Welcome welcome = Welcome.FromJson(mySongs);
                Item[] item = welcome.Items;

                if (item.Length == 0)
                {
                    break;
                }

                listItems.Add(item);
                offset += 50;
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    string mySongs = await Requests.TrackRequests.GetTracksAsync(token, offset);
            //    Welcome welcome = Welcome.FromJson(mySongs);
            //    Item[] item = welcome.Items;
            //    listItems.Add(item);
            //    offset += 50;
            //}

            //Add item to TracksRepository
            TracksRepository.listItems = listItems;

            //Fill trackList with the data
            TracksRepository.AddTracksToList();

            //Write songs to the txt file
            //System.IO.File.WriteAllText(@"C:\Users\ArsenijKorolkov\Desktop\SpoticToWin\mySongs.txt", mySongs);

            return RedirectToAction("Index","Track");
        }
    }
}
