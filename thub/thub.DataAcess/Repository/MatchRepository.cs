using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thub.DataAcess.Data;
using thub.DataAcess.Repository.IRepository;
using thub.Models;

namespace thub.DataAcess.Repository
{
	public class MatchRepository : Repository<MatchModel>, IMatchRepository
	{
		private ApplicationDbContext _db;
		public MatchRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(MatchModel match)
		{
			_db.Matches.Update(match);
		}
	}
}
