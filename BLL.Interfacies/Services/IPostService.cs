namespace BLL.Interfacies.Services
{
    using System.Collections.Generic;
    using BLL.Interfacies.Entities;

    public interface IPostService
    {
        PostEntity GetPostEntity(int id);
        IEnumerable<PostEntity> GetAllPostEntities();
        IEnumerable<CommentEntity> GetCommentsForPost(int id);
        void CreatePost(PostEntity post);
        void DeletePost(int id);
    }
}
