using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostWebApplication.Controllers
{
    public class PostController : ApiController
    {
        [HttpPost]
        public bool AddPost()
        {
            return true;
            //write insert logic  

        }
        [HttpGet]
        public string GetPosts()
        {
            return "Posts";

        }
        [HttpDelete]
        public string DeletePost(string id)
        {
            return "Post deleted having Id " + id;

        }
        [HttpPut]
        public string UpdatePost(string Name, String Id)
        {
            return "Post Updated with Name " + Name + " and Id " + Id;

        }
    }
}
