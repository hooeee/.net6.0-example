using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeamTech.ORM.Entities;
using TeamTech.ORM.Entities.Models;
using TeamTech.RestAPI.Models;
using TeamTech.RestAPI.Service;

namespace TeamTech.RestAPI.Controllers
{
    [ApiController]
    [Route("/Blog")]
    public class BlogController : Controller
    {
        private readonly BloggingService _bloggingService;

        public BlogController(BloggingService bloggingService)
        {
            _bloggingService = bloggingService;
        }

        //public IActionResult Index()
        //{
        //    return View("/View/Home/index");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("/Blog")]
        public Blog Test([FromBody]BlogRequest blog)
        {
            return _bloggingService.Save(blog.Name, blog.Description);
        }

        [HttpGet("/Blog/{id}")]
        public Blog GetBlog(int id)
        {
            return _bloggingService.Get(id);
        }
    }
}