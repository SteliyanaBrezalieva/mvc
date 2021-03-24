using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } //DBContext ще управлява Users
        public DbSet<Book> Books { get; set; }

        public DbSet<Entities.UserToBook> UserToBooks { get; set; }

        public MyDbContext()
        {
            Users = this.Set<User>();
            Books = this.Set<Book>();
            UserToBooks = this.Set<Entities.UserToBook>();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Users;User Id=stelinna;Password=12345678910;"); //connection string - казва ни по какъв начин се връзваме към БД

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Username = "admin",
                Password = "admin123",
                FirstName = "Steliyana",
                LastName = "Brezalieva"

            });

        }
    }
}
