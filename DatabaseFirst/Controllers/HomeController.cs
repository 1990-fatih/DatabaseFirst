using DatabaseFirst.Models;
using DatabaseFirst.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirst.Controllers
{
	public class HomeController : Controller
	{
		private DatabaseFirstDbContext ctx;
		public HomeController(DatabaseFirstDbContext ctx)
		{
			this.ctx = ctx;
		}

		public IActionResult Index()
		{
			List<Article> articles = ctx.Articles
										.OrderByDescending(a => a.Created)
										.ToList();
			IndexViewModel ivm = new IndexViewModel()
			{
				TopArticle = articles.FirstOrDefault(),
				Articles = articles.Skip(1).ToList()
			};

			return View(ivm);
		}
		public IActionResult ZweiteSeite(int? id, string text)
		{
			ZweiteSeiteViewModel zsvm = new ZweiteSeiteViewModel()
			{
				Id = id,
				Text = text
			};
			return View(zsvm);
		}

		public IActionResult Details(int? id)
		{
			if (id != null)
			{
				Article? article = ctx.Articles.FirstOrDefault(a => a.Id == id);

				if (article != null)
				{
					return View(article);
				}
			}

		 return NotFound();
			
		}

		[HttpGet]
		public IActionResult NeuerArtikel() 
		{
			return View();
		}
		[HttpPost]

		public IActionResult NeuerArtikel(Article article)
		{
			article.Created = DateTime.Now;
			int maxId = 0;
			if (ctx.Articles.Any())
			{
				maxId = ctx.Articles.Max(a => a.Id);	
			}
			article.Id = maxId+1;
			ctx.Articles.Add(article);
			ctx.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

	}
}