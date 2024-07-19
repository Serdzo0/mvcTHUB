using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thub.DataAcess.Repository.IRepository;
using thub.Models;
using thub.Services.IServices;

namespace thub.Services
{
	public class MatchService : IMatchService
	{
		private readonly IUnitOfWork _unitOfWork;
		public MatchService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<MatchModel> GetAllMatches()
		{
			return _unitOfWork.Match.GetAll().ToList();
		}

		public MatchModel GetMatchById(int id)
		{
			return _unitOfWork.Match.GetFirstOrDefault(t => t.MatchId == id);
		}

		public void CreateMatch(MatchModel match)
		{
			_unitOfWork.Match.Add(match);
			_unitOfWork.Save();
		}

		public void UpdateMatch(MatchModel match)
		{
			_unitOfWork.Match.Update(match);
			_unitOfWork.Save();
		}

		public void DeleteMatch(MatchModel match)
		{
			_unitOfWork.Match.Delete(match);
			_unitOfWork.Save();
		}
	}
}
