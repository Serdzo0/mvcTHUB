using Microsoft.EntityFrameworkCore;
using tournamenthub.Models;

namespace tournamenthub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { UserId = 1, Name = "Sergej", Email = "sergej.ajlec@gmail.com", LastName = "Ajlec", Password = "test123" },
                new UserModel { UserId = 2, Name = "Dejan", Email = "dejan.ajlec@gmail.com", LastName = "Ajlec", Password = "test123" },
                new UserModel { UserId = 3, Name = "Samo", Email = "samo.ajlec@gmail.com", LastName = "Ajlec", Password = "test123" }
                );
        }
    }
}
