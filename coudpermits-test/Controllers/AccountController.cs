using Microsoft.AspNetCore.Mvc;

namespace coudpermits_test.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return RedirectToAction("login", "Home");
            }
            else
            {
                Console.WriteLine("Login Sucess");
            }
            return View();
        }
    }
}
