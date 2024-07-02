using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel;
using thub.Models;
using thub.Services;
using thub.Services.IServices;
using thub.Utility;


namespace tournamenthub.Customer.Controllers
{
    [Area("Customer")]
	[Authorize(Roles = SD.Role_Customer + "," + SD.Role_Admin)]
	public class TournamentController : Controller
    {
		private readonly ITournamentService _tournamentService;

		public TournamentController(ITournamentService tournamentService)
		{
			_tournamentService = tournamentService;
		}

		public IActionResult Index()
		{
			var tournamentList = _tournamentService.GetAllTournaments();
			if (!tournamentList.Any())
			{
				TempData["Empty"] = "The list you're currently trying to display is empty!";
			}
			return View(tournamentList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(TournamentModel tournament)
		{
			if (ModelState.IsValid)
			{
				_tournamentService.CreateTournament(tournament);
				TempData["Success"] = "Tournament " + tournament.Name + " added successfully";
				return RedirectToAction("Index");
			}
			return View(tournament);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var tournament = _tournamentService.GetTournamentById(id.Value);
			if (tournament == null)
			{
				return NotFound();
			}
			return View(tournament);
		}

		[HttpPost]
		public IActionResult Edit(TournamentModel tournament)
		{
			if (ModelState.IsValid)
			{
				_tournamentService.UpdateTournament(tournament);
				TempData["Success"] = "Tournament " + tournament.Name + " updated successfully";
				return RedirectToAction("Index");
			}
			return View(tournament);
		}
		public IActionResult EditTeams(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var tournament = _tournamentService.GetTournamentById(id.Value);
			if (tournament == null)
			{
				return NotFound();
			}
			return View(tournament);
		}

		[HttpPost]
		public IActionResult EditTeams(TournamentModel tournament)
		{
			if (ModelState.IsValid)
			{
				_tournamentService.UpdateTournament(tournament);
				TempData["Success"] = "Tournament " + tournament.Name + " updated successfully";
				return RedirectToAction("Index");
			}
			return View(tournament);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var tournament = _tournamentService.GetTournamentById(id.Value);
			if (tournament == null)
			{
				return NotFound();
			}
			return View(tournament);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int? id)
		{
			var tournament = _tournamentService.GetTournamentById(id.Value);
			if (tournament == null)
			{
				return NotFound();
			}
			_tournamentService.DeleteTournament(tournament);
			TempData["Success"] = "Tournament " + tournament.Name + " deleted successfully";
			return RedirectToAction("Index");
		}

		public IActionResult AddTeams(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var tournament = _tournamentService.GetTournamentById(id.Value);
			if (tournament == null)
			{
				return NotFound();
			}
			return View(tournament);
		}

		[HttpPost]
		public IActionResult AddTeams(TournamentModel tournament)
		{
			if (ModelState.IsValid)
			{
				_tournamentService.UpdateTournament(tournament);
				TempData["Success"] = "Tournament " + tournament.Name + " updated successfully";
				return RedirectToAction("Index");
			}
			return View(tournament);
		}

		public IActionResult Info(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var tournament = _tournamentService.GetTournamentById(id.Value);
			if (tournament == null)
			{
				return NotFound();
			}
			return View(tournament);
		}

	}
}
