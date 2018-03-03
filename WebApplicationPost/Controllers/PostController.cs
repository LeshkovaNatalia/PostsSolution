using WebApplicationPost.Infrastructure.Mappers;
using WebApplicationPost.View_Models;

namespace WebApplicationPost.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using BLL.Interfacies.Entities;
    using BLL.Interfacies.Services;

    public class PostController : Controller
    {
        #region Fields
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        #endregion

        #region Ctors
        public PostController(IPostService service, ICommentService cmntService)
        {
            postService = service;
            commentService = cmntService;
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(PostViewModel post)
        {
            if (!ModelState.IsValid)
                return View(post);

            PostViewModel model = new PostViewModel
            {
                Text = post.Text,
                CreatedOn = DateTime.Now,
                Name = post.Name
            };

            postService.CreatePost(model.ToBllPost());

            return RedirectToAction("");
        }

        /*[HttpGet]
        public ActionResult DeletePost(int id)
        {
            PostEntity photo = postService.GetPostEntity(id);

            if (photo == null)
                return HttpNotFound();

            return View(photo.ToMvcPost());
        }

        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostEntity post = postService.GetPostEntity(id);
            TempData["message"] = string.Format("Post has been deleted.", post.Name);
            postService.DeletePost(id);
            return RedirectToAction("GetPosts");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            PostEntity post = postService.GetPostEntity(id);
            TempData["message"] = string.Format("Post has been deleted.", post.Name);
            postService.DeletePost(id);
            return RedirectToAction("GetPosts");
        }*/
    }
}
