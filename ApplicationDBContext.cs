using Microsoft.EntityFrameworkCore;
using MyTaskManager.Models;

namespace MyTaskManager
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public DbSet<LifeSphere> LifeSpheres => Set<LifeSphere>();
        public ApplicationDBContext(DbContextOptions options) : base(options)
             => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskItem>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<LifeSphere>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<LifeSphere>()
                .HasMany(x => x.TaskItems);
        }
    }
}