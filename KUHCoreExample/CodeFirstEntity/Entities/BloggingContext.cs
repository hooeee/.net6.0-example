using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntity.Entities
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public string DbPath { get; }

        private string DATA_SOURCE = "UserID=root;Password=dkrnl1318;Server=database-postgresql-1.cr4ulfvyna2m.us-west-1.rds.amazonaws.com;Port=5432;Database=efcoredb;IntegratedSecurity=true;Pooling=true;";

        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql(DATA_SOURCE).LogTo((a) =>
            {
                Console.WriteLine(a);
            });
    }
}
