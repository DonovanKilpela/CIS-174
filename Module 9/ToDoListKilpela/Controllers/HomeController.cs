using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListKilpela.Models;
using ToDoListKilpela.ViewModels;

namespace ToDoListKilpela.Controllers
{
    public class HomeController : Controller
    {
        private TicketDbContext context;

        public HomeController(TicketDbContext ctx) => context = ctx;

        public IActionResult Index(string SelectedStatus, string SelectedSprint)
        {
            var viewModel = new TicketViewModel
            {
                SelectedStatus = SelectedStatus ?? "all",
                SelectedSprint = SelectedSprint ?? "all",
                Statuses = context.Statuses.ToList(),
                SprintNumbers = context.Tickets.Select(t => t.SprintNumber).Distinct().OrderBy(s => s).ToList()
            };

            IQueryable<Ticket> query = context.Tickets.Include(t => t.Status);

            if (viewModel.SelectedStatus != "all")
            {
                query = query.Where(t => t.StatusId == viewModel.SelectedStatus);
            }

            if (viewModel.SelectedSprint != "all" && int.TryParse(viewModel.SelectedSprint, out int sprint))
            {
                query = query.Where(t => t.SprintNumber == sprint);
            }

            viewModel.Tickets = query.OrderBy(t => t.SprintNumber).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = context.Statuses.ToList();
            return View(new Ticket { StatusId = "todo" });
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Statuses = context.Statuses.ToList();
            return View(ticket);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticket = context.Tickets.Find(id);
            ViewBag.Statuses = context.Statuses.ToList();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Update(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Statuses = context.Statuses.ToList();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ticket = context.Tickets.Find(id);
            context.Tickets.Remove(ticket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}