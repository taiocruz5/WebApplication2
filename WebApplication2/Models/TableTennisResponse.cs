using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class TableTennisResponse {
        [Required(ErrorMessage ="Please Enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter your contact number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage ="Please specify whether or not you are coming")]
        public bool? WillAttend { get; set; }




    
    }
}

