using Core.Activities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions builder) : base(builder)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<ActivityModel> __activities { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
