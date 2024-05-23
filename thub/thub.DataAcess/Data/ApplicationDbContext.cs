using Microsoft.EntityFrameworkCore;
using thub.Models;

namespace thub.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
   
        public DbSet<TournamentModel> Tournaments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { UserId = 1, Name = "Sergej", Email = "sergej.ajlec@gmail.com", LastName = "Ajlec", Password = "test123" },
                new UserModel { UserId = 2, Name = "Dejan", Email = "dejan.ajlec@gmail.com", LastName = "Ajlec", Password = "test123" },
                new UserModel { UserId = 3, Name = "Samo", Email = "samo.ajlec@gmail.com", LastName = "Ajlec", Password = "test123" }
                );
            modelBuilder.Entity<TournamentModel>().HasData(
                new TournamentModel { TournamentId = 1, Name = "Mešane dvojice", Sport="Beach Volleyball", NumberOfTeams=8, NumberOfGroups=2, StartDate = new DateOnly(2024, 5, 20) },
                new TournamentModel { TournamentId = 2, Name = "Dvojice", Sport="Beach Volleyball", NumberOfTeams=8, NumberOfGroups=2, StartDate = new DateOnly(2024, 6, 22) },
                new TournamentModel { TournamentId = 3, Name = "Mešane dvojice", Sport="Beach Volleyball", NumberOfTeams=8, NumberOfGroups=2, StartDate = new DateOnly(2024, 8, 5) }
                );
        }
    }
}
