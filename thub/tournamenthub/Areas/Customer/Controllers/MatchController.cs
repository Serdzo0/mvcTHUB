using Microsoft.AspNetCore.Mvc;
using thub.DataAcess.Repository.IRepository;
using thub.Models;

namespace tournamenthub.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class MatchController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public MatchController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<MatchModel> MatchList = _unitOfWork.Match.GetAll().ToList();
			if (!MatchList.Any())
			{
				TempData["Empty"] = "The list youre currenty trying to display is empty!";
			}
			return View(MatchList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(MatchModel o)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Match.Add(o);
				_unitOfWork.Save();
				TempData["Success"] = "Bracket has been made successfully";
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
