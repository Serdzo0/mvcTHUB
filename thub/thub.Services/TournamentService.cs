using System.Collections.Generic;
using thub.DataAcess;
using thub.Models;
using System.Linq;
using thub.DataAcess.Repository.IRepository;
using thub.Services.IServices;
using Microsoft.AspNetCore.Identity;


namespace thub.Services
{
	public class TournamentService : ITournamentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<IdentityUser> _userManager;
		public TournamentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<TournamentModel> GetAllTournaments()
		{
			return _unitOfWork.Tournament.GetAll().ToList();
		}

		public TournamentModel GetTournamentById(int id)
		{
			return _unitOfWork.Tournament.GetFirstOrDefault(t => t.TournamentId == id);
		}

		public void CreateTournament(TournamentModel tournament)
		{
			_unitOfWork.Tournament.Add(tournament);
			_unitOfWork.Save();
		}

		public void UpdateTournament(TournamentModel tournament)
		{
			_unitOfWork.Tournament.Update(tournament);
			_unitOfWork.Save();
		}

		public void DeleteTournament(TournamentModel tournament)
		{
			_unitOfWork.Tournament.Delete(tournament);
			_unitOfWork.Save();
		}
	}
}

