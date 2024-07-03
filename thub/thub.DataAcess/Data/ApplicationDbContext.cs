using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using thub.Models;

namespace thub.DataAcess.Data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<TournamentModel> Tournaments { get; set; }
		public DbSet<MatchModel> Matches { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TournamentModel>()
			.HasOne(t => t.User)
			.WithMany()
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<TournamentModel>().HasData(
				new TournamentModel { TournamentId = 1, Name = "Mešane dvojice", Sport = "Beach Volleyball", NumberOfTeams = 8, NumberOfGroups = 2, StartDate = new DateOnly(2024, 5, 20) },
				new TournamentModel { TournamentId = 2, Name = "Dvojice", Sport = "Beach Volleyball", NumberOfTeams = 8, NumberOfGroups = 2, StartDate = new DateOnly(2024, 6, 22) },
				new TournamentModel { TournamentId = 3, Name = "Mešane dvojice", Sport = "Beach Volleyball", NumberOfTeams = 8, NumberOfGroups = 2, StartDate = new DateOnly(2024, 8, 5) }
				);
		}
	}
}
