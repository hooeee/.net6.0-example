using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TeamTech.RestAPI.Service;

namespace TeamTech.RestAPI.Controllers
{
    public class HomeController : Controller
    {

        [Inject]
        public IBlogService BlogService { get; set; }


        public IActionResult Index()
        {
            var a = this.BlogService;
            return View();
        }
    }
}