﻿using Microsoft.AspNetCore.Mvc;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public ActionResult MyView()
        { //pass action and controller name to be directed
            return this.RedirectToAction("Index", "PartyController");
        }

        public IActionResult Profile()
        {
            return View();
        }
    }

}
       

