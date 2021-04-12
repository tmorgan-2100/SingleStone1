using Microsoft.EntityFrameworkCore;
using System.Linq;
using SingleStone.Models;


namespace SingleStone
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public ContactContext(DbContextOptions<ContactContext> dbContextOptions) : base(dbContextOptions)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=contacts.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().Property(c => c.First).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Contact>().Property(c => c.Last).IsRequired().HasMaxLength(255);


            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1,
                First = "Tim",
                Last = "Morgan"
            });

            modelBuilder.Entity<Address>().HasData(new Address { Id = 1, ContactId = 1, Street = "11 Street X", City = "Sometown", State = "NH", Zip = "11111" });
            modelBuilder.Entity<Phone>().HasData(new Phone { Id = 1, ContactId = 1, Number = "6035551212", Type = "mobile" });



        }
    }
}
