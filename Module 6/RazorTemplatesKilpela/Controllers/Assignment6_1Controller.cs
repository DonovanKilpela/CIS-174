using Microsoft.AspNetCore.Mvc;
using RazorTemplatesKilpela.Models;
using RazorTemplatesKilpela.ViewModel;
namespace RazorTemplatesKilpela.Controllers
{
    public class Assignment6_1Controller : Controller
    {
        public IActionResult Index(int id)
        {
            // This will create a list of sample students.
            var students = new List<Student> 
            { 
                new Student { FirstName = "Donovan", LastName = "Kilpela", Grade = 100 },
                new Student { FirstName = "Meg", LastName = "Kilpela", Grade = 95 },
                new Student { FirstName = "Michael", LastName = "Davis", Grade = 75 },
                new Student { FirstName = "Sarah", LastName = "Taylor", Grade = 85 },
                new Student { FirstName = "William", LastName = "Johnson", Grade = 64 }
            };

            // This will create and populate the view model with students and access level.
            var viewModel = new Assignment6_1ViewModel
            {
                Students = students,
                AccessLevel = id
            };

            // This will return the view with the populated view model.
            return View(viewModel);

        }
    }
}
