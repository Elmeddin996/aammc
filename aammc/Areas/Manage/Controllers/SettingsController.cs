using aammc.DAL;
using aammc.Helpers;
using aammc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace aammc.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("manage")]
    public class SettingsController : Controller
    {
        private readonly AammcDbContext _context;

        public SettingsController(AammcDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Settings settings = _context.Settings.FirstOrDefault();
            return View(settings);
        }

        public IActionResult Edit(int id)
        {
            Settings settings = _context.Settings.Find(id);
            if (settings == null) return StatusCode(404);

            return View(settings);
        }

        [HttpPost]
        public IActionResult Edit(Settings settings)
        {
            Settings existSettings = _context.Settings.Find(settings.Id);
            if (existSettings == null) return StatusCode(404);

            existSettings.AddressAz= settings.AddressAz;
            existSettings.AddressEn= settings.AddressEn;
            existSettings.AddressRu= settings.AddressRu;
            existSettings.Email= settings.Email;
            existSettings.Phone= settings.Phone;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
