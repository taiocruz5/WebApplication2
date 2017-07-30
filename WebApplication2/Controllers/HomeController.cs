using Microsoft.AspNetCore.Mvc;


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
            ViewData["Message"] = "Welcome to OpenPlay!";

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
       

