using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel;
using thub.Models;
using thub.Services;
using thub.Services.IServices;
using thub.Utility;
namespace matchhub.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(SD.Role_Admin)]
	public class MatchController : Controller
    {
		private readonly IMatchService _matchService;
		private readonly UserManager<IdentityUser> _userManager;
		public MatchController(IMatchService matchService, UserManager<IdentityUser> userManager)
		{
			_matchService = matchService;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var matchList = _matchService.GetAllMatches();
			if (!matchList.Any())
			{
				TempData["Empty"] = "The list you're currently trying to display is empty!";
			}
			return View(matchList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(MatchModel match)
		{
			if (ModelState.IsValid)
			{
				_matchService.CreateMatch(match);
				TempData["Success"] = "match " + match.MatchId + " added successfully";
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
			return View(match);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var match = _matchService.GetMatchById(id.Value);
			if (match == null)
			{
				return NotFound();
			}
			return View(match);
		}

		[HttpPost]
		public IActionResult Edit(MatchModel match)
		{
			if (ModelState.IsValid)
			{
				_matchService.UpdateMatch(match);
				TempData["Success"] = "match " + match.MatchId + " updated successfully";
				return RedirectToAction("Index");
			}
			return View(match);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var match = _matchService.GetMatchById(id.Value);
			if (match == null)
			{
				return NotFound();
			}
			return View(match);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int? id)
		{
			var match = _matchService.GetMatchById(id.Value);
			if (match == null)
			{
				return NotFound();
			}
			_matchService.DeleteMatch(match);
			TempData["Success"] = "match " + match.MatchId + " deleted successfully";
			return RedirectToAction("Index");
		}
	}
}

