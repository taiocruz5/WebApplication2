using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Models.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;
        private object SqlMethods;

        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        public int OR { get; private set; }
       

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        //[HttpGet]
        //public IActionResult Search()
        //{
        //    ProfileSearchViewModel vm = new ProfileSearchViewModel();
        //    vm.DisplayName = "Hazim";

        //    return View(vm);
        //}

        //[HttpGet]
        //public IActionResult Search(ProfileSearchViewModel vm)
        //{
        //    List<ProfileSearchResultViewModel> result = new List<ProfileSearchResultViewModel>();
        //    if (ModelState.IsValid)
        //    {
        //        result = (from p in _context.Profiles
        //                  where p.DisplayName.Contains(vm.DisplayName.ToString())
        //                  && p.Description.Contains(vm.Description.ToString())

        //                  select new ProfileSearchResultViewModel
        //                  {
        //                      DisplayName = View((object)p.DisplayName),
        //                      Description = RedirectToAction(p.Description),
        //                      ProfilePicture = $"{p.Id}/{p.ProfilePicture}",
        //                      Gender = p.Gender
        //                  }
        //                  ).ToList();
                          
                


        //    }
        //    return View("Result", result)
        //}

        // GET: Profile/Edit/5

        public async Task<IActionResult> Edit()
        {
            ApplicationUser currentuser = await _userManager.GetUserAsync(User);
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == currentuser.ProfileId);
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,DisplayName,BirthDate,Gender,ProfilePicture,Description,ProfilePictureFile")] Profile profile, IFormFile ProfilePictureFile)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentuser = await _userManager.GetUserAsync(User);

                if (ProfilePictureFile != null)
                {
                    string uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPath, currentuser.ProfileId.ToString()));

                    string filename = Path.GetFileName(ProfilePictureFile.FileName);

                    using (FileStream fs = new FileStream(Path.Combine(uploadPath, currentuser.ProfileId.ToString(), filename), FileMode.Create))
                    {
                        await ProfilePictureFile.CopyToAsync(fs);
                    }
                    profile.ProfilePicture = filename;


                }
                
            }

            try
            {
                _context.Update(profile);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProfileExists(profile.Id))
                //{
                //return NotFound();
                //}
                //else
                //{
                //throw;
                //}
            }
            return RedirectToAction("Index");
        }

    }
}

        

 