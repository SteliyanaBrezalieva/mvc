using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.DataAccess;
using Project.Entities;
using Project.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }
       
        //public IActionResult Books()
        //{
        //    return View();
        //}

        //public IActionResult Authors()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Logout()
        {
            if(this.HttpContext.Session.GetString("LoggedUserId")== null)
                 return RedirectToAction("Index","Home");


            this.HttpContext.Session.Remove("LoggedUserId");

            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public IActionResult Login()
        {
            if (this.HttpContext.Session.GetString("loggedUser") != null)
                return RedirectToAction("Index", "Home");
            

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (this.HttpContext.Session.GetString("loggedUser") != null)          
                return RedirectToAction("Index", "Home");
            


            if (!ModelState.IsValid)
                return View();

            

            MyDbContext context = new MyDbContext();

            //User item = context.Users
            //    .Where(u => u.Username == model.Username &&
            //     u.Password == model.Password)
            //    .FirstOrDefault();

            User loggedUser = context.Users.Where(u => u.Username == model.Username &&
                                                       u.Password == model.Password)
                                           .FirstOrDefault();

            if (loggedUser == null)
            {
                ModelState.AddModelError("AuthenticationFailed", "Wrong Username or Password");
                   return View(model);
            }//

            //// this.HttpContext.Session.SetString("loggedUser", model.Username);


            //bool isAuthenticated = false;

            //if( model.Username == "stel" && model.Password == "1234")
            //{
            //    isAuthenticated = true;
            //}

            //if (!isAuthenticated)
            //{
            //    ModelState.AddModelError("AuthenticationFailed", "Wrong Username or Password");
            //    return View();

            //}


            this.HttpContext.Session.SetString("LoggedUserId", loggedUser.Id.ToString());
            this.HttpContext.Session.SetString("LoggedUserUsername", loggedUser.Username);




            return RedirectToAction("Index","Home");

        }       

        //public IActionResult Logout()
        //{
        //    if (this.HttpContext.Session.GetString("logggedUser") == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    this.HttpContext.Session.Remove("loggedUser");
        //    return RedirectToAction("Index","Login");
        //}



    }
}
