﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace COMP2084_Assignment2.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.isLoggedIn = User.Identity.GetUserId();
            if(!String.IsNullOrEmpty(User.Identity.GetUserId()))
            {

            }

            return View();
        }
    }
}