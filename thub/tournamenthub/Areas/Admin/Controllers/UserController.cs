using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel;
using thub.DataAcess.Data;
using thub.DataAcess.Repository;
using thub.DataAcess.Repository.IRepository;
using thub.Models;


namespace tournamenthub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<UserModel> UserList = _unitOfWork.User.GetAll().ToList();
            if (!UserList.Any())
            {
                TempData["Empty"] = "The list youre currenty trying to display is empty!";
            }
            return View(UserList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel o)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Add(o);
                _unitOfWork.Save();
                TempData["Success"] = "User " + o.Name + " created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            UserModel o = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        [HttpPost]
        public IActionResult Edit(UserModel o)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.User.Update(o);
                _unitOfWork.Save();
                TempData["Success"] = "User " + o.Name + " updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            UserModel o = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            UserModel o = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);
            if (o == null)
            {
                return NotFound();
            }
            _unitOfWork.User.Delete(o);
            _unitOfWork.Save();
            TempData["Success"] = "User " + o.Name + " deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
