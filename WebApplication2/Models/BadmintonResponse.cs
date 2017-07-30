using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class BadmintonResponse {
        [Required(ErrorMessage ="Please Enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter your Email Address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage ="Please Enter a Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter your Contact Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage ="Please Specify If you are Coming")]
        public bool? WillAttend { get; set; }    
    }
}

