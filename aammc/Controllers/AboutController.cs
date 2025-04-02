using aammc.DAL;
using aammc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aammc.Controllers
{
	public class AboutController : Controller
	{
		private readonly AammcDbContext _context;


		public AboutController(AammcDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{

			MenuViewModel model = new MenuViewModel
			{
				Settings = _context.Settings.FirstOrDefault(),
				Project = _context.Projects.ToList()
			};

			return View(model);
		}
	}

}
