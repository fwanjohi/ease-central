using EaseCentralApi.Models;
using EaseCentralApi.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EaseCentralApi.Controllers
{
    public class RedditController : ApiController
    {
        
        // GET api/values?token=abcd
        [HttpGet()]
        [Route("api/reddit/{token}")]
        public HttpResponseMessage ListReddits(HttpRequestMessage request, string token = null)
        {
            HttpResponseMessage respose = new HttpResponseMessage();
            if (string.IsNullOrEmpty(token))
            {
                return request.CreateErrorResponse(HttpStatusCode.Unauthorized, "No Token Supplied. Please register or login");
            }
            var svc = new RedditService();
            var reddits = svc.GetAllRedits();

            return request.CreateResponse(HttpStatusCode.OK, reddits);
        }


        [HttpPost()]
        [Route("api/reddit/register")]
        public HttpResponseMessage Register(HttpRequestMessage request, [FromBody]User user)
        {
            var saved = new RedditService().SaveUser(user);
            return request.CreateResponse(HttpStatusCode.OK, Guid.NewGuid().ToString());
        }

        [HttpPost()]
        [Route("api/reddit/login")]
        public HttpResponseMessage Login(HttpRequestMessage request, [FromBody]User user)
        {
            //TO DO, SINCE i do not have storeage I will just return a fake token
            var existing = new RedditService().GetUserByToken(user.Token);
            return request.CreateResponse(HttpStatusCode.OK, existing.Token);
        }
       
        [HttpPut()]
        [Route("api/reddit/favorite")]
        public HttpResponseMessage Favorite(HttpRequestMessage request, [FromBody]Favorite favorite)
        {
            try
            {
                //List<string> faves = new List<string>();
                //faves.Add("maya");
                //faves.Add ("tttyy");
                //faves.Add("ffx");

                //var fx = new Favorite { AccessToken = Guid.NewGuid().ToString(), RedditId = "xauys_t", Tags = faves };

                return request.CreateResponse(HttpStatusCode.OK, $"Your tages for {favorite.RedditId} has been saved" );

                //return request.CreateResponse(HttpStatusCode.OK, fx);
            }
            catch
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
        }

        [HttpGet()]
        [Route("api/reddit/favorites/{token}")]
        public HttpResponseMessage Favorites(HttpRequestMessage request, string token)
        {
            var fakeRedits = new RedditService().GetReditsForUser(token);
            return request.CreateResponse(HttpStatusCode.OK, fakeRedits);
        }

       
      
    }
}
