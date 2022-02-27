using Microsoft.AspNetCore.Mvc;
using coudpermits_test.Models;

namespace coudpermits_test.Controllers
{
    public class AccountController : Controller
    {
        public bool loginCheck()
        {
            bool userLogin = false;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {

                return userLogin;
            }
            else
            {
                userLogin = true;
                return userLogin;
            }

        }

      




        public IActionResult dashboard()
        {
            if (loginCheck() == true)
            {
                return View();
               
              
            }

            else
            {
                return RedirectToAction("login", "Home");
            }
            return RedirectToAction("login", "Home");
        }

        public IActionResult add_inventory()
        {
            if (loginCheck() == true)
            {
                return View();
               

            }

            else
            {
                return RedirectToAction("login", "Home");
            }
        }



      






    }
}
