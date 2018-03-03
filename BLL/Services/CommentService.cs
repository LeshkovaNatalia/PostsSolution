namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BLL.Interfacies.Entities;
    using BLL.Interfacies.Services;
    using BLL.Mappers;
    using DAL.Interfaces.DTO;
    using DAL.Interfaces.Repository;

    public class CommentService: ICommentService
    {
        #region Fields
        private readonly IUnitOfWork uow;
        private readonly ICommentRepository commentRepository;
        #endregion

        #region Ctors

        public CommentService(IUnitOfWork uow, ICommentRepository repository)
        {
            this.uow = uow;
            this.commentRepository = repository;
        }

        #endregion

        public CommentEntity GetCommentEntity(int id)
        {
            return commentRepository.GetById(id).ToBllComment();
        }

        public IEnumerable<CommentEntity> GetAllCommentEntities()
        {
            return commentRepository.GetAll().Select(comment => comment.ToBllComment());
        }

        public IEnumerable<CommentEntity> GetAllComments()
        {
            return commentRepository.GetAllAsync().Result.Select(comment => comment.ToBllComment());
        }

        public IEnumerable<CommentEntity> GetCommentEntitiesForPost(int postId)
        {
            return commentRepository.GetAll().Where(com => com.PostId == postId).Select(comment => comment.ToBllComment());
        }

        public void CreateComment(CommentEntity comment)
        {
            commentRepository.Create(comment.ToDalComment());
            uow.Commit();
        }

        public void DeleteComment(CommentEntity comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int id)
        {
            commentRepository.Delete(id);
            uow.Commit();
        }
    }
}
