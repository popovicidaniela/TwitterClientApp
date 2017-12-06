using TwitterClientAPI.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Web;

namespace TwitterClientAPI.Controllers
{
    public class TwitterAPICalls
    {
        public static async Task<Token> GetToken(string keys)
        {
            string address = "https://api.twitter.com/oauth2/token";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + keys);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, address);
                request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

                HttpResponseMessage response = await client.PostAsync(address, request.Content);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var jsonresult = JsonConvert.DeserializeObject<Token>(content);
                return jsonresult;
            }
        }

        public static async Task<Hashtag> SearchTweets(string token, string q)
        {
            string address = "https://api.twitter.com/1.1/search/tweets.json";
            var uriBuilder = new UriBuilder(address);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            
            uriBuilder.Query = query.ToString();
            string longurl = String.Format("{0}?q=%23{1}", address, q);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, longurl);
                HttpResponseMessage response = await client.GetAsync(longurl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var jsonresult = JsonConvert.DeserializeObject<Hashtag>(content);
                return jsonresult;
            }
        }

        public static async Task<List<Tweet>> GetTweets(string token, string username)
        {
            string address = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            var uriBuilder = new UriBuilder(address);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["screen_name"] = username;
            uriBuilder.Query = query.ToString();
            string longurl = uriBuilder.ToString();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, longurl);
                HttpResponseMessage response = await client.GetAsync(longurl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var jsonresult = JsonConvert.DeserializeObject<List<Tweet>>(content);
                return jsonresult;
            }
        }
    }
}