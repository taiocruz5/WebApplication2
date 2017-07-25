using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Identity;

namespace WebApplication2.Models
{ 
    public enum GenderType
    {
        Male,
        Female,
        AttackHelicopter

    }


    public class Profile
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderType Gender { get; set; }

        public string ProfilePicture { get; set; }

        public string Description { get; set; }

        public ApplicationUser User { get; set; }
    }
}
