using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel;
using thub.DataAcess.Data;
using thub.DataAcess.Repository;
using thub.DataAcess.Repository.IRepository;
using thub.Models;


namespace tournamenthub.Customer.Admin.Controllers
{
    [Area("Customer")]
    public class TournamentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TournamentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<TournamentModel> TournamentList = _unitOfWork.Tournament.GetAll().ToList();
            if (!TournamentList.Any())
            {
                TempData["Empty"] = "The list youre currenty trying to display is empty!";
            }
            return View(TournamentList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TournamentModel o)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tournament.Add(o);
                _unitOfWork.Save();
                TempData["Success"] = "Tournament " + o.Name + " added successfully";
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
            TournamentModel o = _unitOfWork.Tournament.GetFirstOrDefault(u => u.TournamentId == id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        [HttpPost]
        public IActionResult Edit(TournamentModel o)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tournament.Update(o);
                _unitOfWork.Save();
                TempData["Success"] = "Tournament " + o.Name + " updated successfully";
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
            TournamentModel o = _unitOfWork.Tournament.GetFirstOrDefault(u => u.TournamentId == id);
            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            TournamentModel o = _unitOfWork.Tournament.GetFirstOrDefault(u => u.TournamentId == id);
            if (o == null)
            {
                return NotFound();
            }
            _unitOfWork.Tournament.Delete(o);
            _unitOfWork.Save();
            TempData["Success"] = "Tournament " + o.Name + " deleted successfully";
            return RedirectToAction("Index");

        }
		public IActionResult AddTeams(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			TournamentModel o = _unitOfWork.Tournament.GetFirstOrDefault(u => u.TournamentId == id);
			if (o == null)
			{
				return NotFound();
			}
			return View(o);
		}
		[HttpPost]
		public IActionResult AddTeams(TournamentModel o)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Tournament.Update(o);
				_unitOfWork.Save();
				TempData["Success"] = "Tournament " + o.Name + " updated successfully";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Info()
		{
			List<TournamentModel> TournamentList = _unitOfWork.Tournament.GetAll().ToList();
			if (!TournamentList.Any())
			{
				TempData["Empty"] = "The list youre currenty trying to display is empty!";
			}
			return View(TournamentList);
		}

	}
}
