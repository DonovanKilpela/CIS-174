using Microsoft.EntityFrameworkCore;

namespace MultiPageWebAppKilpela.Models
{
    public class ContactContext : DbContext
    {
        // Creating the DB Context for the MVC App
        public ContactContext(DbContextOptions<ContactContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Contact> Contacts { get; set; }

        // Adding a contact into the program so it will be displayed 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 1,
                Name = "Joji",
                PhoneNumber = "123456789",
                Address = "Japan",
                Note = "Favorite Artist"
            });
        }
    }
}
