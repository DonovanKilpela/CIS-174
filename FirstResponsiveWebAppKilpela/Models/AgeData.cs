// Adding this so I can make sure that data validation takes place 
using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppKilpela.Models
{
    // Creating of the global constant 
    static class Constants
    {
        public const int CURRENT_YEAR = 2025;
    }

    public class AgeData
    {
        // Variable declaration 
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Birth year is required")]
        [Range(1925, 2025, ErrorMessage = "Birth Year must be between 1925 - 2025")]
        public int birthYear { get; set; }

        // Method to get the age of the user at the end of the year 
        public int AgeThisYear()
        {
            return Constants.CURRENT_YEAR - birthYear;
        }

    }
}
