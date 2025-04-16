using Microsoft.EntityFrameworkCore;
using ToDoListKilpela.Models;

namespace ToDoListKilpela.Interfaces
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetTickets();
        List<Status> GetStatuses();
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
        Ticket? GetTicketById(int id);
        List<int> GetSprintNumbers();
        void Save();
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _context;

        public TicketRepository(TicketDbContext context)
        {
            _context = context;
        }

        public IQueryable<Ticket> GetTickets() => _context.Tickets.Include(t => t.Status);

        public List<Status> GetStatuses() => _context.Statuses.ToList();

        public void AddTicket(Ticket ticket) => _context.Tickets.Add(ticket);

        public void UpdateTicket(Ticket ticket) => _context.Tickets.Update(ticket);

        public void DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket != null)
                _context.Tickets.Remove(ticket);
        }

        public Ticket? GetTicketById(int id) => _context.Tickets.Find(id);

        public List<int> GetSprintNumbers() =>
            _context.Tickets.Select(t => t.SprintNumber).Distinct().OrderBy(s => s).ToList();

        public void Save() => _context.SaveChanges();
    }
}
