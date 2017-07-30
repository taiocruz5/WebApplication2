using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Identity;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Models;

namespace Events.Controllers
{
    public class BadmintonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public BadmintonController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public int OR { get; private set; }

        public ViewResult Index()
        {
            return View("MyView");
        }

        [HttpGet]
        public async Task<ViewResult> RSVPFormAsync()
        {
            ApplicationUser currentuser = await _userManager.GetUserAsync(User);
            if (currentuser != null)
            {
                return View("RSVPForm");
            }
            else
            {
                return View("Error");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult RSVPForm(PartyInvites.Models.GuestResponse guestresponse) {
            if (ModelState.IsValid)
            {
                PartyInvites.Models.BadmintonRepository.AddResponse(guestresponse);
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
