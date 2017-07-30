using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class TableTennisController : Controller
    {
        public ViewResult Index()
        {
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RSVPForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RSVPForm(TableTennisResponse tabletennisreponse) {
            if (ModelState.IsValid)
            {
                TableTennisRepository.AddResponse(tabletennisreponse);
                return View("Thanks",tabletennisreponse );
            }
            else
            {
                //there is a validation error
                return View();

            }
        }
        public ViewResult ListResponses()
        {
            return View(TableTennisRepository.Responses.Where(r => r.WillAttend == true));
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
