using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Identity;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Models;
using Microsoft.AspNetCore.Authorization;

namespace Events.Controllers
{
    public class BadmintonController : Controller
    {
        public ViewResult Index()
        {
            return View("MyView");
        }

        [HttpGet]
        [Authorize]
        public ViewResult RSVPForm()
        {
            return View();
        }


        [HttpPost]
        public ViewResult RSVPForm(PartyInvites.Models.BadmintonResponse badmintonresponse) {
            if (ModelState.IsValid)
            {
                PartyInvites.Models.BadmintonRepository.AddResponse(badmintonresponse);
                return View("Thanks", badmintonresponse);
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
