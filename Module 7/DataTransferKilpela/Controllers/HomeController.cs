using DataTransferKilpela.Models;
using DataTransferKilpela.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Controller for handling home-related actions
public class HomeController : Controller
{
    // Database context for Olympic data
    private readonly OlympicDbContext _context;

    // Constructor to initialize the database context
    public HomeController(OlympicDbContext context)
    {
        _context = context;
    }

    // Action to display the index page with filtered countries
    public IActionResult Index(string game = "all", string category = "all")
    {
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

        // Apply game filter if specified
        if (game != "all")
        {
            query = query.Where(c => c.GameId == game);
        }

        // Apply category filter if specified
        if (category != "all")
        {
            query = query.Where(c => c.Sport.Category == category);
        }

        // Execute query and add results to view model
        viewModel.Countries = query.ToList();

        return View(viewModel);
    }

    // Action to display details of a specific country
    public IActionResult Details(int id)
    {
        // Retrieve country with related data
        var country = _context.Countries
            .Include(c => c.Game)
            .Include(c => c.Sport)
            .FirstOrDefault(c => c.CountryId == id);

        // Return 404 if country not found
        if (country == null)
        {
            return NotFound();
        }

        return View(country);
    }
}
