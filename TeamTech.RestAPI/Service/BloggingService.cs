using TeamTech.ORM.Entities;
using TeamTech.ORM.Entities.Models;

namespace TeamTech.RestAPI.Service
{
    public class BloggingService
    {

        private BloggingContext _bloggingContext;

        public BloggingService(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }


        public Blog Save(string name, string description)
        {
            var savedEntity = _bloggingContext.Blogs.Add(new Blog() { Name = name, Id=11 });
            _bloggingContext.SaveChanges();

            return savedEntity.Entity;
        }

        public Blog Get(int id)
        {
            Blog blog = _bloggingContext.Blogs.First(x => x.Id == id);
            return blog;
        }


    }
}
