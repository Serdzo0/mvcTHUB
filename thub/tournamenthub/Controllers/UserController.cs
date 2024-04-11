using Microsoft.AspNetCore.Mvc;
using tournamenthub.Data;
using tournamenthub.Models;

namespace tournamenthub.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db) 
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            List<UserModel> UserList = _db.Users.ToList();
            return View();
        }
    }
}
