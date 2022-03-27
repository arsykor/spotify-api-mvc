using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Requests
{
    static public class Request
    {
        static public string clientId { get; set; }

        static public string redirectUri { get; set; } = "https://localhost:8888";

        static public string clientSecret { get; set; }

        static public string code { get; set; }

        static public string idAlbum { get; set; }

        static public string scope { get; set; } = "user-library-read playlist-read-private";

        public static string GetCode()
        {
            using (HttpClient client = new HttpClient())
            {

                List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("response_type", "code"),
                    new KeyValuePair<string, string>("redirect_uri", redirectUri),
                    new KeyValuePair<string, string>("scope", scope),
                    new KeyValuePair<string, string>("show_dialog", "true")
                };

                var content = new FormUrlEncodedContent(queryParameters);
                string query = content.ReadAsStringAsync().Result;

                string finaleQuery = "https://accounts.spotify.com/authorize?" + query;

                //HttpResponseMessage resp = await client.GetAsync(finaleQuery);

                //var redirectAuth= resp.RequestMessage.RequestUri;

                //string responseBody = await resp.Content.ReadAsStringAsync();

                return finaleQuery;
            }
        }

        public static async Task<string> GetToken()
        {
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret));

            List<KeyValuePair<string, string>> queryParameters2 = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),

            };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

                HttpContent content2 = new FormUrlEncodedContent(queryParameters2);

                HttpResponseMessage resp2 = await client.PostAsync("https://accounts.spotify.com/api/token", content2);
                string msg = await resp2.Content.ReadAsStringAsync();

                //System.IO.File.WriteAllText(@"C:\Users\ArsenijKorolkov\Desktop\SpoticToWin\tokenInfo.txt", msg);

                return msg;
            }
        }
    }
}
