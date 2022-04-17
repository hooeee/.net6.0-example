using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeamTech.ORM.Entities.Models;
using TeamTech.RestAPI.Service;

namespace TeamTech.ORM.Entities
{
    public class BloggingContext : DbContext , IBlogService
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("blogs");
            modelBuilder.Entity<Post>().ToTable("posts");
        }

        public void Test()
        {

        }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {

        }

    }
}
