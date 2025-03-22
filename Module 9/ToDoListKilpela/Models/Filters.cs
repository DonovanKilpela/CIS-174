namespace ToDoListKilpela.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all";
            string[] filters = FilterString.Split('-');
            StatusId = filters[0];
            SprintNumber = filters[1];
        }
        public string FilterString { get; }
        public string StatusId { get; }
        public string SprintNumber { get; }

        public bool HasStatus => StatusId.ToLower() != "all";
        public bool HasSprint => SprintNumber.ToLower() != "all";
    }

}
