using loginn.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace loginn.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    username = "Bahar",
                    Password = "4444"
                },
                new User()
                {
                    Id = 2,
                    username = "Raha",
                    Password = "3333"
                }
            ) ;
        }


    }
}
