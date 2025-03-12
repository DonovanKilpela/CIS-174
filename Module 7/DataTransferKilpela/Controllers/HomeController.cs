using DataTransferKilpela.Models;
using DataTransferKilpela.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Controller for handling home-related actions
    public class HomeController : Controller
    {
    // Database context for Olympic data
        private readonly OlympicDbContext _context;

        public HomeController(OlympicDbContext context)
        {
            _context = context;
        }

    // Action to display the index page with filtered countries
        public IActionResult Index(string game = "all", string category = "all")
        {

            var favorites = FavoriteSession.GetFavorites(HttpContext);
            ViewBag.FavoritesCount = favorites.Count;
            
            // Create and populate the view model with filter options
            var viewModel = new CountryFilterViewModel

            {
                Games = _context.OlympicGames.ToList(),
                Categories = _context.Sports.Select(s => s.Category).Distinct().ToList(),
                SelectedGame = game,
                SelectedCategory = category
            };

        // Query to retrieve countries with related data
            var query = _context.Countries
                .Include(c => c.Game)
                .Include(c => c.Sport)
                .OrderBy(c => c.Name)
                .AsQueryable();

            if (game != "all")
            {
                query = query.Where(c => c.GameId == game);
            }

            if (category != "all")
            {
                query = query.Where(c => c.Sport.Category == category);
            }

            viewModel.Countries = query.ToList();

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var country = _context.Countries
                .Include(c => c.Game)
                .Include(c => c.Sport)
                .FirstOrDefault(c => c.CountryId == id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        public IActionResult AddToFavorites(int id)
        {
            var country = _context.Countries
                .Include(c => c.Game)
                .Include(c => c.Sport)
                .FirstOrDefault(c => c.CountryId == id);

            if (country != null)
            {
                var favorites = FavoriteSession.GetFavorites(HttpContext);
                if (!favorites.Any(f => f.CountryId == country.CountryId))
                {
                    favorites.Add(country);
                    FavoriteSession.SetFavorites(HttpContext, favorites);
                    TempData["Message"] = $"{country.Name} added to favorites.";
                }
                else
                {
                    TempData["Message"] = $"{country.Name} is already in favorites.";
                }
            }

            return RedirectToAction("Index");
        }
    }

