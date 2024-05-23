using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using thub.DataAcess.Data;
using thub.DataAcess.Repository.IRepository;
using thub.Models;

namespace thub.DataAcess.Repository
{
    public class TournamentRepository : Repository<TournamentModel>, ITournamentRepository
    {
        private ApplicationDbContext _db;
        public TournamentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TournamentModel user)
        {
            _db.Tournaments.Update(user);
        }
    }
}
