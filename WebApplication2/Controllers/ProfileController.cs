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



namespace WebApplication2.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ProfileController(ApplicationDbContext context,UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        

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
        public async Task<IActionResult> Edit([Bind("Id,DisplayName,BirthDate,Gender,ProfilePicture,Description")] Profile profile)
        {
            

            if (ModelState.IsValid)
            {
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
            return View(profile);
        }

        

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
