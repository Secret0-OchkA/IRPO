using Microsoft.EntityFrameworkCore;

namespace DobLabASP.Models
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI;Database=Task5Test;Trusted_Connection=True;");
        }
    }

}
