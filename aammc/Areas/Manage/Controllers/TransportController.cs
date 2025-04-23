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
	public class TransportController : Controller
	{
		private readonly AammcDbContext _context;

		public IWebHostEnvironment _env { get; }

		public TransportController(AammcDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
		public IActionResult Index(int page = 1, string search = null)
		{
			var query = _context.Transports.AsQueryable();

			if (search != null)
				query = query.Where(x => x.NameAz.Contains(search));

			ViewBag.Search = search;

			return View(PaginatedList<Transport>.Create(query, page, 6));
		}

		public IActionResult Create()
		{

			return View();
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult Create(Transport transport)
		{
			transport.Image = FileManager.Save(_env.WebRootPath, "uploads/transports", transport.ImageFile);


			_context.Transports.Add(transport);
			_context.SaveChanges();

			return RedirectToAction("index");
		}

		public IActionResult Edit(int id)
		{
			Transport transport = _context.Transports.Find(id);

			if (transport == null) return View("Error");

			return View(transport);
		}

		[HttpPost]
		public IActionResult Edit(Transport transport)
		{
			Transport existTransport = _context.Transports.Find(transport.Id);

			if (existTransport == null) return View("Error");

			string oldFileName = null;
			if (transport.ImageFile != null)
			{
				oldFileName = existTransport.Image;

				if (transport.Image == null)
				{
					transport.Image = FileManager.Save(_env.WebRootPath, "uploads/transports", transport.ImageFile);
                    existTransport.Image = transport.Image;
				}
				else
					transport.Image = FileManager.Save(_env.WebRootPath, "uploads/transports", transport.ImageFile);
			}


            existTransport.NameAz = transport.NameAz;
            existTransport.NameEn = transport.NameEn;
            existTransport.NameRu = transport.NameRu;


            _context.SaveChanges();

			if (oldFileName != null)
				FileManager.Delete(_env.WebRootPath, "uploads/transports", oldFileName);

			return RedirectToAction("index");
		}

		public IActionResult Delete(int id)
		{
			Transport transport = _context.Transports.Find(id);

			if (transport == null) return StatusCode(404);

			_context.Transports.Remove(transport);
			_context.SaveChanges();

			FileManager.Delete(_env.WebRootPath, "uploads/transports", transport.Image);

			return StatusCode(200);
		}
	}
}

