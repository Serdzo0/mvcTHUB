using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;
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
		private readonly UserManager<IdentityUser> _userManager;
		public TournamentController(ITournamentService tournamentService, UserManager<IdentityUser> userManager)
		{
			_tournamentService = tournamentService;
			_userManager = userManager;
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
		public async Task<IActionResult> Create(TournamentModel tournament)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.GetUserAsync(User);
				var userId = user.Id;
				if (user == null)
				{
					TempData["Error"] = "Unable to create tournament. User is not authenticated.";
					return View(tournament);
				}
				tournament.User = user;
				_tournamentService.CreateTournament(tournament);
				TempData["Success"] = "Tournament " + tournament.Name + " added successfully";
				return RedirectToAction("Index");
			}
			else
			{
				// Log or debug output to confirm model state errors
				Console.WriteLine("Model state is invalid.");
				foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
				{
					Console.WriteLine(error.ErrorMessage);
				}
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
		public IActionResult PrepareUserData()
		{
			var user = _userManager.GetUserAsync(User).Result;
			TempData["User"] = JsonConvert.SerializeObject(user);
			return RedirectToAction("CreatedByUser", "Tournament", new { area = "Customer" });
		}
		public IActionResult CreatedByUser(IdentityUser? userId)
		{
			var userJson = TempData["User"] as string;
			if (userJson == null)
			{
				// Handle the case where the user data is not found
				TempData["Empty"] = "User data not found!";
				return View(new List<TournamentModel>());
			}

			var user = JsonConvert.DeserializeObject<IdentityUser>(userJson);
			var tournamentList = _tournamentService.GetAllTournaments()
												   .Where(tournament => tournament.userId == user.Id)
												   .ToList();

			if (!tournamentList.Any())
			{
				TempData["Empty"] = "The list you're currently trying to display is empty!";
			}

			return View(tournamentList); // Pass the filtered list to the view
		}
	}
}

