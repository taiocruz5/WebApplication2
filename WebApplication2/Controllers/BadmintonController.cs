using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;


namespace Events.Controllers
{
    public class BadmintonController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RSVPForm(){
            return View();
        }
        [HttpPost]
        public ViewResult RSVPForm(GuestResponse guestresponse) {
            if (ModelState.IsValid)
            {
                BadmintonRepository.AddResponse(guestresponse);
                return View("Thanks", guestresponse);
            }
            else
            {
                //there is a validation error
                return View();

            }
        }
        public ViewResult ListResponses()
        {
            return View(BadmintonRepository.Responses.Where(r => r.WillAttend == true));
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
    }
}
