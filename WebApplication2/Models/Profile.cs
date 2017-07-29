using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public GenderType Gender { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Description \nEnter your preferred sports here!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ApplicationUser User { get; set; }
    }
}
