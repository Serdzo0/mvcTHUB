using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thub.Models;

namespace thub.DataAcess.Repository.IRepository
{

	public interface IMatchRepository : IRepository<MatchModel>
	{
		void Update(MatchModel match);
	}

}
