namespace DAL.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL.Interfaces.DTO;
    using DAL.Interfaces.Repository;
    using System.Data.Entity;
    using ORM;

    public class CommentRepository : ICommentRepository
    {
        #region Fields
        private readonly DbContext context;
        #endregion

        #region Ctors
        public CommentRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }
        #endregion
        
        public void Create(DalComment entity)
        {
            var comment = new Comment()
            {
                Description = entity.Description,
                Name = entity.Name,
                CreatedOn = entity.CreatedOn,
                PostId = entity.PostId
            };

            context.Set<Comment>().Add(comment);
        }

        public void Delete(Task<DalComment> entity)
        {
            var comment = new Comment()
            {
                Description = entity.Result.Description,
                CreatedOn = entity.Result.CreatedOn,
                Name = entity.Result.Name,
                PostId = entity.Result.PostId
            };

            comment = context.Set<Comment>().Single(cmt => cmt.PostId == comment.PostId);
            context.Set<Comment>().Remove(comment);
        }

        public void Delete(int key)
        {
            var comment = GetById(key);
            Delete(comment);
        }

        public void Delete(DalComment entity)
        {
            var comment = new Comment()
            {
                Description = entity.Description,
                CreatedOn = entity.CreatedOn,
                Name = entity.Name
            };

            comment = context.Set<Comment>().Single(cmnt => cmnt.Id == entity.Id);
            context.Set<Comment>().Remove(comment);
        }

        public async Task<IEnumerable<DalComment>> GetAllAsync()
        {
            List<DalComment> comments = await context.Set<Comment>().Select(comment => new DalComment()
            {
                Id = comment.Id,
                Description = comment.Description,
                CreatedOn = comment.CreatedOn,
                Name = comment.Name,
                PostId = comment.PostId
            }).ToListAsync();

            return comments;
        }

        public IEnumerable<DalComment> GetAll()
        {
            return context.Set<Comment>().Select(comment => new DalComment()
            {
                Id = comment.Id,
                Description = comment.Description,
                CreatedOn = comment.CreatedOn,
                Name = comment.Name,
                PostId = comment.PostId
            });
        }

        public DalComment GetById(int key)
        {
            return context.Set<Comment>().Where(cmnt => cmnt.Id == key).Select(comment => new DalComment()
            {
                Id = comment.Id,
                Description = comment.Description,
                CreatedOn = comment.CreatedOn,
                Name = comment.Name,
                PostId = comment.PostId
            }).FirstOrDefault();
        }

        public async Task<DalComment> GetByIdAsync(int key)
        {
            var dalComment = await context.Set<Comment>().Where(cmnt => cmnt.Id == key).Select(comment => new DalComment()
            {
                Id = comment.Id,
                Description = comment.Description,
                CreatedOn = comment.CreatedOn,
                Name = comment.Name,
                PostId = comment.PostId
            }).SingleOrDefaultAsync();

            return dalComment;
        }

        public void Update(DalComment entity)
        {
            var actualComment = GetById(entity.Id);
            Comment updatedComment = new Comment()
            {
                Id = actualComment.Id,
                Name = actualComment.Name,
                Description = actualComment.Description
            };
            context.Set<Comment>().Attach(updatedComment);

            var comment = context.Entry(updatedComment);
            comment.Property(p => p.Name).IsModified = true;
            comment.Property(p => p.Description).IsModified = true;

            context.SaveChanges();
        }
    }
}
