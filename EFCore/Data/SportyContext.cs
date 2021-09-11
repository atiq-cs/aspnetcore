#region snippet_SS
using Sporty.Models;
using Microsoft.EntityFrameworkCore;

namespace Sporty.Data
{
    public class SportyContext : DbContext
    {
        public SportyContext(DbContextOptions<SportyContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Event>().ToTable(nameof(Event));
        }
    }
}
#endregion