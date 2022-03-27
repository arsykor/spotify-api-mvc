using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Requests
{
    public class TrackRequests
    {
        public static async Task<string> GetTracksAsync(string token, int offset)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                List<KeyValuePair<string, string>> queryParameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("limit", "50"),
                    new KeyValuePair<string, string>("offset", offset.ToString()),
                };

                var content = new FormUrlEncodedContent(queryParameters);
                string query = content.ReadAsStringAsync().Result;

                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spotify.com/v1/me/tracks?" + query);

                var response = await client.SendAsync(request);

                string responseBody = await response.Content.ReadAsStringAsync();

                System.IO.File.WriteAllText(@"C:\Users\ArsenijKorolkov\Desktop\SpoticToWin\ChechIfNoTracks.txt", responseBody);

                return responseBody;
            }
        }
    }
}