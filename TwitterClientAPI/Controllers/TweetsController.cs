using System.Web.Http;
using System.Threading.Tasks;

namespace TwitterClientAPI.Controllers
{
    public class TweetsController : ApiController
    {
        [HttpPost]
        [ActionName("searchtweets")]
        public async Task<IHttpActionResult> SearchTweets([FromBody] string token, string id)
        {
            if (token != null)
            {
                var jsonTweets = await TwitterAPICalls.SearchTweets(token, id);
                return Created(Request.RequestUri, jsonTweets);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ActionName("gettweets")]
        public async Task<IHttpActionResult> GetTweets([FromBody] string token, string id)
        {
            if (token != null)
            {
                var jsonTweets = await TwitterAPICalls.GetTweets(token, id);
                return Created(Request.RequestUri, jsonTweets);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ActionName("gettoken")]
        public async Task<IHttpActionResult> GetToken([FromBody] string appkeys)
        {
            if (appkeys != null)
            {
                var jsonToken = await TwitterAPICalls.GetToken(appkeys);
                return Created(Request.RequestUri, jsonToken);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

