using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;

namespace MultiPageWebAppKilpela.Models
{
    public class Contact
    {
        // EF Core will configure the database to generate this value
        public int ContactId { get; set; }

        // Other information that is needed to complete the contact information 
        [Required(ErrorMessage = "Please enter in a name for the contact")]
        public string Name { get; set; }

        // Adding the phone number 
        [Required(ErrorMessage = "Please enter in a phone number.")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        // Adding the address 
        [Required(ErrorMessage = "Please enter an address")]
        public string Address { get; set; }

        // Adding the note 
        [Required(ErrorMessage = "Please enter a note about the contact")]
        public string Note { get; set; }

        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + Name?.ToString();
    }
}
