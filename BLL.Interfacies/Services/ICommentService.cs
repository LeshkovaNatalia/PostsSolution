namespace BLL.Interfacies.Services
{
    using System.Collections.Generic;
    using BLL.Interfacies.Entities;

    public interface ICommentService
    {
        CommentEntity GetCommentEntity(int id);
        IEnumerable<CommentEntity> GetAllCommentEntities();
        IEnumerable<CommentEntity> GetAllComments();
        IEnumerable<CommentEntity> GetCommentEntitiesForPost(int id);
        void CreateComment(CommentEntity comment);
        void DeleteComment(CommentEntity comment);
        void DeleteComment(int id);
    }
}
