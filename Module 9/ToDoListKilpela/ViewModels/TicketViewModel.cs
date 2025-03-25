using ToDoListKilpela.Models;

namespace ToDoListKilpela.ViewModels
{
    public class TicketViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public List<Status> Statuses { get; set; }
        public List<int> SprintNumbers { get; set; }
        public string SelectedStatus { get; set; } = "all";
        public string SelectedSprint { get; set; } = "all";
    }
}
