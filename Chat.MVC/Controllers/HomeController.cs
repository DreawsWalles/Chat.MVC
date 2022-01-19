using Chat.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System.Diagnostics;

namespace Chat.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Chat");
            else
                return RedirectToAction("Login", "Account");
        }
    }
}