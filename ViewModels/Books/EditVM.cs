using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels.Books
{
    public class EditVM
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }
    }
}
