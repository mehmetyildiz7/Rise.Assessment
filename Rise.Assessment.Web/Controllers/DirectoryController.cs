using Microsoft.AspNetCore.Mvc;

namespace Rise.Assessment.Web.Controllers
{
    public class DirectoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}