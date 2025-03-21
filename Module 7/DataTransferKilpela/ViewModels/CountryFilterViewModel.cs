using DataTransferKilpela.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataTransferKilpela.ViewModels
{
    // ViewModel for the Country Filters 
    public class CountryFilterViewModel
    {
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<OlympicGame> Games { get; set; } = new List<OlympicGame>();
        public List<string> Categories { get; set; } = new List<string>();

        public string SelectedGame { get; set; } = "all";

        public string SelectedCategory { get; set; } = "all";
    }
}
