using Core.Activities;
using DatabaseContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions builder) : base(builder)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<WorkflowEntity> __workflows { get; set; }
        public DbSet<ActivityEntity> __activities { get; set; }
        public DbSet<RegisteredActivitiesEntity> __registered_activities { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowEntity>()
                .HasMany(p => p.Activities)
                .WithOne(p => p.Workflow)
                .HasForeignKey(p => p.WorkflowId);
            modelBuilder.Entity<ActivityEntity>()
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
