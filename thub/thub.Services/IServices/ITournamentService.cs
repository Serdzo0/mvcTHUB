using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thub.Models;

namespace thub.Services.IServices
{
	public interface ITournamentService
	{
		List<TournamentModel> GetAllTournaments();
		TournamentModel GetTournamentById(int id);
		void CreateTournament(TournamentModel tournament);
		void UpdateTournament(TournamentModel tournament);
		void DeleteTournament(TournamentModel tournament);
	}
}
