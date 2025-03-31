using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektDotNet.Data;
using ProjektDotNet.Models;

namespace ProjektDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsersContext _context;

        public HomeController(ILogger<HomeController> logger, UsersContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string sortOrder)
        {
            var uzytkownicy = _context.User.Include(u => u.Group).AsQueryable();

            uzytkownicy = sortOrder switch
            {
                "name" => uzytkownicy.OrderBy(u => u.Name),
                "firstname" => uzytkownicy.OrderBy(u => u.FirstName),
                "lastname" => uzytkownicy.OrderBy(u => u.LastName),
                "group" => uzytkownicy.OrderBy(u => u.Group != null ? u.Group.Name : ""),
                _ => uzytkownicy.OrderBy(u => u.Id)
            };

            return View(uzytkownicy.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.GroupId = new SelectList(_context.Groups, "Id", "Name");//lista grup wyœwietlana
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Dodanie nowego u¿ytkownika do bazy danych
                _context.Add(user);
                await _context.SaveChangesAsync();

                // Przekierowanie do akcji Index po zapisaniu
                return RedirectToAction(nameof(Index));
            }

            // Jeœli wyst¹pi³y b³êdy walidacji, przekazanie listy grup do widoku
            ViewBag.GroupId = new SelectList(_context.Groups, "Id", "Name", user.GroupId);

            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
 
    }

}
