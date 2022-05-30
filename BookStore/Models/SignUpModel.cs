using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "please fill Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "please fill Email")]
        public string Email { set; get; }
        [Compare("ConfirmPassword")]
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }

        public string RoleId { set; get; }
    }
}
