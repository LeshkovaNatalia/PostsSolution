using WebApplicationPost.Infrastructure.Mappers;
using WebApplicationPost.View_Models;

namespace WebApplicationPost.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using BLL.Interfacies.Services;

    [RoutePrefix("api/posts")]
    public class PostApiController : ApiController
    {
        #region Fields
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        #endregion

        #region Ctors
        public PostApiController(IPostService service, ICommentService cmntService)
        {
            postService = service;
            commentService = cmntService;
        }
        #endregion

        [HttpGet]
        public IEnumerable<PostViewModel> AllPosts()
        {
            return postService.GetAllPostEntities().Select(post => post.ToMvcPost());
        }

        [HttpGet]
        public async Task<IEnumerable<PostViewModel>> PostsAsync()
        {
            return await Task.FromResult(AllPosts());
        }

        // GET: api/Post/5
        [HttpGet]
        public PostViewModel Get(int id)
        {
            return postService.GetPostEntity(id).ToMvcPost();
        }

        // POST: api/Post
        [HttpPost]
        [ActionName("create")]
        public void Post([FromBody]PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                PostViewModel model = new PostViewModel
                {
                    Text = post.Text,
                    CreatedOn = DateTime.Now,
                    Name = post.Name
                };

                postService.CreatePost(model.ToBllPost());
            }
        }

        // PUT: api/Post/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Post/5
        [HttpDelete]
        [ActionName("remove")]
        public void DeletePost(int postId)
        {
            postService.DeletePost(postId);
        }
    }
}
