using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListKilpela.Interfaces;
using ToDoListKilpela.Models;
using ToDoListKilpela.ViewModels;

namespace ToDoListKilpela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketRepository _repository;

        public HomeController(ITicketRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string SelectedStatus, string SelectedSprint)
        {
            var viewModel = new TicketViewModel
            {
                SelectedStatus = SelectedStatus ?? "all",
                SelectedSprint = SelectedSprint ?? "all",
                Statuses = _repository.GetStatuses(),
                SprintNumbers = _repository.GetSprintNumbers()
            };

            IQueryable<Ticket> query = _repository.GetTickets();

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
            ViewBag.Statuses = _repository.GetStatuses();
            return View(new Ticket { StatusId = "todo" });
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _repository.AddTicket(ticket);
                _repository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Statuses = _repository.GetStatuses();
            return View(ticket);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticket = _repository.GetTicketById(id);
            ViewBag.Statuses = _repository.GetStatuses();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateTicket(ticket);
                _repository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Statuses = _repository.GetStatuses();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteTicket(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}