using aammc.DAL;
using aammc.Models;
using aammc.Services;
using aammc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aammc.Controllers
{
	public class ServicesController : Controller
	{
		private readonly AammcDbContext _context;

		public ServicesController(AammcDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Detail(int id)
		{
			ProjectViewModel model = new ProjectViewModel
			{
				project = _context.Projects.FirstOrDefault(p => p.Id == id),
				projects = _context.Projects.ToList()
			};

			if (model.project == null)
				return NotFound();


			return View(model);
		}
	}
}
