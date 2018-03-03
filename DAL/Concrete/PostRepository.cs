using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using ORM;

namespace DAL.Concrete
{
    public class PostRepository : IPostRepository
    {
        #region Fields
        private readonly DbContext context;
        #endregion

        #region Ctors
        public PostRepository(DbContext dbContext)
        {
            this.context = dbContext;
        }
        #endregion

        public void Create(DalPost entity)
        {
            var post = new Post
            {
                Id = entity.Id,
                Name = entity.Name,
                Text = entity.Text,
                CreatedOn = entity.CreatedOn
            };

            context.Set<Post>().Add(post);
        }

        public void Delete(Task<DalPost> entity)
        {
            var post = new Post()
            {
                Text = entity.Result.Text,
                CreatedOn = entity.Result.CreatedOn,
                Name = entity.Result.Name
            };

            post = context.Set<Post>().Single(pst => pst.Id == entity.Id);
            context.Set<Post>().Remove(post);
        }

        public void Delete(int key)
        {
            var post = GetById(key);
            Delete(post);
        }

        public void Delete(DalPost entity)
        {
            var post = new Post()
            {
                Text = entity.Text,
                CreatedOn = entity.CreatedOn,
                Name = entity.Name
            };

            post = context.Set<Post>().Single(pst => pst.Id == entity.Id);
            context.Set<Post>().Remove(post);
        }

        public IEnumerable<DalPost> GetAll()
        {
            return context.Set<Post>().Select(post => new DalPost()
            {
                Id = post.Id,
                Text = post.Text,
                CreatedOn = post.CreatedOn,
                Name = post.Name
            }).OrderByDescending(p => p.CreatedOn);
        }

        public Task<IEnumerable<DalPost>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public DalPost GetById(int key)
        {
            return context.Set<Post>().Where(pst => pst.Id == key).Select(post => new DalPost()
            {
                Id = post.Id,
                Text = post.Text,
                CreatedOn = post.CreatedOn,
                Name = post.Name
            }).SingleOrDefault();
        }

        public async Task<DalPost> GetByIdAsync(int key)
        {
            return await context.Set<Post>().Where(pst => pst.Id == key).Select(post => new DalPost()
            {
                Id = post.Id,
                Text = post.Text,
                CreatedOn = post.CreatedOn,
                Name = post.Name
            }).SingleOrDefaultAsync();
        }

        public void Update(DalPost entity)
        {
            var actualPost = GetById(entity.Id);
            Post updatedPost = new Post()
            {
                Id = actualPost.Id,
                Name = actualPost.Name,
                Text = actualPost.Text
            };
            context.Set<Post>().Attach(updatedPost);
            var post = context.Entry(updatedPost);
            post.Property(p => p.Name).IsModified = true;
            post.Property(p => p.Text).IsModified = true;
            context.SaveChanges();
        }
        
    }
}
