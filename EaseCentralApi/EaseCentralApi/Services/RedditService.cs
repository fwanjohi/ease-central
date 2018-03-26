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
            var userJson = File.ReadAllText("repository.json");
            var repository = JsonConvert.DeserializeObject<Repository>(userJson);
            return repository;
        }

        private void SaveRepository(Repository rep)
        {
            var json = JsonConvert.SerializeObject(rep);
            //TODO: SAVE THE DATA SOMEWHERE
            //File.WriteAllText("repository.json", json);
        }

        public User GetUserByToken(string token)
        {

            var repository = GetRepository();
            var user = repository.Users.FirstOrDefault(u => u.Token == token);
            //return user;
            //TODO: RETURN A REAL USER FROM SOME DATA STORED
            return new User
            {
                Token = Guid.NewGuid().ToString(),
                UserName = "fake user",
                Favorites = new List<string>()
            };

        }

        public bool SaveUser(User user)
        {
            var repository = GetRepository();
            var exists = repository.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (exists != null)
            {
                repository.Users.Add(user);
            }

            //SaveRepository(repository);

            return exists != null;

        }

        public List<Reddit> GetReditsForUser(string token)
        {
            //TODO: Since I do not have a storage for now, I will just retun the first 3 from all
            
            var userRedits = GetAllRedits().Take(3).ToList();
            return userRedits;

        }

        public List<Reddit> GetAllRedits()
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
    }

}