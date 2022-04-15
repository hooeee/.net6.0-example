using CodeFirstEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.CodeFirst.Setup.Servicies
{
    public class TempService
    {

        public static void N1()
        {
            using var db = new BloggingContext();

            foreach (var blog in db.Blogs.ToList())
            {
                foreach (var post in blog.Posts)
                {
                    Console.WriteLine($"Blog {blog.Name}, Post: {post.Title}");
                }
            }
        }

        public static void DeleteAll()
        {
            using var db = new BloggingContext();
            db.Posts.RemoveRange(db.Posts.ToList());
            db.Blogs.RemoveRange(db.Blogs.ToList());
            db.SaveChanges();
        }

        public static void Save()
        {
            using var db = new BloggingContext();
            for (int i = 0; i < 10; i++)
            {
                Blog blog = new() { CreatedDate = DateTime.UtcNow, Name = "Name " + i };
                blog.Posts = new List<Post>();
                for (int j = 0; j < 10; j++)
                {
                    Post post = new() { Body = $"Body_{i}_{j}" , Created = DateTime.UtcNow, Title = $"Title_{i}_{j}" };
                    blog.Posts.Add(post);
                };

                db.Blogs.Add(blog);
            }
            db.SaveChanges();
            return;
        }
    }
}
