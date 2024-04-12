using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
	public class HomeController : Controller
	{
		private CodeFirstDbContext ctx;

		public HomeController(CodeFirstDbContext ctx)
		{
			this.ctx = ctx;
		}
		public IActionResult Index()
		{
			var liste = ctx.Items.GroupBy(i => i.Shop).ToList();

			return View(liste);
		}
		[HttpGet]
		public IActionResult NeuerEintrag() { return View(); }

		[HttpPost]

		public IActionResult NeuerEintrag(Item item)
		{
			if (ModelState.IsValid)
			{
			ctx.Items.Add(item);
			ctx.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
			return View(item);
		}
		
		public IActionResult Delete(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			Item item = ctx.Items.FirstOrDefault(i => i.Id == id);
			if (item == null) { return NotFound(); }
			ctx.Items.Remove(item);
			ctx.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
