using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thub.Models
{
	public class MatchModel
	{
		[Key]
		public int MatchId { get; set; }

		[Required]
		[DisplayName("Tournament")]
		public int TournamentId { get; set; }

		[Required]
		[DisplayName("Team 1")]
		public string Team1 { get; set; }

		[Required]
		[DisplayName("Team 2")]
		public string Team2 { get; set; }

		[DisplayName("Score Team 1")]
		public int? ScoreTeam1 { get; set; }

		[DisplayName("Score Team 2")]
		public int? ScoreTeam2 { get; set; }

		[Required]
		[DisplayName("Match Date")]
		[DataType(DataType.Date)]
		public DateOnly MatchDate { get; set; }

		[Required]
		[DisplayName("Match Time")]
		[DataType(DataType.Time)]
		public TimeOnly MatchTime { get; set; }

		public TournamentModel Tournament { get; set; }
	}
}
