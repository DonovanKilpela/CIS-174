using DataTransferKilpela.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataTransferKilpela.Controllers
{
    public class Favorites : Controller
    {
        [HttpPost]
        public RedirectToActionResult Add(Country country)
        {
            TempData["message"] = $"{country.Name} added to your favorites";
            return RedirectToAction("Index", "Home");
        }
    }
}
