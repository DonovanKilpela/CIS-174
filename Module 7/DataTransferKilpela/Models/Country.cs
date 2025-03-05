namespace DataTransferKilpela.Models
{
    public class Country
    {
        public string Name { get; set; } = String.Empty;
        public string FlagImage { get; set; } = String.Empty;
        public OlympicGame Game { get; set; } = null!;
        public Sport Sport { get; set; } = null!;

    }
}
