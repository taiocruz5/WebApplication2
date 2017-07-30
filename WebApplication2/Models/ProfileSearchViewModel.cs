using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ProfileSearchViewModel
    {
        [Display(Name = "Who are you looking for?")]
        public Profile DisplayName { get; set; }

        [Display(Name = "Search for any matching descriptions:")]
        public Profile Description { get; set; }
    }
}
