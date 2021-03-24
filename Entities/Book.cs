using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Book : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }


        public string Genre { get; set; }


        [ForeignKey("UserId")]
        public User ParentUser { get; set; }


    }
}
