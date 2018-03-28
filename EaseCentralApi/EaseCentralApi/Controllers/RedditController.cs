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
            var reddits = svc.GetAllReddits();

            return request.CreateResponse(HttpStatusCode.OK, reddits);
        }


        [HttpPost()]
        [Route("api/reddit/register")]
        public HttpResponseMessage Register(HttpRequestMessage request, [FromBody]User user)
        {
            var existing = new RedditService().GetUserByUserName(user.UserName);
            if (existing != null)
            {
                return  request.CreateErrorResponse(HttpStatusCode.Conflict, $"the username {user.UserName} is already taken");
            }

            user.Token = Guid.NewGuid().ToString();
            user.Favorites = new List<Favorite>();
            var saved = new RedditService().SaveUser(user);

            return request.CreateResponse(HttpStatusCode.OK, user.Token);
        }

        [HttpPost()]
        [Route("api/reddit/login")]
        public HttpResponseMessage Login(HttpRequestMessage request, [FromBody]User user)
        {
           
            var existing = new RedditService().GetUserByUserName(user.UserName);
            //not found, or wrong passsword
            if (existing == null || existing.Password != user.Password)
            {
                return request.CreateErrorResponse(HttpStatusCode.NotFound, $"User {user.UserName} or password is wrong not found.");
            };

            return request.CreateResponse(HttpStatusCode.OK, existing.Token);
        }
       
        [HttpPut()]
        [Route("api/reddit/favorite/{token}")]
        public HttpResponseMessage AddFavorite(HttpRequestMessage request, string token, [FromBody]Favorite favorite)
        {
            try
            {
                var svc = new RedditService();
                var existing = svc.GetUserByToken(token);

                if (existing == null)
                {
                    return  request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid access token");
                }

                var reddit = svc.GetAllReddits().FirstOrDefault(x=> x.RedditId == favorite.RedditId);
                if (reddit == null)
                {
                    return request.CreateErrorResponse(HttpStatusCode.NotFound, $"Reddit Id {favorite.RedditId} not Found");
                }
                

                if (existing.Favorites == null) existing.Favorites = new List<Favorite>();

                existing.Favorites.Add(favorite);
                svc.SaveUser(existing);
                
                return request.CreateResponse(HttpStatusCode.OK, $"Your tages for {favorite.RedditId} has been saved" );

            }
            catch
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
        }

        [HttpGet()]
        [Route("api/reddit/favorites/{token}")]
        public HttpResponseMessage GetFavorites(HttpRequestMessage request, string token)
        {
            var svc = new RedditService();
            var existing = svc.GetUserByToken(token);

            if (existing == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid access token");
            }

            var redits = svc.GetRedditsForUser(existing);
            return request.CreateResponse(HttpStatusCode.OK, redits);
        }

       
      
    }
}
