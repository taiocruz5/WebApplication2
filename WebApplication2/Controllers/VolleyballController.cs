using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using Microsoft.AspNetCore.Authorization;

namespace PartyInvites.Controllers
{
    public class VolleyballController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        [Authorize]
        public ViewResult RSVPForm(){
            return View();
        }
        [HttpPost]
        public ViewResult RSVPForm(VolleyBallResponse volleyballresponse) {
            if (ModelState.IsValid)
            {
                VolleyballRepository.AddResponse(volleyballresponse);
                return View("Thanks", volleyballresponse);
            }
            else
            {
                //there is a validation error
                return View();

            }
        }
        public ViewResult ListResponses()
        {
            return View(VolleyballRepository.Responses.Where(r => r.WillAttend == true));
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
