namespace DataTransferKilpela.Models
{
    // Getters and Setters for the Country Object
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GameId { get; set; } = string.Empty;
        public string SportId { get; set; } = string.Empty;
        public string FlagImage { get; set; } = string.Empty;
        public OlympicGame Game { get; set; } = null!;
        public Sport Sport { get; set; } = null!;
    }

}
