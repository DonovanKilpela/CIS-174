namespace ToDoListKilpela.Models
{
    public class Filters
    {
        public Filters(string statusId = "all", string sprintNumber = "all")
        {
            StatusId = statusId;
            SprintNumber = sprintNumber;
        }

        public string StatusId { get; set; }
        public string SprintNumber { get; set; }

        public bool HasStatus => StatusId?.ToLower() != "all";
        public bool HasSprint => SprintNumber?.ToLower() != "all";
    }

}
