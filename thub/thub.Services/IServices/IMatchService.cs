using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thub.Models;

namespace thub.Services.IServices
{
	public interface IMatchService
	{
		List<MatchModel> GetAllMatches();
		MatchModel GetMatchById(int id);
		void CreateMatch(MatchModel tournament);
		void UpdateMatch(MatchModel tournament);
		void DeleteMatch(MatchModel tournament);
	}
}
