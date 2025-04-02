using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aammc.DAL;
using aammc.Models;
using aammc.ViewModels;
using System.Data;
using aammc.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aammc.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("manage")]
    public class ProjectController : Controller
    {
        private readonly AammcDbContext _context;

        public IWebHostEnvironment _env;

        public ProjectController(AammcDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Projects.AsQueryable();

            if (search != null)
                query = query.Where(x => x.TitleAz.Contains(search));

            ViewBag.Search = search;

            return View(PaginatedList<Project>.Create(query, page, 6));
        }

        public IActionResult Create()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Project project)
        {
            project.Image = FileManager.Save(_env.WebRootPath, "uploads/projects", project.ImageFile);


            _context.Projects.Add(project);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Project project = _context.Projects.FirstOrDefault(x => x.Id == id);

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project project)
        {

            Project existProject = _context.Projects.FirstOrDefault(x => x.Id == project.Id);

            if (existProject == null) return View("Error");



            string oldImage = null;
            if (project.ImageFile != null)
            {
                oldImage = project.Image;

                if (project.Image == null)
                {
                    project.Image = FileManager.Save(_env.WebRootPath, "uploads/projects", project.ImageFile);
                    existProject.Image = project.Image;
                }
                else
                    project.Image = FileManager.Save(_env.WebRootPath, "uploads/projects", project.ImageFile);
            }

            existProject.TitleAz = project.TitleAz;
            existProject.TitleEn = project.TitleEn;
            existProject.TitleRu = project.TitleRu;
            existProject.DescriptionAz = project.DescriptionAz;
            existProject.DescriptionEn = project.DescriptionEn;
            existProject.DescriptionRu = project.DescriptionRu;

            _context.SaveChanges();


            if (oldImage != null) FileManager.Delete(_env.WebRootPath, "uploads/projects", oldImage);


            return RedirectToAction("index");
        }


        public IActionResult Delete(int id)
        {
            Project project = _context.Projects.Find(id);
            if (project == null) return NotFound();

            _context.Projects.Remove(project);
            _context.SaveChanges();

            FileManager.Delete(_env.WebRootPath, "uploads/projects", project.Image);

            return RedirectToAction("index");
        }
    }


}
