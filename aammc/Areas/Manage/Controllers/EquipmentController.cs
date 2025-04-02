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
	public class EquipmentController : Controller
	{
		private readonly AammcDbContext _context;

		public IWebHostEnvironment _env { get; }

		public EquipmentController(AammcDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
		public IActionResult Index(int page = 1, string search = null)
		{
			var query = _context.Equipments.AsQueryable();

			if (search != null)
				query = query.Where(x => x.NameAz.Contains(search));

			ViewBag.Search = search;

			return View(PaginatedList<Equipment>.Create(query, page, 6));
		}

		public IActionResult Create()
		{

			return View();
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult Create(Equipment equipment)
		{
			equipment.Image = FileManager.Save(_env.WebRootPath, "uploads/equipments", equipment.ImageFile);


			_context.Equipments.Add(equipment);
			_context.SaveChanges();

			return RedirectToAction("index");
		}

		public IActionResult Edit(int id)
		{
			Equipment equipment = _context.Equipments.Find(id);

			if (equipment == null) return View("Error");

			return View(equipment);
		}

		[HttpPost]
		public IActionResult Edit(Equipment equipment)
		{
			Equipment existEquipment = _context.Equipments.Find(equipment.Id);

			if (existEquipment == null) return View("Error");

			string oldFileName = null;
			if (equipment.ImageFile != null)
			{
				oldFileName = existEquipment.Image;

				if (equipment.Image == null)
				{
					equipment.Image = FileManager.Save(_env.WebRootPath, "uploads/equipments", equipment.ImageFile);
					existEquipment.Image = equipment.Image;
				}
				else
					equipment.Image = FileManager.Save(_env.WebRootPath, "uploads/equipments", equipment.ImageFile);
			}


			existEquipment.NameAz = equipment.NameAz;
			existEquipment.NameEn = equipment.NameEn;
			existEquipment.NameRu = equipment.NameRu;


            _context.SaveChanges();

			if (oldFileName != null)
				FileManager.Delete(_env.WebRootPath, "uploads/equipments", oldFileName);

			return RedirectToAction("index");
		}

		public IActionResult Delete(int id)
		{
			Equipment equipment = _context.Equipments.Find(id);

			if (equipment == null) return StatusCode(404);

			_context.Equipments.Remove(equipment);
			_context.SaveChanges();

			FileManager.Delete(_env.WebRootPath, "uploads/equipments", equipment.Image);

			return StatusCode(200);
		}
	}
}

