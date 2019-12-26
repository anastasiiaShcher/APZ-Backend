using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dvor.Common.Entities;

namespace Dvor.Web.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Full name length must be between 2 and 25 symbols")]
        public string Name { get; set; }

        public IList<string> Allergies { get; set; }

        public IList<Allergy> AllAllergies { get; set; }
    }
}