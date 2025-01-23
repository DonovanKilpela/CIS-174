using Microsoft.AspNetCore.Mvc;

namespace EFCoreLabKilpela.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
