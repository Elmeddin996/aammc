using aammc.DAL;
using aammc.Models;
using aammc.Services;
using aammc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aammc.Controllers
{
	public class ContactController : Controller
	{
		private readonly AammcDbContext _context;
        private readonly IEmailSender _emailSender;

        public ContactController(AammcDbContext context, IEmailSender emailSender)
		{
			_context = context;
            _emailSender = emailSender;
        }
		public IActionResult Index()
		{
            MenuViewModel model = new MenuViewModel
            {
            Settings  = _context.Settings.FirstOrDefault(),
            Project  = _context.Projects.ToList()
            };

			return View(model);
		}

        [HttpPost]
        public IActionResult Index(ContactPageMessageViewModel vm)
        {
            Settings settings = _context.Settings.FirstOrDefault();

            string messageBody = $@"
             <p><strong>Ad Soyad:</strong> {vm.Fullname}</p>
             <p><strong>Telefon:</strong> {vm.Phone}</p>
             <p><strong>E-Mail:</strong> {vm.Email}</p>
             <p><strong>Mesaj:</strong> {vm.Message}</p>";

            _emailSender.Send(settings.Email, "Saytadan Bir Başa Mesaj", messageBody);
            return View(settings);
        }
    }
}
