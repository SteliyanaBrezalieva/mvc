using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels.Home
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This field is empty!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is empty!")]
        public string Password { get; set; }
    }
}
