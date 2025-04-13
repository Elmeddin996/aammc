using aammc.DAL;
using aammc.Helpers;
using aammc.Models;
using aammc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aammc.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("manage")]
    public class PartnerController : Controller
    {
        private readonly AammcDbContext _context;

        public IWebHostEnvironment _env { get; }

        public PartnerController(AammcDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Partners.AsQueryable();

            if (search != null)
                query = query.Where(x => x.Name.Contains(search));

            ViewBag.Search = search;

            return View(PaginatedList<Partner>.Create(query, page, 6));
        }

        public IActionResult Create()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Partner partner)
        {
            partner.Image = FileManager.Save(_env.WebRootPath, "uploads/partners", partner.ImageFile);


            _context.Partners.Add(partner);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Partner partner = _context.Partners.Find(id);

            if (partner == null) return View("Error");

            return View(partner);
        }

        [HttpPost]
        public IActionResult Edit(Partner partner)
        {
            Partner existPartner = _context.Partners.Find(partner.Id);

            if (existPartner == null) return View("Error");

            string oldFileName = null;
            if (partner.ImageFile != null)
            {
                oldFileName = existPartner.Image;

                if (partner.Image == null)
                {
                    partner.Image = FileManager.Save(_env.WebRootPath, "uploads/partners", partner.ImageFile);
                    existPartner.Image = partner.Image;
                }
                else
                    partner.Image = FileManager.Save(_env.WebRootPath, "uploads/partners", partner.ImageFile);
            }


            existPartner.Name = partner.Name;
           


            _context.SaveChanges();

            if (oldFileName != null)
                FileManager.Delete(_env.WebRootPath, "uploads/partners", oldFileName);

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Partner partner = _context.Partners.Find(id);

            if (partner == null) return StatusCode(404);

            _context.Partners.Remove(partner);
            _context.SaveChanges();

            FileManager.Delete(_env.WebRootPath, "uploads/partners", partner.Image);

            return StatusCode(200);
        }
    }
}
