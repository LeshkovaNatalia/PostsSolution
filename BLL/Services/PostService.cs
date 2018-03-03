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

    public class PostService: IPostService
    {
        #region Fields
        private readonly IUnitOfWork uow;
        private readonly IPostRepository postRepository;
        #endregion

        #region Ctors

        public PostService(IUnitOfWork uow, IPostRepository repository)
        {
            this.uow = uow;
            this.postRepository = repository;
        }

        #endregion

        public PostEntity GetPostEntity(int id)
        {
            return postRepository.GetById(id).ToBllPost();
        }

        public IEnumerable<PostEntity> GetAllPostEntities()
        {
            return postRepository.GetAll().Select(post => post.ToBllPost());
        }

        public IEnumerable<CommentEntity> GetCommentsForPost(int id)
        {
            throw new NotImplementedException();
        }

        public void CreatePost(PostEntity post)
        {
            postRepository.Create(post.ToDalPost());
            uow.Commit();
        }

        public void DeletePost(int postId)
        {
            postRepository.Delete(postId);
            uow.Commit();
        }
    }
}
