using DataTransferKilpela.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataTransferKilpela.Controllers
{
    public class Favorites : Controller
    {
        // This will load the index page and get the list of Favorites the user has added 
        public IActionResult Index()
        {
            var favorites = FavoriteSession.GetFavorites(HttpContext);
            return View(favorites);
        }


        // When adding countries to the favorites it will add them in the session 
        [HttpPost]
        public IActionResult Add(Country country)
        {
            var favorites = FavoriteSession.GetFavorites(HttpContext);
            if (!favorites.Any(f => f.CountryId == country.CountryId))
            {
                favorites.Add(country);
                FavoriteSession.SetFavorites(HttpContext, favorites);
                TempData["message"] = $"{country.Name} added to your favorites";
            }
            return RedirectToAction("Index", "Home");
        }

        // This will clear the favorites section 
        [HttpPost]
        public IActionResult Clear()
        {
            FavoriteSession.ClearFavorites(HttpContext);
            TempData["message"] = "Favorites cleared";
            return RedirectToAction("Index");
        }
    }
}
