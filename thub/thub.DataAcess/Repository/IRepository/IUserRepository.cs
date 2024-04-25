using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thub.Models;

namespace thub.DataAcess.Repository.IRepository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        void Update(UserModel user);
    }
}
