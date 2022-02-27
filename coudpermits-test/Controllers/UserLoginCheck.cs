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
    public class UserLoginCheck : Controller
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
    }
}
