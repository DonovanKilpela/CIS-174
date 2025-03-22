using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListKilpela.Models;

namespace ToDoListKilpela.Controllers
{
    public class HomeController : Controller
    {
        private TicketDbContext context;

        public HomeController(TicketDbContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.Sprints = context.Tickets
                .Select(t => t.SprintNumber)
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            IQueryable<Ticket> query = context.Tickets
                .Include(t => t.Status);

            // Apply Status Filter
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }

            // Apply Sprint Filter
            if (filters.HasSprint)
            {
                if (int.TryParse(filters.SprintNumber, out int sprint))
                {
                    query = query.Where(t => t.SprintNumber == sprint);
                }
            }

            var tickets = query.OrderBy(t => t.SprintNumber).ToList();
            return View(tickets);
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
