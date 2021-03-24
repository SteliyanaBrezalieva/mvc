using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DataAccess;
using Project.Entities;
using Project.Filters;
using Project.ViewModels.Home;
using Project.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project.Controllers
{

    [AuthenticationFilter]
    public class UsersController : Controller
    {

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    //if (this.HttpContext.Session.GetString("loggedUser") == null)
        //    //{
        //    //    return RedirectToAction("Login", "Home");
        //    //}
        //    return View();
        //}
        public IActionResult Index(IndexVM model)
        {
            //if (this.HttpContext.Session.GetString("loggedUser") == null)
            //{
            //    return RedirectToAction("Login", "Home");
            //}

            // UsersRepository repo = new UsersRepository();

            MyDbContext context = new MyDbContext();
            model.Items = context.Users.ToList();
            //model.Items = repo.GetAll();

            return View(model);
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
            if (!ModelState.IsValid) {
            return View();
            }
            //UsersRepository repo = new UsersRepository(); 
            MyDbContext context = new MyDbContext();

            User item = new User();
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            //repo.Insert(item);
            context.Users.Add(item);
           context.SaveChanges();


            return RedirectToAction("Index", "Users");
        }

        public IActionResult Delete(int id)//трябва ми id-то на записа,който трия
        {

           //// MyDbContext context = new MyDbContext();
            UsersRepository repo = new UsersRepository();
            User item = new User();
            item.Id = id;

            repo.Delete(item);
            //context.Users.Delete(item);
          ///  context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            MyDbContext context = new MyDbContext();
            UsersRepository repo = new UsersRepository();
            User item = repo.GetById(id);

            //User item = context.Users
            //                        .Where(u => u.Id == id)
            //                        .FirstOrDefault();
            if (item == null)
            
                return RedirectToAction("Index", "Users");
            
            
                EditVM model = new EditVM();
                model.Id = item.Id;
                model.Username = item.Username;
                model.Password = item.Password;
                model.FirstName = item.FirstName;
                model.LastName = item.LastName;


             
                return View(model);
            

            

        }

        [HttpPost]
        public IActionResult Edit(EditVM model) //да може да създaва User
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            MyDbContext context = new MyDbContext();
            UsersRepository repo = new UsersRepository();

            User item = new User();
            item.Id = model.Id;//не се редактира, подава се като скрит параметър
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            //записите се променят по първичен ключ
             repo.Update(item);

            //context.Users.Update(item);
            //context.SaveChanges();

            //save user to database 
            return RedirectToAction("Index", "Users");
        }
    }
}




 