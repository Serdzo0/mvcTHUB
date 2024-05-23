using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thub.DataAcess.Data;
using thub.DataAcess.Repository.IRepository;

namespace thub.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IUserRepository User { get; private set; }
        public ITournamentRepository Tournament { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        { 
            _db = db;
            User = new UserRepository(_db);
            Tournament = new TournamentRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
