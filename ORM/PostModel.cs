namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PostModel : DbContext
    {
        public PostModel()
            : base("name=PostModel")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Comment>()
                .HasOptional(p => p.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.PostId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);*/
        }
    }
}
