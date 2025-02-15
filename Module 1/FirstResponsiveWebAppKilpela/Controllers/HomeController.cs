using FirstResponsiveWebAppKilpela.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstResponsiveWebAppKilpela.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AgeData ageData)
        {
            // Once form is completed and submitted it will show this message out to the user on the bottom of the page
            if (ModelState.IsValid)
            {
                ViewBag.Result = $"{ageData.Name}, will be {ageData.AgeThisYear()} years old on December 31st, " +
                    $"{Constants.CURRENT_YEAR}.";
                return View(ageData);
            }
            return View(ageData);
        }
    }
}
