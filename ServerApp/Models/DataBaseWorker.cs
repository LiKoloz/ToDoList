using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ServerApp.Models
{
    public class DataBaseWorker : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DataBaseWorker()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=SomePassword123!;database=usersdb;",
                new MySqlServerVersion(new Version(8, 0, 33)));
        }
    }
}
