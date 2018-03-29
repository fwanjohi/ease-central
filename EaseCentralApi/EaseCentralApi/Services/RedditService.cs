using EaseCentralApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace EaseCentralApi.Services
{
    public class RedditService
    {
        private readonly string _baseUrl = "https://www.reddit.com/hot.json";
        private string GetRedditJson()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var json = client.GetStringAsync(_baseUrl).Result;
            return json;
        }

        private Repository GetRepository()
        {
            var fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/repository.json");
            var userJson = File.ReadAllText(fullPath);
            var repository = JsonConvert.DeserializeObject<Repository>(userJson);
            return repository;
        }

        private void SaveRepository(Repository rep)
        {
            var json = JsonConvert.SerializeObject(rep);
            var fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/repository.json");
            
            
            File.WriteAllText(fullPath, json);
        }

        public User GetUserByToken(string token)
        {

            var repository = GetRepository();
            var user = repository.Users.FirstOrDefault(u => u.Token == token);
            return user;
           
        }

        public User GetUserByUserName(string userName)
        {

            var repository = GetRepository();
            var user = repository.Users.FirstOrDefault(u => u.UserName == userName);
            return user;
           

        }

        public bool SaveUser(User user)
        {
            var repository = GetRepository();
            var exists = repository.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (exists == null)
            {
                repository.Users.Add(user);
            }
            else
            {
                exists.Token = user.Token;
                exists.Password = user.Password;
                exists.Favorites = user.Favorites;
            }

            SaveRepository(repository);

            return exists != null;

        }

        public List<Reddit> GetRedditsForUser(User user, string tag)
        {
            var faveIds = user.Favorites.Select(x=> x.RedditId).ToList();

            var allRedits = GetAllReddits();

            var userReddits = allRedits.Where(m => faveIds.Contains(m.RedditId)).ToList();
            var tagged = new List<Reddit>();

            //foreach(Reddit r in user.Favorites)
            //{
            //    if (r.
            //}

               
            return userReddits;
        }

        public List<Reddit> GetAllReddits()
        {
            var json = GetRedditJson();

            JObject redditObject = JObject.Parse(json);

            List<Reddit> reddits = new List<Reddit>();

            JArray children = (JArray)redditObject["data"]["children"];
            foreach (var child in children)
            {
                var reddit = new Reddit
                {
                    RedditId = child["data"]["id"].ToString(),
                    PermLink = child["data"]["permalink"].ToString(),
                    Url = child["data"]["url"].ToString(),
                    Author = child["data"]["author"].ToString()

                };

                reddits.Add(reddit);
            }

            return reddits;
        }

        //public bool AddFavorite(Favorite fave)
        //{
           
        //}
    }

}