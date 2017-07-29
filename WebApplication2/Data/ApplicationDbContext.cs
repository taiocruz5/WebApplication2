using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Models.Identity;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<WebApplication2.Models.ProfileSearchResultViewModel> ProfileSearchResultViewModel { get; set; }

        
        
    }
}
