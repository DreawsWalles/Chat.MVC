using Microsoft.AspNetCore.Mvc;

namespace Chat.MVC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            string tmp = User.Identity.Name;
            return View();
        }
    }
}
