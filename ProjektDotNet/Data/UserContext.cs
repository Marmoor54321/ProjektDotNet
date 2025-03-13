using ProjektDotNet.Models;
using Microsoft.EntityFrameworkCore;
namespace ProjektDotNet.Data
{
    public class UsersContext : DbContext {
        public UsersContext(DbContextOptions options) :
            base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Posts> Group { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                HasMany(e => e.Groups)
                .WithMany(equals => equals.Users);
        }
    }
}
