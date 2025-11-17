using Microsoft.AspNetCore.Mvc;

namespace Login_Auth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Alle()
        {
            string? username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Alle");
            }
            return View();
        }

        public IActionResult Privat()
        {
            string? username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            string? username = HttpContext.Session.GetString("Username");
            if (!string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                HttpContext.Session.SetString("Username", username);

                return RedirectToAction("Privat");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }
    }
}
