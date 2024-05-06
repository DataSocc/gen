using Microsoft.EntityFrameworkCore;
using CleanArchNet.Domain.Entities;

namespace CleanArchNet.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Id = Guid.NewGuid(), Title = "Todo Item 1", IsCompleted = false },
                new TodoItem { Id = Guid.NewGuid(), Title = "Todo Item 2", IsCompleted = true }
            );
        }
    }

    
}
