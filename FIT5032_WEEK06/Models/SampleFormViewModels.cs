using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FIT5032_WEEK06.Models
{
    public class SampleFormViewModels
    {
    }

    public class FormOneViewModel 
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "The length have to between 1 and 5!")]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}