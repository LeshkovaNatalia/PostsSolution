using WebApplicationPost.Infrastructure.Mappers;

namespace WebApplicationPost.Controllers
{
    using System;
    using System.Web.Mvc;
    using BLL.Interfacies.Services;
    using WebApplicationPost.View_Models;

    public class CommentController : Controller
    {
        #region Fields
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        #endregion

        #region Ctors
        public CommentController(IPostService service, ICommentService cmntService)
        {
            postService = service;
            commentService = cmntService;
        }
        #endregion

        [HttpGet]
        public ActionResult Create(int postId)
        {
            var newComment = new CommentViewModel();
            newComment.PostId = postId; // this will be sent from the ArticleDetails View, hold on :).

            return View(newComment);
        }

        [HttpPost]
        public ActionResult Create(CommentViewModel comment)
        {
            if (!ModelState.IsValid)
                return View(comment);

            CommentViewModel model = new CommentViewModel
            {
                Description = comment.Description,
                CreatedOn = DateTime.Now,
                Name = comment.Name,
                PostId = comment.PostId
            };

            commentService.CreateComment(model.ToBllComment());

            return RedirectToAction("", "Post");
        }
    }
}