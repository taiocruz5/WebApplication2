using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ProfileSearchResultViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Display Name")]
        public Profile DisplayName { get; set; }

        [Display(Name = "Description")]
        public Profile Description { get; set; }

        [Display(Name = "Age")]
        public DateTime Age { get; set; }

        [Display(Name = "Gender")]
        public GenderType Gender { get; set; }
    }
}
