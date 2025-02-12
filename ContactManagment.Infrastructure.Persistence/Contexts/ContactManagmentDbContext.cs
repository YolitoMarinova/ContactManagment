using ContactManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagment.Infrastructure.Persistence
{
    public class ContactManagmentDbContext : DbContext
    {
        public ContactManagmentDbContext(DbContextOptions<ContactManagmentDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactManagmentDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
