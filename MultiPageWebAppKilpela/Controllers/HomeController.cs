using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiPageWebAppKilpela.Models;

namespace MultiPageWebAppKilpela.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context {  get; set; }

        public HomeController(ContactContext cxt) => context = cxt;
        public IActionResult Index()
        {
            var Contacts = context.Contacts.OrderBy(c => c.Name).ToList();

            return View(Contacts);
        }
    }
}
