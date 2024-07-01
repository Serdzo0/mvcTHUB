using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thub.DataAcess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ITournamentRepository Tournament { get; }
		IMatchRepository Match { get; }
		void Save();
	}
}
