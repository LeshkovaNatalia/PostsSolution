using WebApplicationPost.Infrastructure.Mappers;

namespace WebApplicationPost.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using BLL.Interfacies.Services;
    using WebApplicationPost.View_Models;

    [RoutePrefix("api/comments")]
    public class CommentApiController : ApiController
    {
        #region Fields
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        #endregion

        #region Ctors
        public CommentApiController(IPostService service, ICommentService cmntService)
        {
            postService = service;
            commentService = cmntService;
        }
        #endregion

        // GET: api/CommentViewModels
        [HttpGet]
        public IEnumerable<CommentViewModel> GetCommentViewModels()
        {
            return commentService.GetAllComments().Select(comment => comment.ToMvcComment());
        }

        // GET: api/CommentViewModels/5
        [HttpGet]
        public CommentViewModel GetComment(int id)
        {
            return commentService.GetCommentEntity(id).ToMvcComment();
        }

        [HttpGet]
        public IEnumerable<CommentViewModel> GetCommentsForPost(int id)
        {
            return commentService.GetCommentEntitiesForPost(id).Select(comment => comment.ToMvcComment());
        }

        [HttpDelete]
        public void Remove(int id)
        {
            commentService.DeleteComment(id);
        }
    }
}