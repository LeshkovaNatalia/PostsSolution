namespace BLL.Mappers
{
    using System.Threading.Tasks;
    using BLL.Interfacies.Entities;
    using DAL.Interfaces.DTO;

    public static class BllEntityMappers
    {
        public static DalPost ToDalPost(this PostEntity postEntity)
        {
            return new DalPost()
            {
                Id = postEntity.Id,
                Text = postEntity.Text,
                CreatedOn = postEntity.CreatedOn,
                Name = postEntity.Name
            };
        }

        public static DalComment ToDalComment(this CommentEntity commentEntity)
        {
            return new DalComment()
            {
                Id = commentEntity.Id,
                Description = commentEntity.Description,
                CreatedOn = commentEntity.CreatedOn,
                Name = commentEntity.Name,
                PostId = commentEntity.PostId
            };
        }

        public static PostEntity ToBllPost(this DalPost dalPost)
        {
            return new PostEntity()
            {
                Id = dalPost.Id,
                Name = dalPost.Name,
                Text = dalPost.Text,
                CreatedOn = dalPost.CreatedOn
            };
        }

        public static Task<PostEntity> ToBllPostTask(this DalPost dalPost)
        {
            return new Task<PostEntity>(() => new PostEntity()
            {
                Id = dalPost.Id,
                Name = dalPost.Name,
                Text = dalPost.Text,
                CreatedOn = dalPost.CreatedOn
            });
        }

        public static CommentEntity ToBllComment(this DalComment dalComment)
        {
            return new CommentEntity()
            {
                Id = dalComment.Id,
                Name = dalComment.Name,
                Description = dalComment.Description,
                PostId = dalComment.PostId,
                CreatedOn = dalComment.CreatedOn
            };
        }

        public static Task<CommentEntity> ToBllCommentTask(this DalComment dalComment)
        {
            return new Task<CommentEntity>(() => new CommentEntity()
            {
                Id = dalComment.Id,
                Name = dalComment.Name,
                Description = dalComment.Description,
                PostId = dalComment.PostId,
                CreatedOn = dalComment.CreatedOn
            });
        }
    }
}
