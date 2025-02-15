using Microsoft.AspNetCore.Mvc;

namespace Ch02FutueValueKilpela.Controllers
{
    public class AttributeController : Controller
    {
        [Route("attribute-page")]
        public IActionResult Index()
        {
            ViewBag.Title = "Attribute Routing Page";
            return View();
        }
    }
}
