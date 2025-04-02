using aammc.DAL;
using aammc.Models;
using aammc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aammc.Controllers
{
    public class HomeController : Controller
    {
		private readonly AammcDbContext _context;

        public HomeController(AammcDbContext context)
        {
			_context = context;
		}
        public IActionResult Index()
        {
            MenuViewModel model = new MenuViewModel
            {
                Settings = _context.Settings.FirstOrDefault(),
                Project = _context.Projects.ToList(),
                Equipment = _context.Equipments.ToList(),
                Slider = _context.Sliders.ToList()
            };

            return View(model);
        }

       
    }
}
