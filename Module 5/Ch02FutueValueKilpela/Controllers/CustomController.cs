// Adding the Custom routing controller

using Microsoft.AspNetCore.Mvc;

namespace Ch02FutueValueKilpela.Areas.Admin.Controllers
{
    public class CustomController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Custom Routing Page";
            return View();
        }
    }
}
