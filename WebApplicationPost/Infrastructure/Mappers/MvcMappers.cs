namespace WebApplicationPost.Infrastructure.Mappers
{
    using BLL.Interfacies.Entities;
    using WebApplicationPost.View_Models;

    public static class MvcMappers
    {
        #region Public methods

        public static PostEntity ToBllPost(this PostViewModel postViewModel)
        {
            return new PostEntity()
            {
                Id = postViewModel.Id,
                Text = postViewModel.Text,
                Name = postViewModel.Name,
                CreatedOn = postViewModel.CreatedOn

            };
        }

        public static PostViewModel ToMvcPost(this PostEntity postEntity)
        {
            return new PostViewModel()
            {
                Id = postEntity.Id,
                Name = postEntity.Name,
                Text = postEntity.Text,
                CreatedOn = postEntity.CreatedOn
            };
        }

        public static CommentViewModel ToMvcComment(this CommentEntity commentEntity)
        {
            return new CommentViewModel()
            {
                Id = commentEntity.Id,
                Name = commentEntity.Name,
                Description = commentEntity.Description,
                CreatedOn = commentEntity.CreatedOn,
                PostId = commentEntity.PostId
            };
        }

        public static CommentEntity ToBllComment(this CommentViewModel commentViewModel)
        {
            return new CommentEntity()
            {
                Id = commentViewModel.Id,
                Description = commentViewModel.Description,
                Name = commentViewModel.Name,
                CreatedOn = commentViewModel.CreatedOn,
                PostId = commentViewModel.PostId

            };
        }

        #endregion
    }
}