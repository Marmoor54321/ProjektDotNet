using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            };

            return View(uzytkownicy.ToList());
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
