

using ASP.NETFinalExamsProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETFinalExamsProject.Entities
{
    public class CallContext : IdentityDbContext<IdentityUser>
    {
        public CallContext(DbContextOptions<CallContext> options) : base(options)
        {
        }

       
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin"},
                new IdentityRole() { Name = "Receptionist", ConcurrencyStamp = "2", NormalizedName = "Receptionist"}
                );
        }
        

        public DbSet<CallTrackerClass> CallTrackerClasses { get; set; }
    }

    
}
