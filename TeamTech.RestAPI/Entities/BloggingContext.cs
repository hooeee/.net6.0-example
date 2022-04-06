using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeamTech.ORM.Entities.Models;

namespace TeamTech.ORM.Entities
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }


        string dbsource = "UserID=postgres;Password=root;Server=localhost;Port=5432;Database=teamtech;IntegratedSecurity=true;Pooling=true;";

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) {

            var sqlServerOptionsExtension =
                   options.FindExtension<NpgsqlDbContextOptionsBuilderExtensions>();
            if (sqlServerOptionsExtension != null)
            {
                string connectionString = sqlServerOptionsExtension.ConnectionString;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(dbsource);
        public BloggingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            optionsBuilder.UseNpgsql(dbsource);

            return new BloggingContext(optionsBuilder.Options);
        }

    }
}
