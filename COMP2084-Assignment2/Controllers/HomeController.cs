using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace COMP2084_Assignment2.Controllers
{
    public class HomeController : Controller
    {
        //Allow anyone (authenticated or not) to view the home page
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}