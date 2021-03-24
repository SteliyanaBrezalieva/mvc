using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels.Users
{
    public class EditVM
    { 
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is empty!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is empty!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is empty!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is empty!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is empty!")]
        public string Email { get; set; }
    }
}
