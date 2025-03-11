using ProjektDotNet.Models;
using Microsoft.EntityFrameworkCore;
namespace ProjektDotNet.Data
{
    public class UsersContext : DbContext {
        public UsersContext(DbContextOptions options) :
            base(options) { }
        public DbSet<User> User { get; set; }
    }
}
