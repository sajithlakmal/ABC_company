using coudpermits_test.Models;
using coudpermits_test.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using coudpermits_test.ViewModel;
using System.Collections;
using System.Web;
using RestSharp;

namespace coudpermits_test.Controllers
{
    public class HomeController : Controller
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



        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        { 
         
            return View();
        }
        public IActionResult login()
        {

            if (loginCheck() == true)
            {
                return RedirectToAction("dashboard", "account");
                return View();


            }

            else
            {
                ViewData["Layout"] = "~/_UserLayout.cshtml";
                return View();
            }
           


            return View();
        }
        public IActionResult add_inventory()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult login([Bind] LoginViewModel ad)
        {
            DB dbop = new DB();
            int res = dbop.LoginCheck(ad);
            if (res == 1)
            {

                HttpContext.Session.SetString("email", ad.Email);

                var name = HttpContext.Session.GetString("email");


                _logger.LogInformation("Session Name: {Name}", name);

                return RedirectToAction("dashboard", "account");
             
            }
            else
            {
                Response.Redirect("login");

            }
            return View();
        }


    }
}