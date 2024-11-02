using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.address)
                .WithOne(u => u.User)
                .HasForeignKey<Address>(a => a.UserId);

            //modelBuilder.Entity<User>()
            //    .HasMany(t => t.task)
            //    .WithOne(u => u.User)
            //    .HasForeignKey<TaskItem>(a => a.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
