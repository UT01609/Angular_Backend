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
        public DbSet<UserLogin> UsersLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasOne(a => a.address)
            //    .WithOne(u => u.User)

            //    .HasForeignKey<Address>(a => a.UserId);

            //modelBuilder.Entity<User>()
            //    .HasMany(t => t.task)
            //    .WithOne(u => u.User)
            //    .HasForeignKey<TaskItem>(a => a.UserId);


            //ONE to ONE
            modelBuilder.Entity<User>()
                .HasOne(a => a.address)
                .WithOne(u => u.User)
                .HasForeignKey<Address>(a => a.UserId);

            //ONE to Many
            modelBuilder.Entity<User>()
                .HasMany(t => t.items)
                .WithOne(u => u.Assignee)
                .HasForeignKey(t => t.AssigneeId);

            modelBuilder.Entity<TaskItem>()
               .HasMany(t => t.CheckLists)
               .WithOne(c => c.Task)
               .HasForeignKey(c => c.TaskId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
