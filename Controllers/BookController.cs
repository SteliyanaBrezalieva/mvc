using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DataAccess;
using Project.Entities;
using Project.Filters;
using Project.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class BookController : Controller
    
    {
        [AuthenticationFilter]

        //public IActionResult Index()
        //{
        //    return View();
        //}

       
        //[HttpGet]
        public IActionResult Index(IndexVM model)
        {
            int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));


            MyDbContext context = new MyDbContext();
            //if (this.HttpContext.Session.GetString("loggedUser") == null)
            //{
            //    return RedirectToAction("Login", "Home");
            //}

            //  int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));
            model.Items = context.Books
                                       //.Where(c => c.UserId == loggedUserId)
                                        .ToList();
          // BookRepository repo = new BookRepository();
          //  model.Items = repo.GetAll();
           // repo.GetAll();

            return View(model);
        }



        [HttpGet]
        public IActionResult Share(int id)
        {

            ShareVM model = new ShareVM();

            MyDbContext context = new MyDbContext();

           // Book item = new Book();
            model.Book = context.Books
                                    .Where(u => u.Id == id)
                                    .FirstOrDefault();

            model.SharedWith = context.UserToBooks
                                .Include(utc => utc.ParentUser)
                                .Include(utc => utc.ParentBook)
                                .Where(i => i.BookId == model.Book.Id)
                                .Select(i => i.ParentUser)
                                .ToList();

            //model.Users = context.Users.ToList();
            model.Users = new List<User>();
            UsersRepository repo = new UsersRepository();

            foreach (User user in repo.GetAll())
            {
                if (model.SharedWith.Where(i => i.Id == user.Id).Count() > 0)
                    continue;

                model.Users.Add(user);

            }



            return View(model);
        }
        [HttpPost]
        public IActionResult Share(ShareVM model)
        {

            MyDbContext context = new MyDbContext();

            //using (UnitOfWork uow = new UnitOfWork())
            //{
            //    //try
            //    //{
            //    uow.BeginTransaction();
            //    UsersToBookRepository repo = new UsersToBookRepository(uow);
            //    List<UserToBook> shares = repo.GetAll(i => i.BookId == model.BookId);

                //foreach (int userId in model.UserIds)
                //{
                //    if (shares.Where(i => i.UserId == userId).Count() > 0)
                //        continue;

                    UserToBook userToBook = new UserToBook();
                    userToBook.UserId = model.UserId;
                    userToBook.BookId = model.BookId;

            context.UserToBooks.Add(userToBook);
            context.SaveChanges();

                    //repo.Insert(userToBook);
                
                //uow.Comit();
            
            //след излизане от using - се изпълнява dispose iow
            
            //finally
            //{
            //    uow.Dispose();
            //}

          



            return RedirectToAction("Share", "Book" , new { id = model.BookId});
        }


        public IActionResult RevokeAccess( int UserId, int BookId)
        {
            MyDbContext context = new MyDbContext();

           UserToBook item = context.UserToBooks
                                                .Where(utc => utc.UserId == UserId &&
                                                              utc.BookId == BookId)
                                                .FirstOrDefault();

            if(item != null)
            {
                context.UserToBooks.Remove(item);
                context.SaveChanges();
            }

            return RedirectToAction("Share", "Book", new { id = BookId });



        }




        [HttpGet]
        public IActionResult Create()
        {
            //if (this.HttpContext.Session.GetString("loggedUser") == null)
            //{
            //    return RedirectToAction("Login", "Home");
            //}
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {

            int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));


                if (!ModelState.IsValid)
                {
                    return View(model);
                }
            //BookRepository repo = new BookRepository();

            MyDbContext context = new MyDbContext();

                Book item = new Book();
              //  item.UserId = loggedUserId;
                item.Title = model.Title;
                item.Author = model.Author;
                item.Genre = model.Genre;

//
           // repo.Add(item);
            context.Books.Add(item);
            context.SaveChanges();

            //context.Books.Add(item);
            //context.SaveChanges();



            return RedirectToAction("Index", "Users");
            
        }



        public IActionResult Delete(int id)//трябва ми id-то на записа,който трия

        {
            MyDbContext context = new MyDbContext();
          BookRepository repo = new BookRepository();
            Book item = new Book();
            item.Id = id;

            //context.Entry(item).State = EntityState.Deleted;
            //context.SaveChanges();

            repo.Delete(item);

            return RedirectToAction("Index", "Book");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MyDbContext context = new MyDbContext();
            Book item = context.Books
                                    .Where(u => u.Id == id)
                                    .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Book");
            
              EditVM model = new EditVM();
               // model.BookId = item.Id;
                model.Title = item.Title;
                model.Author = item.Author;
                model.Genre = item.Genre;
             

                return View(model);
            
        }

        [HttpPost]
        public IActionResult Edit(EditVM model) //да може да създaва User
        {
            if (!ModelState.IsValid)
                return View(model);
            

            MyDbContext context = new MyDbContext();

           // BookRepository repo = new BookRepository();

            Book item = new Book();
            item.Id = model.Id;//не се редактира, подава се като скрит параметър
            item.Title = model.Title;
            item.Author = model.Author;
            item.Genre = model.Genre;


            //записите се променят по първичен ключ
            context.Books.Update(item);
          
            context.SaveChanges();

//context.Books.Update(item);
  //          context.SaveChanges();

            //save user to database 
            return RedirectToAction("Index", "Book");
        }
    }
}


