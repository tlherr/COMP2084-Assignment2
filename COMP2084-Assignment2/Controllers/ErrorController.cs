using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COMP2084_Assignment2.Controllers
{
    //This controller implements our custom error handling methods. Basically we are just returning back views with some text at this point
    public class ErrorController : Controller
    {
        // GET: Error/NotFound
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
        // GET: Error/Error
        public ActionResult Error()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}