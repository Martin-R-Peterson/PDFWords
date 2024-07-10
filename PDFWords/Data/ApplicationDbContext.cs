using App.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace App.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PDF> PDFs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PDF>()
                .Property(b => b.Guid)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
