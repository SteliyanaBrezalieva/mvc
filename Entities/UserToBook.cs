using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class UserToBook : BaseEntity
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }


        [ForeignKey("UserId")]
        public User ParentUser { get; set; }
        [ForeignKey("BookId")]
        public Book ParentBook { get; set; }
    }


}
