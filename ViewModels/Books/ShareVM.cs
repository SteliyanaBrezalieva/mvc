using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels.Books
{
    public class ShareVM
    {
        //public List<int> UserIds { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public Book Book { get; set; }
        public List<User> SharedWith { get; set; }
        public List<User> Users { get; set; }
    }
}
